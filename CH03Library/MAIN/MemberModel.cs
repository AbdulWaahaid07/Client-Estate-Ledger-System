using CH03Library.TOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH03Library.MAIN
{
    public class MemberModel
    {
        public int Member_id { get; set; }

        public string Member_Name { get; set; }

        public string Member_FName { get; set; }

        public char Member_Gender { get; set; }

        public DateTime Member_DOB { get; set; }

        // TODO - figure this photo path out 

        public string Member_Occupation { get; set; }

        public string Member_Portfolio { get; set; }

        public string Member_Comments { get; set; }

        public int Annual_Income { get; set; }

        public string Blood_Group { get; set; }


        /////////////////////////////////////////////////////////////////////////////

        // TODO - correct the datatypes

        public byte Community { get; set; }

        // TODO - fill in the remaing properties in DB as well as FE

        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<AllotmentModel> RAllotmentID { get; set; } = new List<AllotmentModel>();

        public List<UnionModel> RUnionID { get; set; } = new List<UnionModel>();

        public List<CommunityModel> RCommunityID { get; set; } = new List<CommunityModel>();

        


    }
}
