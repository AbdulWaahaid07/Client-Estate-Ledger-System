using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH03
{
    public static class Declarations
    {
        private static User loggedUser;
        public static User LoggedUser
        {
            get 
            {
                return loggedUser;
            }
            set 
            {
                loggedUser = value;
            }
        }
    }
}
