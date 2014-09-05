namespace Homework
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Threading;
    using MongoDB.Bson;
    using MongoDB.Driver;

    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Window
    {
        private const string MongoUri = "mongodb://user:telerik@ds035300.mongolab.com:35300/crowdchat";
        private static readonly MongoUrl MongoUrl = new MongoUrl(MongoUri);
        private static readonly MongoClient MongoClient = new MongoClient(MongoUrl);
        private static readonly MongoServer MongoServer = MongoClient.GetServer();
        private static readonly MongoDatabase MongoDb = MongoServer.GetDatabase(MongoUrl.DatabaseName);        
        private DispatcherTimer timer = new DispatcherTimer();
        private ObservableCollection<string> allMessages = new ObservableCollection<string>();
        
        public ChatPage()
        {
            this.InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Closing += this.OnWindowClosing;

            this.GetAllMessages();
            this.DataContext = this.allMessages;

            this.timer.Tick += new EventHandler(this.Timer_Tick);
            this.timer.Interval = new TimeSpan(0, 0, 1);
            this.timer.Start();
        }

        private void OnWindowClosing(object sender, CancelEventArgs e) 
        {
            Environment.Exit(0);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.allMessages.Clear();
            this.GetAllMessages();
        }

        private void GetAllMessages()
        {
            var messages = MongoDb.GetCollection<BsonDocument>("messages").FindAll();

            foreach (var message in messages)
            {
                var date = string.Format("{0}-{1}-{2} {3}:{4}:{5}", message["Date"].ToUniversalTime().Year, message["Date"].ToUniversalTime().Month, message["Date"].ToUniversalTime().Day, message["Date"].ToUniversalTime().Hour, message["Date"].ToUniversalTime().Minute, message["Date"].ToUniversalTime().Second);
                var user = this.GetValue(message, "User");
                var post = this.GetValue(message, "Post");

                var currentMessage = string.Format("<{0}><{1}>: {2}", date, user, post);
                this.allMessages.Add(currentMessage);
            }
        }

        private string GetValue(BsonDocument document, string key)
        {
            string value = string.Empty;
            if (document.Contains(key))
            {
                value = document[key].ToString();
            }

            return value;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var messages = MongoDb.GetCollection<BsonDocument>("messages");

            var message = new Message
            {
                Id = Guid.NewGuid(),
                User = this.txtBoxUserName.Text,
                Post = this.txtBoxMessage.Text,
                Date = DateTime.Now
            };

            messages.Insert<Message>(message);

            this.txtBoxMessage.Text = string.Empty;
            this.txtBoxMessage.Focus();
        }
    }
}