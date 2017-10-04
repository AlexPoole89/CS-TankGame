using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace tbUI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();

            string playername = tbUserLogin.Text;

            db.ExecuteQueries("SELECT Username FROM Users WHERE Username = @Username");

            if (playername.Equals("@Username"))
            {
                db.ExecuteQueries("SELECT Username FROM Users WHERE Username = @Username");
            }
            else
            //create new user
            {
                db.ExecuteQueries("INSERT INTO Users ");
            }
           
            //TODO: if username exists, select user
            // if username doesn't exist, insert new user

            
        }
    }
}
