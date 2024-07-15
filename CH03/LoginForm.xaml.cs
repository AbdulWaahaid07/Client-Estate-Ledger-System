using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CH03
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == string.Empty || txtPassword.Password == string.Empty)
            { 
                return;
            }

            User loggedUser = checkMe(txtUsername.Text, txtPassword.Password);
            if (loggedUser == null || loggedUser.UserName == null)
            {
                MessageBox.Show("Username or password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUsername.Clear();
                txtPassword.Clear();
                txtPassword.Focus();
                //This is why it crashed 
                // all it needed was a return
                Declarations.LoggedUser = null;
                return;
            }
            //WHEN YOU RETURN TO DIRECT PASS:
            //===============
            //new MainWindow().Show(loggedUser);
            //this.Close();
            //===============
            Declarations.LoggedUser = loggedUser;
            new MainWindow().Show();
            this.Close();
            
        }

        private User checkMe(string text, string password)
        {
            try
            {
                text = text.TrimEnd();
                string connetionstring = @"Server=localhost;Database=ch;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connetionstring))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM ch.usersdetails WHERE USERID='" + text + "' AND USERPASSWORD='" + password + "'", con);
                    cmd.CommandType = CommandType.Text;

                    MySqlDataReader dr = cmd.ExecuteReader();

                    User myUser = new User();
                    while (dr.Read()) 
                    {
                        string check = dr["USERID"].ToString();
                        if (String.Equals(check, text, StringComparison.Ordinal)) 
                        {
                            myUser.UserName = text;
                            myUser.Password = password;
                            myUser.Role = dr["USERROLEID"].ToString();
                        }

                    }

                    if (myUser != null && myUser.UserName != string.Empty)
                    {
                        return myUser;
                    }
                    else 
                    {
                        //retrutnung null caused an error because we lacked return
                        return null;
                    }
                    
                }
            }
            catch (Exception)
            {
                //retrutnung null caused an error because we lacked return
                return null;
            }
        }
    }
}
