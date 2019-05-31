using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDS_EXER.Domain.UserAccounts;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace CRUDS_EXER.DataAccess.RepositoryManager
{
    public class UserAccountRepository
    {
        #region UserAuthentication
        public UserAccount AuthenticateUser(UserAccount obj)
        {
            UserAccount CurrentUserAccount;
            using (IDbConnection connection = ConnectionManager.FGCICRUDSConnection)
            {
                string query = @"SELECT users.ID as UserAccountID, CONCAT(users.FirstName , ' ' ,users.LastName, ' ')
                                as EmployeeName, users.UserName, users.Password
                                FROM UserAccounts users
                                WHERE users.[Username] = @UserName AND users.[Password] = @Password";
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                CurrentUserAccount = connection.Query<UserAccount>(query, obj).FirstOrDefault();

                connection.Close();
            }
            return CurrentUserAccount;       
        }
        #endregion

        public List<UserAccount> GetAll()
        {
            List<UserAccount> listOfUserAccount;
            using (IDbConnection connection = ConnectionManager.FGCICRUDSConnection)
            {
                string query = @"SELECT useracc.Id as UserAccountID, useracc.FirstName, useracc.LastName,
                                    useracc.MiddleName, useracc.Useranme FROM UserAccounts useracc";

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            return listOfUserAccount;
        }
    }
}
