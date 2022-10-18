using System.Collections;

namespace ISDP_AlexanderK.entity
{
    public class User
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string LocationID { get; set; }
        public string RoleID { get; set; }
        public ArrayList Permissions { get; set; }

        public User()
        {
        }

        public User(string userID, string firstName, string lastName, string email, string locationID, string roleID, ArrayList permissions)
        {
            UserID = userID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            LocationID = locationID;
            RoleID = roleID;
            Permissions = permissions;
        }
    }
}