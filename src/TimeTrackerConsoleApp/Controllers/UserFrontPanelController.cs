namespace TimeTrackerConsoleApp.Controllers
{
    /// <summary>
    /// Front Panel Controller
    /// </summary>
    public class UserFrontPanelController
    {
        private enum FromPanelOption
        {
            Quit,
            SignIn,
            SignUp,
        }

        /// <summary>
        /// Executes the front panel operations
        /// </summary>
        /// <returns>true if user press quit</returns>
        public bool ExecuteFrontPanel()
        {
            this.ShowFrontPanelMenu();

            int userOption = UserViews.GetOptionFromTheUser();

            FromPanelOption operationToPerform = (FromPanelOption)userOption;

            switch (operationToPerform)
            {
                case FromPanelOption.SignIn:
                    this.ShowFrontPanelMenu();
                    break;
                case FromPanelOption.SignUp:
                    this.ShowFrontPanelMenu();
                    break;
                case FromPanelOption.Quit:
                    return true;
            }

            return false;
        }

        private void ShowFrontPanelMenu()
        {
            Console.WriteLine("1." + FromPanelOption.SignIn);
            Console.WriteLine("2." + FromPanelOption.SignUp);
            Console.WriteLine("0." + FromPanelOption.Quit);
        }
    }
}
