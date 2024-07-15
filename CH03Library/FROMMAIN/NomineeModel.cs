using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH03Library.FROMMAIN
{
    public class Nominee
    {
        // TODO - think about the ID

        public string Nominee_name { get; set; }

        public int Nominee_age { get; set; }

        public List<N_R_Model> RNomineeRelationshipid { get; set; } = new List<N_R_Model>();
    }

}
