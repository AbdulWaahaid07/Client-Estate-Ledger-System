using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH03
{
    public class ListContent: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private string imageSource;
        private string content;
        private string memid;
        private int myID;

        

        public int MyID
        {
            get
            {
                return myID;
            }

            set
            {
                myID = value;
                NotifyPropertyChanged("MyID");
            }
        }

        public string ImageSource
        {
            get
            {
                return imageSource;
            }

            set
            {
                imageSource = value;
                NotifyPropertyChanged("ImageSource");
            }
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
                NotifyPropertyChanged("Content");
            }
        }

        public string Memid
        {
            get
            {
                return memid;
            }

            set
            {
                memid = value;
                NotifyPropertyChanged("Memid");
            }
        }
    }
}
