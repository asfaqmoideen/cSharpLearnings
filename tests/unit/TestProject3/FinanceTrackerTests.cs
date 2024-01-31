using Assignments;

namespace ExpenseTrackerTests

{
    public class FinanceTrackerTests
    {
        [Theory]
        [InlineData("120")]
        [InlineData("12.1")]
        [InlineData("150")]

        public void ProvidedValidIncomeAmount_IsIncomeAmountDouble_ReturnsTrue(string InocmeAmount)
        {
            FinanceTracker financeTracker = new FinanceTracker();
            bool isvalid;
            double result;

            isvalid = financeTracker.IsAmountDouble(InocmeAmount, out result);

            Assert.True(isvalid);
        }

        [Theory]
        [InlineData("1Hundred")]
        [InlineData("Thousand")]
        [InlineData("Fourhundred")]
        public void ProvidedInValidIncomeAmount_IsIncomeAmountDouble_ReturnsFalse(string InocmeAmount)
        {
            FinanceTracker financeTracker = new FinanceTracker();
            bool isvalid;
            double resultAmount;

            isvalid = financeTracker.IsAmountDouble(InocmeAmount, out resultAmount);

            Assert.False(isvalid);
        }   
        [Theory]
        [InlineData("1Hundred")]
        [InlineData("Thousand")]
        [InlineData("Fourhundred")]
        public void ProvidedInValidExpenseAmount_IsExpenseAmountDouble_ReturnsFalse(string ExpenseAmount)
        {
            FinanceTracker financeTracker = new FinanceTracker();
            bool isvalid;
            double resultAmount;

            isvalid = financeTracker.IsAmountDouble(ExpenseAmount, out resultAmount);

            Assert.False(isvalid);
        }

        [Theory]
        [InlineData("120")]
        [InlineData("12.1")]
        [InlineData("150")]

        public void ProvidedValidexpenseAmount_IsExpenseAmountDouble_ReturnsTrue(string ExpenseAmount)
        {
            FinanceTracker financeTracker = new FinanceTracker();
            bool isvalid;
            double result;

            isvalid = financeTracker.IsAmountDouble(ExpenseAmount, out result);

            Assert.True(isvalid);
        }

        [Theory]
        [InlineData(12000,"salary","10-12-2002","2-12-2002")]

