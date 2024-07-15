using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for FlatX.xaml
    /// </summary>
    public partial class FlatX : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        bool _isItEnabled;
        public bool isItEnabled
        {
            get
            {
                return _isItEnabled;
            }
            set
            {
                _isItEnabled = value;
                NotifyPropertyChanged("isItEnabled");
            }
        }

        bool pleaseUpdate;

        bool _isitReadOnly;
        public bool isitReadOnly
        {
            get
            {
                return _isitReadOnly;
            }
            set
            {
                _isitReadOnly = value;
                NotifyPropertyChanged("isitReadOnly");
            }
        }

        User loggedUser;

        public FlatX(User loggedUser) // delte inside bracket 
        {
            // ------------------

            InitializeComponent();

            // --------------------dont delet this 

            isItEnabled = false;
            isitReadOnly = true;
            this.loggedUser = loggedUser;
            pleaseUpdate = true;
            DataContext = this;
            if (loggedUser.Role == "ADMIN")
            {
                isItEnabled = true;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void p01_Click(object sender, RoutedEventArgs e)
        {
            
             
        }
    }
}
