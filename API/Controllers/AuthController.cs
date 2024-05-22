using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Text.Json;
using User.Model;

namespace API.Controllers
{
    public class AuthController : MainController
    {

        [HttpGet]
        public IActionResult LoginAD()
        {
            try
            {
                //var isLogin = ValidateUser(loginRequest.Username, loginRequest.Password);

                return Ok(GetADUsers());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<ADUser> GetADUsers()
        {

            var myDomainUsers = new List<ADUser>();

            using (var ctx = new PrincipalContext(ContextType.Domain, "192.168.0.3"))
            {

                var userPrinciple = new UserPrincipal(ctx);

                using (var search = new PrincipalSearcher(userPrinciple))
                {
                    foreach (UserPrincipal domainUser in search.FindAll())
                    {
                        var adUser = new ADUser()
                        {
                            Description = domainUser.Description,
                            DisplayName = domainUser.DisplayName,
                            DistinguishedName = domainUser.DistinguishedName,
                            EmailAddress = domainUser.EmailAddress,
                            Name = domainUser.Name,
                            EmployeeId = domainUser.EmployeeId,
                            GivenName = domainUser.GivenName,
                            MiddleName = domainUser.MiddleName,
                            Surname = domainUser.Surname,
                            SamAccountName = domainUser.SamAccountName
                        };
                        myDomainUsers.Add(adUser);
                    } //foreach
                } //using
            } //using

            return myDomainUsers;

        } //GetADGroups


        public static bool ValidateUser(string username, string password)
        {
            Dictionary<string, object> properties = [];
            string _path = "LDAP://192.168.0.3";
            string _filterAttribute;

            DirectoryEntry entry = new DirectoryEntry(_path, username, password);

            try
            {
                //Bind to the native AdsObject to force authentication.
                object Nativeobj = entry.NativeObject;

                if (Nativeobj != null)
                {
                    DirectorySearcher search = new(entry);
                    search.Filter = "(SAMAccountName=" + username + ")";
                    search.PropertiesToLoad.Add("cn");
                    search.PropertiesToLoad.Add("givenName");
                    search.PropertiesToLoad.Add("sn");

                    var result = search.FindOne();

                    if (result == null) return false;
                    else
                    {
                        if (result.Properties["sn"].Count != 0) properties.Add("FirstName", result.Properties["sn"][0]);
                        if (result.Properties["givenName"].Count != 0) properties.Add("LastName", result.Properties["givenName"][0]);
                    }

                    _path = result.Path;
                    _filterAttribute = (string)result.Properties["cn"][0];

                    Console.WriteLine(JsonSerializer.Serialize(result));
                    Console.WriteLine(JsonSerializer.Serialize(properties));

                }
                else return false;

            }
            catch (Exception ex)
            {
                throw new Exception("err:" + ex.Message);
            }

            return true;
        }
    }
}