        public void ProvidedIncomeParamters_AddIncomeToTheList_ContainsInTheList(double Income, string IncomeSource, string CreatedAt, string updatedAt)
        {
            DateTime createdDateTime = DateTime.Parse(CreatedAt);
            DateTime UpdatedDateTime = DateTime.Parse(updatedAt);
            IncomeEntity incomeEntity = new IncomeEntity(Income, IncomeSource, createdDateTime, UpdatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();

            financeTracker.AddIncomesToTheList(incomeEntity);

            Assert.Contains(incomeEntity, financeTracker.GetIncome());
        }

        [Theory]
        [InlineData(1200, "food", "10-12-2002", "2-12-2002")]
        public void ProvidedExpenseParamters_AddExpenseToTheList_ContainsInTheList(double ExpenseAmount, string ExpenseCategory, string CreatedAt, string updatedAt)
        {
            DateTime createdDateTime = DateTime.Parse(CreatedAt);
            DateTime UpdatedDateTime = DateTime.Parse(updatedAt);
            ExpenseEntity expenseEntity = new ExpenseEntity(ExpenseAmount, ExpenseCategory, createdDateTime, UpdatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();

            financeTracker.AddExpenseToTheList(expenseEntity);

            Assert.Contains(expenseEntity, financeTracker.GetExpense());
        }
        [Theory]
        [InlineData (2200, "snacks")]
        public void AddedExpenseParametersToTheList_EditSpecifiExpenseFromTheList_ContainsInTheList(double newExpenseAmount, string newExpenseCategory)
        {
            var (expenseEntity, financeTracker) = AddExpense();

            financeTracker.EditExpenseWithReferenceObject(expenseEntity, newExpenseAmount, newExpenseCategory);

            Assert.Contains(expenseEntity, financeTracker.GetExpense());
        }

        [Theory]
        [InlineData ("food")]
        public void AddedExpenseParametersToTheList_IsExpenseCtaegoryDouble_ReturnsTrue(string newExpenseCategory)
        {
            var (expenseEntity, financeTracker) = AddExpense();

            var result = financeTracker.IsExpenseCategoryUnique (newExpenseCategory);

            Assert.False(result);
        }

        [Theory]
        [InlineData ("Juice")]
        public void AddedExpenseParametersToTheList_IsExpenseCtaegoryDouble_ReturnsFalse(string newExpenseCategory)
        {
            var (expenseEntity, financeTracker) = AddExpense();

            var result = financeTracker.IsExpenseCategoryUnique (newExpenseCategory);

            Assert.True(result);
        }

        [Theory]
        [InlineData(220000, "freelancer")]
        public void AddedIncomeParametersToTheList_EditSpecificIncomeFromTheList_ContainsInTheList(double newIncomeAmount, string newIncomeCategory)
        {
            var (incomeEntity, financeTracker) = AddIncome();

            financeTracker.EditIncomeWithReferenceObject(incomeEntity, newIncomeAmount, newIncomeCategory);

            Assert.Contains(incomeEntity, financeTracker.GetIncome());
        }

        [Theory]
        [InlineData("freelancer")]
        public void AddedIncomeParametersToTheList_IsIncomeSourceUnique_ReturnTrue(string newIncomeCategory)
        {
            var (incomeEntity, financeTracker) = AddIncome();

            var result = financeTracker.IsIncomeSourceUnique(newIncomeCategory);

            Assert.True(result);
        }

        [Theory]
        [InlineData("salary")]
        public void AddedIncomeParametersToTheList_IsIncomeSourceUnique_ReturnFalse(string newIncomeCategory)
        {
            var (incomeEntity, financeTracker) = AddIncome();

            var result = financeTracker.IsIncomeSourceUnique(newIncomeCategory);

            Assert.False(result);
        }
        public void AddedExpenseParametersToTheList_RemoveSpecifiExpenseFromTheList_NotContainsInTheList()
        {
            var (expenseEntity, financeTracker) = AddExpense();

            financeTracker.RemoveExpenseFromTheList(expenseEntity);

            Assert.DoesNotContain(expenseEntity, financeTracker.GetExpense());
        }

        [Theory]
        [InlineData("Food")]
        public void AddedExpenseParametersToTheList_SearchSpecifiExpenseFromTheList_ReturnsTheSpecificObjcet(string searchCategory)
        {
            var (expenseEntity, financeTracker) = AddExpense();

            var searchResult = financeTracker.SearchExpenseFromTheList(searchCategory);

            Assert.Equal(searchResult, expenseEntity);
        }
        
        public void AddedIncomeParametersToTheList_RemoveSpecifiIncomeFromTheList_NotContainsInTheList()
        {
            var (incomeEntity, financeTracker) = AddIncome();

            financeTracker.RemoveIncomeFromTheList(incomeEntity);

            Assert.DoesNotContain(incomeEntity, financeTracker.GetIncome());
        }

 
        [Theory]
        [InlineData("Salary")]
        public void AddedIncomeParametersToTheList_SearchSpecifiIncomeFromTheList_ReturnsTheSpecificObjcet(string searchCategory)
        {
            var (incomeEntity, financeTracker) = AddIncome();

            var searchResult = financeTracker.SearchIncomeFromTheList(searchCategory);

            Assert.Equal(searchResult, incomeEntity);
        }

        public (IncomeEntity, FinanceTracker) AddIncome()
        {
            DateTime createdDateTime = DateTime.Parse("10 - 12 - 2002");
            DateTime UpdatedDateTime = DateTime.Parse("2-12-2002");
            IncomeEntity incomeEntity = new IncomeEntity(12000, "Salary", createdDateTime, UpdatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();
            financeTracker.AddIncomesToTheList(incomeEntity);
            return (incomeEntity, financeTracker);
        }
        public (ExpenseEntity, FinanceTracker) AddExpense()
        {
            DateTime createdDateTime = DateTime.Parse("10-12-2002");
            DateTime UpdatedDateTime = DateTime.Parse("2-12-2002");
            ExpenseEntity expenseEntity = new ExpenseEntity(1200, "Food", createdDateTime, UpdatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();
            financeTracker.AddExpenseToTheList(expenseEntity);
            return (expenseEntity, financeTracker);
        }

    }
}