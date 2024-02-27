namespace TimeTrackerConsoleApp
{
    /// <summary>
    /// Provides utitlity to user controller
    /// </summary>
    public class UserService
    {
        private List<User> _users;
        private int _userId = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="users">list of users</param>
        public UserService(List<User> users)
        {
            this._users = users;
        }

        /// <summary>
        /// Gets user details
        /// </summary>
        /// <returns>Object of user</returns>
        public User GetUserDetails()
        {
            string name = this.GetNameOfTheUser();
            string userName = this.GetNewUsername();
            string password = this.GetNewPassword();
            int id = this.GenerateUserId();

            return new User(id, name, password, userName);
        }

        /// <summary>
        /// Search the user
        /// </summary>
        /// <param name="userName">username to find</param>
        /// <returns>object containing user name</returns>
        public User SearchUserWithUserName(string userName)
        {
            return this._users.Find(u => u.UserName == userName)!;
        }

        /// <summary>
        /// Gets user name
        /// </summary>
        /// <returns>string user name</returns>
        public string GetUsername()
        {
            string userName;
            while (UserInpuValidator.IsStringValid(userName = UserViews.GetStringFromUser("Enter Username")))
            {
                UserViews.PrintMessage("Enter Valid Username");
            }

            return userName;
        }

        private int GenerateUserId()
        {
            this._userId++;
            return this._userId;
        }

        /// <summary>
        /// Gets password from the user
        /// </summary>
        /// <returns>String of password</returns>
        /// <exception cref="Exception">If password dosen't match</exception>
        private string GetNewPassword()
        {
            string passwordFirstAttempt = UserViews.GetStringFromUser("Enter password");
            while (passwordFirstAttempt != UserViews.GetStringFromUser("Again Enter Password"))
            {
                UserViews.PrintMessage("Passwords Doesn't Match");
            }

            return passwordFirstAttempt;
        }

        private string GetNameOfTheUser()
        {
            string name;
            while (UserInpuValidator.IsStringValid(name = UserViews.GetStringFromUser("Enter Name")))
            {
                UserViews.PrintMessage("Enter Valid Name");
            }

            return name;
        }

        private string GetNewUsername()
        {
            string newUserName = this.GetUsername();

            while (this._users.Any(p => p.UserName == newUserName))
            {
                UserViews.PrintMessage("Enter Unique User Name");
                newUserName = this.GetUsername();
            }

            return newUserName;
        }
    }
}