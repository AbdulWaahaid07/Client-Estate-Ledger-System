using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CH03
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    /// 


    public partial class Dashboard : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


        string connetionstring = @"Server=localhost;Database=ch;Uid=root;Pwd=1234;";
        int ID = 0;

        ObservableCollection<ListContent> _myList;
        public ObservableCollection<ListContent> myList 
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

        bool pleaseUpdate;
        //================

        //Ok, every control (window, usercontrol, page...) has the samw way to receive input from other controls.
        //1.decalre it
        //2. put it in the brackets
        //3.reference it
        //U have to do this exact same thing wherever you try and send through data
        //===================
        User loggedUser;

        public Dashboard(User loggedUser)
        {
            InitializeComponent();
            isItEnabled = false;
            isitReadOnly = true;
            this.loggedUser = loggedUser;
            pleaseUpdate = true;
            DataContext = this;
            if (loggedUser.Role == "ADMIN") 
            {
                isItEnabled = true;
            }
            string imgavatar = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString()}\\Images\\avatar1.jpg";
            HeavyMethod();


            //returnList();

        }



        private void Maximize(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Minmize(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }



        private void Add_New_Member_Click(object sender, RoutedEventArgs e)
        {

            clear();
            Add_New_Member.Visibility = Visibility.Collapsed;
            btnupdate.Content = "Save";
            fadrs.Visibility = Visibility.Collapsed;
            mem7.Visibility = Visibility.Collapsed;
            //adimg.Visibility = Visibility.Visible;

        }
       
        void clear()
        {
            memno.Text = memnm.Text = fsn.Text = ai.Text = altid.Text = mno.Text = cmts.Text = bg.Text = gndr.Text = ocp.Text = dob.Text = unm.Text = pno.Text = eadrs.Text = fadrs.Text = nomnm.Text = nomr.Text = sh.Text = sd.Text = nsh.Text = cps.Text = totc.Text = bnklc.Text = la1.Text = la2.Text = la3.Text = la4.Text = rft.Text = totco2.Text = atbpd.Text = ap.Text = dr.Text = "";
            unid.IsChecked = alotl.IsChecked = unl.IsChecked = socid.IsChecked = false;
            

        }

        private void HeavyMethod()
        {
            try
            {
                ObservableCollection<ListContent> list = new ObservableCollection<ListContent>();

                using (MySqlConnection con = new MySqlConnection(connetionstring))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("ViewAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    { 
                        ListContent x = new ListContent();
                            
                        var isitOK = dr.GetOrdinal("Mem_Name");
                        x.Content = "";
                        if (!dr.IsDBNull(isitOK))
                        {
                            x.Content = dr.GetString("Mem_Name");
                        }
                         
                        isitOK = dr.GetOrdinal("Photo_path");
                        x.ImageSource = "";
                        if (!dr.IsDBNull(isitOK))
                        {
                            x.ImageSource = dr.GetString("Photo_path");
                        }

                        isitOK = dr.GetOrdinal("Mem_no");
                        x.Memid = "";
                        if (!dr.IsDBNull(isitOK)) 
                        {
                            x.Memid = dr.GetString("Mem_no");
                        }

                        x.MyID = dr.GetInt32("Mem_no");
                        list.Add(x);
                    }
                }
                myList = list;
            }
            catch (Exception ex)
            {
                string why = ex.Message;
                return;
            }
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            
                using (MySqlConnection con = new MySqlConnection(connetionstring))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("Dashboard", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // MSLNS
                   
                    fadrs.Visibility = Visibility.Visible;


                    //IMAGE

                    cmd.Parameters.AddWithValue("_Photo_path", $@"E:\new databse project\chitrapuri\images\{memno.Text}.jpg");
                   // adimg.Visibility = Visibility.Collapsed;


                //FIRST CARRD

                    cmd.Parameters.AddWithValue("_ID", ID);
                    cmd.Parameters.AddWithValue("_Mem_no", memno.Text.Trim());
                    cmd.Parameters.AddWithValue("_Mem_Name", memnm.Text.Trim());
                    cmd.Parameters.AddWithValue("_Father_Name", fsn.Text.Trim());
                    cmd.Parameters.AddWithValue("_AllotmentLetter", altid.Text.Trim());
                    cmd.Parameters.AddWithValue("_A_income", ai);
                    cmd.Parameters.AddWithValue("_Gender", gndr.Text.Trim());
                    cmd.Parameters.AddWithValue("_Mem_Design", ocp.Text.Trim());
                    cmd.Parameters.AddWithValue("_Date_of_Birth", dob.Text.Trim());
                    cmd.Parameters.AddWithValue("_bloodgroup", bg.Text.Trim());
                    cmd.Parameters.AddWithValue("_Union_name", unm.Text.Trim());


                // SECOND CARD 


                    if (unid.IsChecked == true)
                    {

                    cmd.Parameters.AddWithValue("_UnionIDCard", "YES");

                    }
                    else 
                    {

                    cmd.Parameters.AddWithValue("_UnionIDCard", "NO");

                    }
                    


                   
                    if (unl.IsChecked == true)
                    {

                    cmd.Parameters.AddWithValue("_UnionLetter", "YES");

                    }
                    else 
                    {

                    cmd.Parameters.AddWithValue("_UnionLetter", "NO");

                    }
                    


                   
                    if (socid.IsChecked == true)
                    {

                    cmd.Parameters.AddWithValue("_AllotmentLetter", "YES");

                    }
                    else 
                    {

                    cmd.Parameters.AddWithValue("_AllotmentLetter", "NO");

                    }
                    


                   
                    if (alotl.IsChecked == true)
                    {

                    cmd.Parameters.AddWithValue("_SocietyID", "YES");

                    }
                    else 
                    {

                    cmd.Parameters.AddWithValue("_SocietyID", "NO");

                    }
                    


                   
                    







                // THIRD CARD 



                    cmd.Parameters.AddWithValue("_Email_id", eadrs.Text.Trim());
                    cmd.Parameters.AddWithValue("_Ph_No", pno.Text.Trim());
                    cmd.Parameters.AddWithValue("_Mobile_No", mno.Text.Trim());




                    cmd.ExecuteNonQuery();
                    MessageBox.Show("success");
                    clear();
                    btnupdate.Content = "Update";
                    Add_New_Member.Visibility = Visibility.Visible;
                    con.Close();
                   /*

                // FIFTH CARD 
                // SIXTH CARD 


                    cmd.Parameters.AddWithValue("_Local_Address1", la1.Text.Trim());
                    cmd.Parameters.AddWithValue("_Local_Address2", la2.Text.Trim());
                    cmd.Parameters.AddWithValue("_Local_Address3", la3.Text.Trim());
                    cmd.Parameters.AddWithValue("_Local_Address4", la4.Text.Trim());
                    cmd.Parameters.AddWithValue("_N_Name", nomnm.Text.Trim());
                    cmd.Parameters.AddWithValue("_N_Relation", nomr.Text.Trim());
                    cmd.Parameters.AddWithValue("_Portfolio", .Text.Trim());
                    cmd.Parameters.AddWithValue("_Comments", .Text.Trim());
                    cmd.Parameters.AddWithValue("_Share_date", sd);
                    cmd.Parameters.AddWithValue("_No_shares", nsh);
                    cmd.Parameters.AddWithValue("_Share_cost", cps.Text.Trim());
                    cmd.Parameters.AddWithValue("_Site_house", sh.Text.Trim());
                    cmd.Parameters.AddWithValue("_AllotmentNo", AID.Text.Trim());
                    
                    cmd.Parameters.AddWithValue("_UnionLetter", unl.Text.Trim());
                    cmd.Parameters.AddWithValue("_SocietyID", socid.Text.Trim());
                    cmd.Parameters.AddWithValue("_BankLoan", bnklc.Text.Trim());






                    cmd.Parameters.AddWithValue("_date_of_exp", .Text.Trim());
                    cmd.Parameters.AddWithValue("_exp_status", .Text.Trim());


                    //cmd.Parameters.AddWithValue("_Receipt_no", .Text.Trim());
                    //cmd.Parameters.AddWithValue("_Date_of_pay", .Text.Trim());
                    //cmd.Parameters.AddWithValue("_Amount_pay", .Text.Trim());
                    //cmd.Parameters.AddWithValue("_Mode_of_pay", .Text.Trim());
                    //cmd.Parameters.AddWithValue("_Cheque_no", .Text.Trim());
                    //cmd.Parameters.AddWithValue("_Bank_name", .Text.Trim());

                    /*cmd.Parameters.AddWithValue("_Booking_status", .Text.Trim());
                    cmd.Parameters.AddWithValue("_Mem_status", .Text.Trim());

                    //cmd.Parameters.AddWithValue("_Address_blocking", .Text.Trim());
                    //cmd.Parameters.AddWithValue("_GB_Status", .Text.Trim());
                    cmd.Parameters.AddWithValue("_Flat_type", rft.Text.Trim());
                    //cmd.Parameters.AddWithValue("_ChennaiList", .Text.Trim());
                    //cmd.Parameters.AddWithValue("_Election", .Text.Trim());
                    //cmd.Parameters.AddWithValue("_Refund_Status", .Text.Trim());
                    //cmd.Parameters.AddWithValue("_Community", .Text.Trim());
                    */


                }
            
        }

        private void memno_KeyDown(object sender, KeyEventArgs e)
        {

            if (Keyboard.IsKeyDown(Key.Enter)) 
            {
                if (!checkRecord(int.Parse(memno.Text.Trim()))) 
                {
                    MessageBox.Show("error");
                }
               
            }

                
 
        }




        private bool checkRecord(int recordID) 
        {
            try
            {
                cleanMeUp();
                using (MySqlConnection con = new MySqlConnection(connetionstring))
                {
                    con.Open();
                    if (memno.Text != "")
                    {


                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM ch.mi WHERE Mem_no =" + recordID, con);
                        MySqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {

                            //PHOTO
                            string isMyPhotoOk = dr["Photo_path"].ToString();
                            if (isMyPhotoOk != string.Empty && isMyPhotoOk != null) 
                            {
                                if (File.Exists(isMyPhotoOk))
                                {
                                    mimg.Source = new BitmapImage(new Uri(dr["Photo_path"].ToString()));
                                }
                                
                            }
                                                          
                            // FIRST CARD 
                            memnm.Text = dr["Mem_Name"].ToString();
                            fsn.Text = dr["Father_Name"].ToString();
                            altid.Text = dr["AllotmentNo"].ToString();
                            ai.Text = dr["A_income"].ToString();
                            gndr.Text = dr["Gender"].ToString();
                            ocp.Text = dr["Mem_Design"].ToString();
                            bg.Text = dr["BloodGroup"].ToString();
                            unm.Text = dr["Union_name"].ToString();


                            var isitOK = dr.GetOrdinal("Date_of_Birth");
                            if (dr.IsDBNull(isitOK))
                            {
                                dob.SelectedDate = null;
                            }
                            else
                            {

                                string resultwith4 = dr["Date_of_Birth"].ToString();

                                string[] date = resultwith4.Split('/');
                                int year = Convert.ToInt32(date[2]);
                                int month = Convert.ToInt32(date[1]);
                                int day = Convert.ToInt32(date[0]);
                                dob.SelectedDate = new DateTime(year, month, day, 0, 0, 0);
                               
                            }
                            


                            //SECOND CARD 

                            

                            string tp = dr["UnionIDCard"].ToString();
                             if (tp == "YES")
                             {
                                 unid.IsChecked = true;
                                 
                             }
                             else { unid.IsChecked = false;  }


                            string tp2 = dr["UnionLetter"].ToString();
                            if (tp2 == "YES")
                            {
                                unl.IsChecked = true;
                            }

                            else { unl.IsChecked = false; }


                            string tp3 = dr["AllotmentLetter"].ToString();
                             if (tp3 == "YES")
                             {
                                alotl.IsChecked = true;
                                
                            }
                             else { alotl.IsChecked = false;  }


                            string tp4 = dr["SocietyID"].ToString();
                            if (tp4 == "YES")
                            {
                                socid.IsChecked = true;
                                
                            }
                            else { socid.IsChecked = false;  }





                            // THIRD CARD 

                            mno.Text = dr["Mobile_No"].ToString();
                            pno.Text = dr["Ph_No"].ToString();
                            eadrs.Text = dr["Email_id"].ToString();
                            fadrs.Text = dr["Local_Address1"].ToString()+ " " +
                                         dr["Local_Address2"].ToString()+ " " +
                                         dr["Local_Address3"].ToString()+ " " +
                                         dr["Local_Address4"].ToString();

                            




                            // FOURTH CARD 

                            nomnm.Text = dr["N_Name"].ToString();
                            nomr.Text = dr["N_Relation"].ToString();
                            sh.Text = dr["Site_house"].ToString();
                            sd.Text = dr["Share_date"].ToString();
                            nsh.Text = dr["No_shares"].ToString();
                            cps.Text = dr["Share_cost"].ToString();
                            //totc.Text = dr[""].ToString(); 
                            bnklc.Text = dr["BankLoan"].ToString();
                            la1.Text = dr["Local_Address1"].ToString();
                            la2.Text = dr["Local_Address2"].ToString();
                            la3.Text = dr["Local_Address3"].ToString();
                            la4.Text = dr["Local_Address4"].ToString();



                            // FIFTH CARD 
                            try
                            {
                                exp1.Text = dr["Comments"].ToString();
                            }
                            catch (Exception)
                            {
                                exp1.Text = dr["Comments"].ToString();
                            }
                            
                            cmts.Text = dr["Portfolio"].ToString();


                          

                        }
                        else
                        {
                           
                            clear();
                            MessageBox.Show("Data Not Available");

                        }

                        con.Close();
                    }

                    memno.Focus();


                }
                return true;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
        }



        //private void FillDataGrid()

        //{

        //    string ConString = ConfigurationManager.ConnectionStrings["connetionstring"].ConnectionString;

        //    string CmdString = string.Empty;

        //    using (MySqlConnection con = new MySqlConnection(connetionstring))

        //    {

        //        CmdString = "SELECT Mem_no, Receipt_no, Receipt_date, Mode_pay, Amount_pay, Bank_name FROM ShareCapitalDetails WHERE Mem_no =" + memno.Text;

        //        MySqlCommand cmd = new MySqlCommand(CmdString, con);

        //        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

        //        DataTable dt = new DataTable("ShareCapitalDetails");

        //        sda.Fill(dt);

        //        dtm.ItemsSource = dt.DefaultView;

        //    }

        //}



        private void cleanMeUp()
        {
            try
            {
                mimg.Source = null;

                // FIRST CARD 
                memnm.Text = fsn.Text = altid.Text = ai.Text = gndr.Text = ocp.Text = bg.Text = unm.Text = "";
                dob.SelectedDate = null;


                //SECOND CARD 

                altid.Text = "";
                unid.IsChecked = unl.IsChecked = alotl.IsChecked = socid.IsChecked = false;


                // THIRD CARD 

                mno.Text = pno.Text = eadrs.Text = "";
                // FULL ADDRESS LEFT 




                // FOURTH CARD 

                nomnm.Text = nomr.Text =  sh.Text =  sd.Text =  nsh.Text = cps.Text = totc.Text =bnklc.Text = la1.Text =  la2.Text =  la3.Text = la4.Text = "";

                // FIFTH CARD 

                exp1.Text = cmts.Text = "";
            }
            catch (Exception)
            {

            }
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you Sure Your Want To Delete This Record ?", "Delete Member", MessageBoxButton.YesNo) == MessageBoxResult.Yes)

            {
                using (MySqlConnection con = new MySqlConnection(connetionstring))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("DeleteByID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_Mem_no", memno.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("success Deleted the Member");
                    clear();
                }
            }

            
        }


        private void nxt_Click(object sender, RoutedEventArgs e)
        {
            if (memno.Text != "")
            {
                int val = int.Parse(memno.Text);
                memno.Text = (val + 1).ToString();
                checkRecord(int.Parse(memno.Text.Trim()));
            }
            else
            {
                memno.Text = "1" ;
                checkRecord(int.Parse(memno.Text.Trim()));
            }

            lst.ScrollIntoView(lst.Items[(int.Parse(memno.Text.Trim()) - 1)]);
            lst.SelectedIndex = int.Parse(memno.Text.Trim()) - 1;
        }




        private void prv_Click(object sender, RoutedEventArgs e)
        {
            if (memno.Text != "" && memno.Text != "1")
            {
                int val = int.Parse(memno.Text);
                memno.Text = (val - 1).ToString();
                checkRecord(int.Parse(memno.Text.Trim()));
                lst.ScrollIntoView(lst.Items[(int.Parse(memno.Text.Trim()) - 1)]);
                lst.SelectedIndex = int.Parse(memno.Text.Trim()) - 1;
            }
            else
            {
                MessageBox.Show("OOPS!! you have Reahced the End!");
                clear();
            }


        }




        private void listItem_Click(object sender, MouseButtonEventArgs e)
        {
            int id = 0;
            if (sender is TextBlock) 
            {
                TextBlock t = (TextBlock)sender;
                id = Convert.ToInt32(t.Tag);
            }
            else if (sender is Image)
            {
                Image t = (Image)sender;
                id = Convert.ToInt32(t.Tag);
            }
            else if (sender is StackPanel)
            {
                StackPanel t = (StackPanel)sender;
                id = Convert.ToInt32(t.Tag);
            }

            memno.Text = (id).ToString();
            checkRecord(int.Parse(memno.Text.Trim()));
        }

        protected void SelectCurrentItemSearch(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void search(object sender, RoutedEventArgs e)
        {

        }

        private void btnupdate_Click(object sender, MouseButtonEventArgs e)
        {
            if (loggedUser.Role == "ADMIN") { isitReadOnly = false; }
        }

        private void mid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                int val = int.Parse(memno.Text);
                memno.Text = (val + 1).ToString();
                checkRecord(int.Parse(memno.Text.Trim()));
            }

            else if (e.Delta < 0)
            {
                int val = int.Parse(memno.Text);
                memno.Text = (val - 1).ToString();
                checkRecord(int.Parse(memno.Text.Trim()));
                lst.ScrollIntoView(lst.Items[(int.Parse(memno.Text.Trim()) - 1)]);
                lst.SelectedIndex = int.Parse(memno.Text.Trim()) - 1;
            }
        }






        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    using (MySqlConnection con = new MySqlConnection(connetionstring))
        //    {
        //        con.Open();
        //        MySqlCommand cmd = new MySqlCommand("SearchValue", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new MySqlParameter("_SearchValue", "%" + srch1.Text + "%"));


        //        cmd.ExecuteNonQuery();
        //        MySqlDataReader dr = cmd.ExecuteReader();

        //        System.Windows.Forms.AutoCompleteStringCollection col = new System.Windows.Forms.AutoCompleteStringCollection
        //        while (dr.Read())
        //        {

        //            col.Add(dr["Mem_Name"].ToString());
        //        }

        //        srch1.AutoCompleteCustomSource = col;
        //        con.Close();
        //    }
        //}
    }
}
