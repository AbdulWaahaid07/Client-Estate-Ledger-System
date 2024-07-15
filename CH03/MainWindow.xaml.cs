using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User loggedUser;
        //Ok, every control (window, usercontrol, page...) has the samw way to receive input from other controls.
        //1.decalre it
        //2. put it in the brackets (THIS)
        //3.reference it
        //U have to do this exact same thing wherever you try and send through data
        //===================
        public MainWindow()
        {          
            InitializeComponent();
            // comment out these two rows then you pass on directly
            loggedUser = Declarations.LoggedUser;
            if (loggedUser == null) { loggedUser = new User(); }
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //RenderPages.Children.Clear();
            //RenderPages.Children.Add(new Dashboard());

            UserControl usc = null;

            usc = new Dashboard(loggedUser);
            usc.Tag = "Memeber";
            RenderPages.Children.Add(usc);

            CH03.ShareDetailsX usc1 = new CH03.ShareDetailsX();
            usc1.Tag = "ShareCapital";
            RenderPages.Children.Add(usc1);

            CH03.FlatX usc2 = new CH03.FlatX(loggedUser);
            usc2.Tag = "Flat";
            RenderPages.Children.Add(usc2);

            CH03.FDG usc3 = new CH03.FDG();
            usc3.Tag = "Reports";
            RenderPages.Children.Add(usc3);

            ShowUserContro("Memeber");


        }

        /// <summary>
        /// This funtions displays the selected user control that corrosponds to the listview item 
        /// </summary>
        /// <param name="v"></param>

        private void ShowUserContro(string v)
        {
            foreach (UIElement item in RenderPages.Children)
            {
                if (item is UserControl) 
                {
                    UserControl x = (UserControl)item;
                    if (x.Tag != null) 
                    {
                        if (x.Tag.ToString().ToUpper() == v.ToUpper())
                        {
                            x.Visibility = Visibility.Visible;
                        }
                        else 
                        {
                            x.Visibility = Visibility.Collapsed;
                        }
                    }
                }
            }
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowUserContro((((ListViewItem)((ListView)sender).SelectedItem).Name));

            //switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            //{
            //    case "Memeber":
            //        //usc = new Dashboard();
            //        //RenderPages.Children.Add(usc);
            //        break;
            //    case "ShareCapital":
            //        //CH03.ShareDetailsX usc1 = new CH03.ShareDetailsX();
            //        //RenderPages.Children.Add(usc1);
            //        break;
            //    case "Flat":
            //        CH03.FlatX usc2 = new CH03.FlatX();
            //        RenderPages.Children.Add(usc2);
            //        break;

            //    default:
            //        break;
            //}
        }

      

        
    }
}
