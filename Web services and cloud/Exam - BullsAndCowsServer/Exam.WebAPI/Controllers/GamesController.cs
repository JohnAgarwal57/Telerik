namespace Exam.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Exam.Data;
    using Exam.Models;
    using Exam.WebAPI.Models;

    public class GamesController : BaseController
    {
        private const int DefaultPageSize = 10;
        private readonly IApplicationData data;

        public GamesController() : this(new ApplicationData())
        {
        }

        public GamesController(IApplicationData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult GetPublicGames(int page)
        {
            var games = this.GetAllSorted();

            if (this.User.Identity.Name != null)
            {
                var currentUser = this.User.Identity.Name;
                games = games.Where(u => u.Red == currentUser || u.Blue == currentUser || u.GameState == GameState.WaitingForOpponent.ToString())
                             .Skip(page * DefaultPageSize)
                             .Take(DefaultPageSize);
            }
            else
            {
                games = games.Where(g => g.GameState == GameState.WaitingForOpponent.ToString()).Skip(page * DefaultPageSize).Take(DefaultPageSize);
            }

            return this.Ok(games);
        }

        [HttpGet]
        public IHttpActionResult GetPublicGames()
        {
            var games = this.GetAllSorted();

            if (this.User.Identity.Name != null)
            {
                var currentUser = this.User.Identity.Name;
                games = games.Where(u => u.Red == currentUser || u.Blue == currentUser || u.GameState == GameState.WaitingForOpponent.ToString())
                             .Take(DefaultPageSize);
            }
            else
            {
                games = games.Where(g => g.GameState == GameState.WaitingForOpponent.ToString()).Take(DefaultPageSize);
            }

            return this.Ok(games);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var game = this.data.Games.All().Select(GameModel.FromGameWithDetails).FirstOrDefault(g => g.Id == id);

            if (game.GameState != GameState.RedInTurn.ToString() && game.GameState != GameState.BlueInTurn.ToString())
            {
                return this.BadRequest("The game is not in process!");
            }

            return this.Ok(game);
        }
        
        [Authorize]
        [HttpPost]
        public IHttpActionResult CreateGame(GameCreateModel game)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Please input game name and secret number!");
            }

            if (!this.ValidNumber(game.Number))
            {
                return this.BadRequest("The number isn't valid");
            }

            var newGame = new Game
            {
                Name = game.Name,
                Red = this.User.Identity.Name,
                RedNumber = game.Number,
                Blue = "No blue player yet",
                BlueNumber = "0",
                Guesses = new HashSet<Guess>(),
                GameState = GameState.WaitingForOpponent,
                DateCreated = DateTime.Now,
            };

            this.data.Games.Add(newGame);
            this.data.SaveChanges();

            var responceModel = new GameModel
            {
                Id = newGame.Id,
                Name = newGame.Name,
                Blue = newGame.Blue,
                Red = newGame.Red,
                GameState = newGame.GameState.ToString(),
                DateCreated = newGame.DateCreated.ToString()
            };

            var location = new Uri(this.Url.Link("DefaultApi", new { id = newGame.Id }));
            var response = this.Created(location, responceModel);
            return response;
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult JoinGame(int id, GameBlueJoinModel model)
        {
            var existingGame = this.data.Games.All()
                                   .FirstOrDefault(g => g.Id == id);

            if (existingGame == null)
            {
                return this.BadRequest("Such game doens't exist");
            }

            var currentUser = this.data.Users.All().FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            if (existingGame.Red == currentUser.UserName)
            {
                return this.BadRequest("You cannot join game hosted by you!");
            }

            if (!this.ValidNumber(model.Number))
            {
                return this.BadRequest("The number isn't valid");
            }

            existingGame.Blue = currentUser.UserName;
            existingGame.BlueNumber = model.Number;

            var newNotification = new Notification
            {
                Message = string.Format("{0} joined your game \"{1}\"", currentUser.UserName, existingGame.Name),
                DateCreated = DateTime.Now,
                Type = NotificationType.GameJoined,
                GameId = existingGame.Id,
                State = State.Unread,
                UserId = currentUser.Id,
                User = currentUser
            };

            this.data.Notifications.Add(newNotification);

            var rand = new Random();
            var userInTurn = this.data.Users.All().FirstOrDefault(u => u.UserName == existingGame.Blue);

            if (rand.Next(10) > 5)
            {
                existingGame.GameState = GameState.BlueInTurn;
            }
            else
            {
                userInTurn = this.data.Users.All().FirstOrDefault(u => u.UserName == existingGame.Red);
                existingGame.GameState = GameState.RedInTurn;
            }

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

            this.data.Notifications.Add(turnNotification);
            
            this.data.SaveChanges();

            var responce = new
            {
                result = string.Format("You joined game \"{0}\"", existingGame.Name)
            };

            return this.Ok(responce);
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

        private IEnumerable<GameModel> GetAllSorted()
        {
            return this.data.Games.All()
                       .OrderBy(g => g.GameState)
                       .ThenBy(g => g.Name)
                       .ThenBy(g => g.DateCreated)
                       .ThenBy(g => g.Red)
                       .Select(GameModel.FromGame);
        }
    }
}