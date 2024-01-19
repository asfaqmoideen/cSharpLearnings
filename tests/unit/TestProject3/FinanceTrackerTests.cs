namespace ExpenseTrackerTests

{
    public class FinanceTrackerTests
    {
        [Theory]
        [InlineData("120")]
        [InlineData("12.1")]
        [InlineData("150")]

        public void ProvidedInvalidIncomeAmount_IsIncomeAmountDouble_ReturnsTrueIfDouble()
        {

        }
    }
}