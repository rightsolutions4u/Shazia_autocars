using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Facebook;
//using GenericDating.BusinessRules.Security;
using System.Web.Mvc;
namespace GenericDating.BusinessRules.Interfaces
{
    public interface IFacebookService
    {
        void DeleteUserFacebookLink(int applicationUserId);
        //ApplicationUser GetByFacebookId(IUserService userService, Int64 id);
        //ApplicationUser GetByFacebookId(IUserService userService, Int64 id, bool checkArchive);
    
        //FacebookClient GetClient(string fbToken);
        void SaveUserFacebookLink(Int64 facebookUserId, int applicationUserId);
        bool UserFacebookLinkExists(int applicationUserId);

        JsonResult FBLogin(string UserEmail, string FBToken);


         
    }
}