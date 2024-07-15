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
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CH03
{
    /// <summary>
    /// Interaction logic for FDG.xaml
    /// </summary>
    public partial class FDG : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        string connetionstring = @"Server=localhost;Database=ch;Uid=root;Pwd=1234;";

        ObservableCollection<Member> _myList;
        public ObservableCollection<Member> myList 
        {
            get 
            {
                return _myList;
            }
            set 
            {
                _myList = value;
                NotifyPropertyChanged("myList");
            }
        }

        public FDG()
        {
            this.DataContext = this;
            InitializeComponent();
            

        }





        private void pplt() 
        {

            using (MySqlConnection con = new MySqlConnection(connetionstring)) 
            {

                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM ch.mi", con);
                MySqlDataReader dr = cmd.ExecuteReader();

                myList = new ObservableCollection<Member>();
                while (dr.Read())
                {
                    Member x = new Member();
                    x.Memno = dr["mem_no"].ToString();
                    x.MemName = dr["mem_name"].ToString();
                    x.Father_Name = dr["father_name"].ToString();

                    myList.Add(x);
                }

                //DataSet dt = new DataSet();
                //da.Fill(dt);
                //dg1.ItemsSource = dt.Tables[0].DefaultView;


            }


        }

        private void dg1_Loaded(object sender, RoutedEventArgs e)
        {
            pplt();
        }
    }
}