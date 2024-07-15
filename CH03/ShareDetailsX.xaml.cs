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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CH03
{
    /// <summary>
    /// Interaction logic for ShareDetails.xaml
    /// </summary>
    public partial class ShareDetailsX : UserControl
    {
        public ShareDetailsX()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //private void btnupdate_Click(object sender, RoutedEventArgs e)
        //{
        //    ShareDetailModel objShareDetailModel = new ShareDetailModel();
        //  frontproper = objShareDetailModel.Number_of_Share;



        //}
    }
}
