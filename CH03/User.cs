using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH03
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        string userName;
        string password;
        string role;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
                NotifyPropertyChanged("Role");
            }
        }
    }
}
