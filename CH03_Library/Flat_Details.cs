using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH03_Library
{
    public class Flat_Details
    {
        //figure out if enum and apply
        public string FlatType { get; set; }


        public int TFC { get; set; }
        // correct the name if required
        public string CFS { get; set; }

        public int LoanAmount { get; set; }

        //should i calculate
        public int AmountPaid { get; set; }

        //figure out if to only set
        public int DueAmount { get; set; }

        public int ReceiptNumber { get; set; }

        public DateTime ReceiptDate { get; set; }

        //enum?
        public string Mode { get; set; }

        public int Amount { get; set; }

        public int DCNumber { get; set; }

        public string Particulars { get; set; }

        public string TransactionType { get; set; }

        public int Installments { get; set; }

        public string BankName { get; set; }

    }

}
