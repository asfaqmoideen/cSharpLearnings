using Assignments;

namespace ExpenseTrackerTests

{
    public class FinanceTrackerTests
    {
        [Theory]
        [InlineData("120")]
        [InlineData("12.1")]
        [InlineData("150")]

        public void ProvidedValidIncomeAmount_IsIncomeAmountDouble_ReturnsTrueIfDouble(string InocmeAmount)
        {
            FinanceTracker financeTracker = new FinanceTracker();

            bool isvalid;
            double result;
            isvalid = financeTracker.IsExpenseAmountDouble(InocmeAmount, out result);
            Assert.True(isvalid);
        }

        [Theory]
        [InlineData("1Hundred")]
        [InlineData("Thousand")]
        [InlineData("Fourhundred")]
        public void ProvidedInValidIncomeAmount_IsIncomeAmountDouble_ReturnsFalseIfNotDouble(string InocmeAmount)
        {
            FinanceTracker financeTracker = new FinanceTracker();
            bool isvalid;
            double resultAmount;
            isvalid = financeTracker.IsExpenseAmountDouble(InocmeAmount, out resultAmount);
            Assert.False(isvalid);
        }   
        [Theory]
        [InlineData("1Hundred")]
        [InlineData("Thousand")]
        [InlineData("Fourhundred")]
        public void ProvidedInValidExpenseAmount_IsExpenseAmountDouble_ReturnsFalseIfNotDouble(string ExpenseAmount)
        {
            FinanceTracker financeTracker = new FinanceTracker();
            bool isvalid;
            double resultAmount;
            isvalid = financeTracker.IsExpenseAmountDouble(ExpenseAmount, out resultAmount);
            Assert.False(isvalid);
        }

        [Theory]
        [InlineData("120")]
        [InlineData("12.1")]
        [InlineData("150")]

        public void ProvidedValidexpenseAmount_IsExpenseAmountDouble_ReturnsTrueIfDouble(string ExpenseAmount)
        {
            FinanceTracker financeTracker = new FinanceTracker();

            bool isvalid;
            double result;
            isvalid = financeTracker.IsExpenseAmountDouble(ExpenseAmount, out result);
            Assert.True(isvalid);
        }

        [Theory]
        [InlineData(12000,"salary","10-12-2002","20-12-2002")]

        public void ProvidedIncomeParamters_AddIncomeToTheList_ContainsInTheListIfAdded(double Income, string IncomeSource, string CreatedAt, string updatedAt)
        {
            DateTime createdDateTime = DateTime.Parse(CreatedAt);
            DateTime UpdatedDateTime = DateTime.Parse(updatedAt);
            IncomeEntity incomeEntity = new IncomeEntity(Income, IncomeSource, createdDateTime, UpdatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();
            financeTracker.AddIncomesToTheList(incomeEntity);
            Assert.Contains(incomeEntity, financeTracker.GetIncome());
        }

        [Theory]
        [InlineData(1200, "food", "10-12-2002", "20-12-2002")]
        public void ProvidedExpenseParamters_AddExpenseToTheList_ContainsInTheListIfAdded(double ExpenseAmount, string ExpenseCategory, string CreatedAt, string updatedAt)
        {
            DateTime createdDateTime = DateTime.Parse(CreatedAt);
            DateTime UpdatedDateTime = DateTime.Parse(updatedAt);
            ExpenseEntity expenseEntity = new ExpenseEntity(ExpenseAmount, ExpenseCategory, createdDateTime, UpdatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();
            financeTracker.AddExpenseToTheList(expenseEntity);
            Assert.Contains(expenseEntity, financeTracker.GetExpense());
        }
        [Theory]
        [InlineData(1200, "food", "10-12-2002", "10-12-2002", 2200, "snacks")]
        public void AddedExpenseParametersToTheList_EditSpecifiExpenseFromTheList_ContainsInTheListIfEdited(double ExpenseAmount, string ExpenseCategory, string CreatedAt, string updatedAt, double newExpenseAmount, string newExpenseCategory)
        {
            DateTime createdDateTime = DateTime.Parse(CreatedAt);
            DateTime UpdatedDateTime = DateTime.Parse(updatedAt);
            ExpenseEntity expenseEntity = new ExpenseEntity(ExpenseAmount, ExpenseCategory, createdDateTime, UpdatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();
            financeTracker.AddExpenseToTheList(expenseEntity);
            financeTracker.EditExpenseWithReferenceObject(expenseEntity, newExpenseAmount, newExpenseCategory);
            Assert.Contains(expenseEntity, financeTracker.GetExpense());
        }

        [Theory]
        [InlineData(120000, "Income", "9-12-2002", "6-12-2002", 220000, "freelancer")]
        public void AddedIncomeParametersToTheList_EditSpecificIncomeFromTheList_ContainsInTheListIfEdited(double Income, string IncomeSource, string CreatedAt, string updatedAt, double newIncomeAmount, string newIncomeCategory)
        {
            DateTime createdDateTime = DateTime.Parse(CreatedAt);
            DateTime UpdatedDateTime = DateTime.Parse(updatedAt);
            IncomeEntity incomeEntity = new IncomeEntity(Income, IncomeSource, createdDateTime, UpdatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();
            financeTracker.AddIncomesToTheList(incomeEntity);
            financeTracker.EditIncomeWithReferenceObject(incomeEntity, newIncomeAmount, newIncomeCategory);
            Assert.Contains(incomeEntity, financeTracker.GetIncome());
        }

        [Theory]
        [InlineData(1200, "food", "10-12-2002", "20-12-2002")]
        public void AddedExpenseParametersToTheList_RemoveSpecifiExpenseFromTheList_NotContainsInTheListIfDeleted(double ExpenseAmount, string ExpenseCategory, string CreatedAt, string updatedAt)
        {
            DateTime createdDateTime = DateTime.Parse(CreatedAt);
            DateTime UpdatedDateTime = DateTime.Parse(updatedAt);
            ExpenseEntity expenseEntity = new ExpenseEntity(ExpenseAmount, ExpenseCategory, createdDateTime, UpdatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();
            financeTracker.AddExpenseToTheList(expenseEntity);
            financeTracker.RemoveExpenseFromTheList(expenseEntity);
            Assert.DoesNotContain(expenseEntity, financeTracker.GetExpense());
        }
        
        [Theory]
        [InlineData(12000, "Salary", "10-12-2002", "20-12-2002")]
        public void AddedIncomeParametersToTheList_RemoveSpecifiIncomeFromTheList_NotContainsInTheListIfDeleted(double Income, string IncomeSource, string CreatedAt, string updatedAt)
        {
            DateTime createdDateTime = DateTime.Parse(CreatedAt);
            DateTime UpdatedDateTime = DateTime.Parse(updatedAt);
            IncomeEntity incomeEntity = new IncomeEntity(Income, IncomeSource, createdDateTime, UpdatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();
            financeTracker.AddIncomesToTheList(incomeEntity);
            financeTracker.RemoveIncomeFromTheList(incomeEntity);
            Assert.DoesNotContain(incomeEntity, financeTracker.GetIncome());
        }
    }
}