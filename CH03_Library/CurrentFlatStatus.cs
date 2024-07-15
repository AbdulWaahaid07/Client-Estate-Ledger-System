using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH03_Library
{
    public class CurrentFlatStatus
    {
        public string Flat_type { get; set; }

        public int Block_No { get; set; }

        public string BlockCurrentStatus { get; set; }

        public string BlockCode { get; set; }

        //calculated?
        public string PercentageToBePaid { get; set; }
    }
}
