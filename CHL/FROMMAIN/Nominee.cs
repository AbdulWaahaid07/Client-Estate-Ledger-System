using System;
using System.Collections.Generic;
using System.Text;

namespace CHLibrary.FROMMAIN
{
    public class Nominee
    {

        public string Nominee_name { get; set; }

        public int Nominee_age { get; set; }

        public List<N_R_Model> RNomineeRelationshipid { get; set; } = new List<N_R_Model>();
    }
}
