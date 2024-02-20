using BoilerControllerConsole;
using BoilerControllerConsoleApplication;

namespace BoilerControllerTests
{
    public class BoilerControllerTests
    {
        [Theory]
        [InlineData(false, false)]
        public void OpenStateBoilerSwitches_StartBoilerOperation_ThrowInvalidOperatioNException(bool interlockSwitch, bool lockoutReset)
        {
            BoilerSwitches boilerSwitches = new BoilerSwitches(interlockSwitch, lockoutReset);
            BoilerController boilerController = new BoilerController();

            Assert.Throws<InvalidOperationException>(() => boilerController.StartBoilerSequence());

        }
        
        [Theory]
        [InlineData(true, true)]
        public void ClosedStateBoilerSwitches_StartBoilerOperation_RunsWithoutException(bool interlockSwitch, bool lockoutReset)
        {
            BoilerSwitches boilerSwitches = new BoilerSwitches(interlockSwitch, lockoutReset);
            BoilerController boilerController = new BoilerController();

            var isExceptionThrown = Record.Exception(() => boilerController.StartBoilerSequence());

        }
    }
}