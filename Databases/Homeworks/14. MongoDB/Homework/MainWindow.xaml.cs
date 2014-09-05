namespace Homework
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChatPage chatPage = new ChatPage();

        public MainWindow()
        {
            this.InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.txtBoxUserName.Focus();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtBoxUserName.Text != string.Empty)
            {
                this.chatPage.txtBoxUserName.Text = this.txtBoxUserName.Text;
                this.chatPage.ShowDialog();
            }
            else
            {
                this.txtBoxUserName.Focus();
                MessageBox.Show("Please choose nickname!");
            }            
        }
    }
}
