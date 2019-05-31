using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDS_EXER.Domain.UserAccounts
{
    public class UserAccount
    {
       public Int64 UserAccountID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MiddleName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }

        public UserAccount()
        {
            UserAccountID = 0;
            FirstName = "";
            LastName = "";
            MiddleName = "";
            UserName = "";
            Password = "";
        }

       public String EmployeeName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
