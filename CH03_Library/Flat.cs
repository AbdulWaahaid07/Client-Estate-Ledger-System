using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH03_Library
{
    public class Flat
    {
        public string Flat_type { get; set; }

        //calculated? check the og sc
        public int Total_amount { get; set; }

        public int Loan_amount { get; set; }

        public int Inst_amount { get; set; }

        public int Sqrft { get; set; }

        public int Plinth_Level { get; set; }

        public int Slab_Level { get; set; }

        public int Plastering { get; set; }

        public int Finishing_Work { get; set; }
    }
}
