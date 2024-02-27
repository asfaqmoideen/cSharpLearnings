
namespace TimeTrackerConsoleApp
{
    internal class TaskController
    {
        public TaskController()
        {
        }

        /// <summary>
        /// Adds a new task
        /// </summary>
        public void AddUser()
        {
            User newUser = this._userSerive.GetUserDetails();

            this._users.Add(newUser);

            // this._userLog.AddToLog(newUser);
            string userNoun = this._users.Count == 1 ? "User was" : "Users were";
            UserViews.PrintMessage($"Totally {this._users.Count()}  {userNoun}  Added");
        }

        /// <summary>
        /// Remove user from the list
        /// </summary>
        public void RemoveUser()
        {
            string userName = this._userSerive.GetUsername();

            User userToBeDeleted = this._userSerive.SearchUserWithUserName(userName);

            if (UserViews.GetConfirmation($"Remove User with {userToBeDeleted.Name} and {userToBeDeleted.Id}"))
            {
                this._users.Remove(userToBeDeleted);
                this._userLog.RemoveFromLog(userToBeDeleted);
                UserViews.PrintMessage($"User With {userToBeDeleted.Name} Removed Succesfully");
                return;
            }

            UserViews.PrintMessage("Removal Operation Cancelled");
        }

        /// <summary>
        /// Updates the user details
        /// </summary>
        public void UpdateUser()
        {
            string userName = this._userSerive.GetUsername();

            User userToBeUpdated = this._userSerive.SearchUserWithUserName(userName);

            if (UserViews.GetConfirmation($"Edit User with {userToBeUpdated.Name} and {userToBeUpdated.Id}"))
            {
                // Logic goes here
                UserViews.PrintMessage($"User With {userToBeUpdated.Name} Edited Succesfully");
                return;
            }

            UserViews.PrintMessage("User Updation Operation Cancelled");
        }
    }
}