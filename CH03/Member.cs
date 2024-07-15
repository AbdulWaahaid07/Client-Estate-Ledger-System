using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH03
{
    public class Member : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        string memno, memName, father_Name;

        public string Memno
        {
            get
            {
                return memno;
            }

            set
            {
                memno = value;
                NotifyPropertyChanged("Memno");
            }
        }
        public string MemName
        {
            get
            {
                return memName;
            }

            set
            {
                memName = value;
                NotifyPropertyChanged("MemName");
            }
        }
        public string Father_Name
        {
            get
            {
                return father_Name;
            }

            set
            {
                father_Name = value;
                NotifyPropertyChanged("Father_Name");
            }
        }
    }
}
