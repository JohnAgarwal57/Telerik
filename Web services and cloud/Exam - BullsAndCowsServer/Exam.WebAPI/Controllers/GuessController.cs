namespace Exam.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Exam.Models;
    using Exam.WebAPI.Models;

    public class GuessController : BaseController
    {
        [Authorize]
        [HttpPost]
        public IHttpActionResult MakeGuess(int id, GuessModel model)
        {
            var existingGame = this.data.Games.All()
                                   .FirstOrDefault(g => g.Id == id);

            if (existingGame.GameState == GameState.Finnished)
            {
                return this.BadRequest("You can't join finnished game!");
            }

            if (existingGame.GameState == GameState.WaitingForOpponent)
            {
                return this.BadRequest("This game hasn't started yet!");
            }

            var currentUser = this.data.Users.All().FirstOrDefault(u => u.UserName == this.User.Identity.Name);
            var currentUserName = currentUser.UserName;

            if (existingGame.Red != currentUserName && existingGame.Blue != currentUserName)
            {
                return this.BadRequest("You're not part of this game");
            }

            if ((existingGame.Blue == currentUserName && existingGame.GameState != GameState.BlueInTurn) ||
                (existingGame.Red == currentUserName && existingGame.GameState != GameState.RedInTurn))
            {
                return this.BadRequest("It's not your turn");
            }

            if (!this.ValidNumber(model.Number))
            {
                return this.BadRequest("The number isn't valid");
            }

            var bullsCount = 0;
            var cowsCount = 0;
            var userInTurn = this.data.Users.All().FirstOrDefault(u => u.UserName == existingGame.Blue);

            if (existingGame.Red == currentUserName)
            {
                var blueNumber = existingGame.BlueNumber;

                if (blueNumber != model.Number)
                { 
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (model.Number[i] == blueNumber[j]) 
                            {
                                if (i == j) 
                                {
                                    bullsCount++;
                                }
                                else 
                                {
                                    cowsCount++;
                                }
                            }
                        }
                    }

                    existingGame.GameState = GameState.BlueInTurn;
                }
                else
                {
                    bullsCount = 4;
                    existingGame.GameState = GameState.Finnished;

                    var winningPlayer = this.data.Users.All().FirstOrDefault(u => u.UserName == existingGame.Red);
                    var loosingPlayer = this.data.Users.All().FirstOrDefault(u => u.UserName == existingGame.Blue); 

                    var winNotification = CreateWinNotification(existingGame, winningPlayer, loosingPlayer);
                    var looseNotification = CreateLooseNotification(existingGame, winningPlayer, loosingPlayer);

                    var scoreWinningPlayer = this.data.Score.All().FirstOrDefault(s => s.UserName == winningPlayer.UserName);
                    this.WinScore(winningPlayer, scoreWinningPlayer);

                    var scoreLoosingPlayer = this.data.Score.All().FirstOrDefault(s => s.UserName == loosingPlayer.UserName);
                    this.LooseScore(loosingPlayer, scoreLoosingPlayer);

                    this.data.Notifications.Add(winNotification);
                    this.data.Notifications.Add(looseNotification);
                }
            }
            else
            {
                var redNumber = existingGame.RedNumber;

                if (redNumber != model.Number)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (model.Number[i] == redNumber[j]) 
                            {
                                if (i == j) 
                                {
                                    bullsCount++;
                                }
                                else 
                                {
                                    cowsCount++;
                                }
                            }
                        }
                    }

                    existingGame.GameState = GameState.RedInTurn;
                    userInTurn = this.data.Users.All().FirstOrDefault(u => u.UserName == existingGame.Red);
                }
                else
                {
                    bullsCount = 4;
                    existingGame.GameState = GameState.Finnished;

                    var winningPlayer = this.data.Users.All().FirstOrDefault(u => u.UserName == existingGame.Blue);
                    var loosingPlayer = this.data.Users.All().FirstOrDefault(u => u.UserName == existingGame.Blue);

                    var winNotification = CreateWinNotification(existingGame, winningPlayer, loosingPlayer);
                    var looseNotification = CreateLooseNotification(existingGame, winningPlayer, loosingPlayer);

                    var scoreWinningPlayer = this.data.Score.All().FirstOrDefault(s => s.UserName == winningPlayer.UserName);
                    this.WinScore(winningPlayer, scoreWinningPlayer);

                    var scoreLoosingPlayer = this.data.Score.All().FirstOrDefault(s => s.UserName == loosingPlayer.UserName);
                    this.LooseScore(loosingPlayer, scoreLoosingPlayer);

                    this.data.Notifications.Add(winNotification);
                    this.data.Notifications.Add(looseNotification);
                }
            }

            var turnNotification = CreateTurnNotification(existingGame, userInTurn);

            this.data.Notifications.Add(turnNotification);

            var newGuess = new Guess
            {
                Game = existingGame,
                GameId = existingGame.Id,
                Number = model.Number,
                UserId = currentUser.Id,
                DateMade = DateTime.Now,
                UserName = currentUser.UserName,
                User = currentUser,
                BullsCount = bullsCount,
                CowsCount = cowsCount
            };

            this.data.Guesses.Add(newGuess);
            this.data.SaveChanges();

            var newModel = new GuessResponceModel
            {
                Id = newGuess.Id,
                UserId = newGuess.UserId,
                UserName = newGuess.UserName,
                GameId = newGuess.GameId,
                Number = model.Number,
                DateMade = newGuess.DateMade.ToString(),
                CowsCount = newGuess.CowsCount,
                BullsCount = newGuess.BullsCount
            };

            return this.Ok(newModel);
        }

        private static Notification CreateWinNotification(Game existingGame, ApplicationUser winningPlayer, ApplicationUser loosingPlayer)
        {
            var winNotification = new Notification
            {
                Message = string.Format("You beat {0} in game \"{1}\"", loosingPlayer.UserName, existingGame.Name),
                DateCreated = DateTime.Now,
                Type = NotificationType.GameWon,
                GameId = existingGame.Id,
                State = State.Unread,
                UserId = winningPlayer.Id,
                User = winningPlayer
            };
            return winNotification;
        }

        private static Notification CreateLooseNotification(Game existingGame, ApplicationUser winningPlayer, ApplicationUser loosingPlayer)
        {
            var looseNotification = new Notification
            {
                Message = string.Format("{0} beat you in game \"{1}\"", winningPlayer.UserName, existingGame.Name),
                DateCreated = DateTime.Now,
                Type = NotificationType.GameLost,
                GameId = existingGame.Id,
                State = State.Unread,
                UserId = loosingPlayer.Id,
                User = loosingPlayer
            };
            return looseNotification;
        }

        private static Notification CreateTurnNotification(Game existingGame, ApplicationUser userInTurn)
        {
            var turnNotification = new Notification
            {
                Message = string.Format("It is your turn in game \" {0}\"", existingGame.Name),
                DateCreated = DateTime.Now,
                Type = NotificationType.YourTurn,
                GameId = existingGame.Id,
                State = State.Unread,
                UserId = userInTurn.Id,
                User = userInTurn
            };
            return turnNotification;
        }

        private void WinScore(ApplicationUser winningPlayer, Score scoreWinningPlayer)
        {
            if (scoreWinningPlayer == null)
            {
                var newScore = new Score
                {
                    UserName = winningPlayer.UserName,
                    Rank = 100
                };

                this.data.Score.Add(newScore);
            }
            else
            {
                scoreWinningPlayer.Rank += 100;
            }
        }

        private void LooseScore(ApplicationUser loosingPlayer, Score scoreLoosingPlayer)
        {
            if (scoreLoosingPlayer == null)
            {
                var newScore = new Score
                {
                    UserName = loosingPlayer.UserName,
                    Rank = 15
                };

                this.data.Score.Add(newScore);
            }
            else
            {
                scoreLoosingPlayer.Rank += 15;
            }
        }

        private bool ValidNumber(string guessedNumber)
        {
            var used = new int[10];
            var number = double.Parse(guessedNumber);

            while (Math.Floor(number) != 0) 
            {
                int currentIndex = Convert.ToInt32(Math.Floor(number % 10));
                if (used[currentIndex] == 1) 
                {
                    return false;
                }

                used[currentIndex] = 1;
                number /= 10;
            }
            
            return true;
        }
    }
}