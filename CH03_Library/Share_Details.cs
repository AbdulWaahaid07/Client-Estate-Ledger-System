using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH03_Library
{
    public class Share_Details
    {
        public int ReciptNumber { get; set; }

        public DateTime ReciptDate { get; set; }

        //figure out to use enum
        public string Mode { get; set; }

        public int Amount { get; set; }

        public int DCNumber { get; set; }

        public string BankName { get; set; }
    }
}
