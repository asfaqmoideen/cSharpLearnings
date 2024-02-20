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

        [Theory]
        [InlineData("1")]
        [InlineData("4")]
        [InlineData("6")]
        public void validUserInput_IsUserInputValid_ReturnsTrue(string inputValue)
        {
            Assert.True(ConsoleInputValidator.IsOptionValid(inputValue, out int output));

        }
        
        [Theory]
        [InlineData("two")]
        [InlineData("x")]
        public void InvalidUserInput_IsUserInputValid_ReturnsFalse(string inputValue)
        {
            Assert.Throws<Exception>(()=> ConsoleInputValidator.IsOptionValid(inputValue,out int output));

        }
    }
}