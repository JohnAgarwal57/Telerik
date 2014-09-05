namespace Homework
{
    using System;
    using System.Linq;
    using System.Transactions;
    using System.Windows;
    using Atm.Data;
    using Atm.Models;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AtmDbContext data = new AtmDbContext();

        public MainWindow()
        {
            this.InitializeComponent();   
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void BtnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var account = new CardAccount()
            {
                CardNumber = this.cardNumber.Text,
                CardPin = this.cardPin.Text,
                CardCash = decimal.Parse(this.cardAmmount.Text)
            };

            this.data.CardAccounts.Add(account);
            this.data.SaveChanges();
        }

        private void BtnWithdrawCash_Click(object sender, RoutedEventArgs e)
        {
            var success = true;
            var ammount = decimal.Parse(this.withdrawAmmount.Text);
            var cardNumber = this.withdrawCardNumber.Text;
            var pin = this.withdrawCardPin.Text;

            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew,
                new TransactionOptions() 
                { 
                    IsolationLevel = IsolationLevel.RepeatableRead 
                }))
            {
                var card = this.data.CardAccounts.Where(c => c.CardNumber == cardNumber)
                               .FirstOrDefault();

                if (card == null || card.CardPin != pin || card.CardCash < ammount)
                {
                    success = false;
                }
                else
                {
                    card.CardCash -= decimal.Parse(this.withdrawAmmount.Text);
                    scope.Complete();
                }
            }

            if (success)
            {
                this.Log(cardNumber, ammount);
                this.data.SaveChanges();
                MessageBox.Show("Withdraw successful");
            }
            else
            {
                MessageBox.Show("Incorrect data!");
            }
        }

        private void Log(string cardNumber, decimal ammount)
        {
            var history = new TransactionsHistory()
            {
                CardNumber = cardNumber,
                TransactionDate = DateTime.Now,
                Ammount = ammount
            };

            this.data.TransactionsHistories.Add(history);
        }
    }
}