using CHLibrary.TOMAIN;
using System;
using System.Collections.Generic;
using System.Text;

namespace CHLibrary.MAIN
{
    public class MemberModel
    {
        

        public string Member_Name { get; set; }

        public string Member_FName { get; set; }

        public char Member_Gender { get; set; }

        public DateTime Member_DOB { get; set; }

       
        public string Member_Occupation { get; set; }

        public string Member_Portfolio { get; set; }

        public string Member_Comments { get; set; }

        public int Annual_Income { get; set; }

        public string Blood_Group { get; set; }

        public byte Address_Blocking { get; set; }

        public byte General_Body_Eligibility { get; set; }

        public byte Election_List { get; set; }

        public byte Chennai_List { get; set; }
        
        /////////////////////////////////////////////////////////////////////////////
        
       
        public byte Bank_Loan { get; set; }

        public byte Community { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<AllotmentModel> RAllotmentID { get; set; } = new List<AllotmentModel>();

        public List<UnionModel> RUnionID { get; set; } = new List<UnionModel>();

        public List<IdentificationModel> RIdentificationID { get; set; } = new List<IdentificationModel>();

        public List<CommunityModel> RCommunityID { get; set; } = new List<CommunityModel>();


    }
}
