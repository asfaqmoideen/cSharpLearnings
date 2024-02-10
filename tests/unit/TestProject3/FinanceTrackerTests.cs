using Assignments;

namespace ExpenseTrackerTests

{
    public class FinanceTrackerTests
    {
        [Theory]
        [InlineData("120")]
        [InlineData("12.1")]
        [InlineData("150")]
        public void ValidInputAmount_IsProvidedAmountDouble_ReturnsTrue(string InocmeAmount)
        {
            FinanceTracker financeTracker = new FinanceTracker();

            bool isvalidDouble = financeTracker.IsAmountDouble(InocmeAmount, out double resultAmountConvertedToDouble);

            Assert.True(isvalidDouble);
        }

        [Theory]
        [InlineData("1Hundred")]
        [InlineData("Thousand")]
        [InlineData("Fourhundred")]
        public void InValidInputAmount_IsProvidedAmountDouble_ReturnsFalse(string InocmeAmount)
        {
            FinanceTracker financeTracker = new FinanceTracker();

            bool isvalidDouble = financeTracker.IsAmountDouble(InocmeAmount, out double resultAmountConvertedToDouble);

            Assert.False(isvalidDouble);
        }

        [Theory]
        [InlineData(12000, "Freelancing", "10-12-2002", "2-12-2002")]
        [InlineData(25000, "Sales", "10-12-2002", "2-12-2002")]
        [InlineData(40000, "salary", "10-12-2002", "2-12-2002")]

        public void ValidIncomeParamters_AddIncomeToTheList_IncomesSuccessfullyAdded(double incomeAmount, string incomeSource, string CreatedAt, string updatedAt)
        {
            DateTime createdDateTime = DateTime.Now;
            DateTime UpdatedDateTime = DateTime.Parse(updatedAt);
            IncomeEntity incomeEntity = new IncomeEntity(incomeAmount, incomeSource, createdDateTime, UpdatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();
            List<IncomeEntity> incomes = financeTracker.GetIncome();

            financeTracker.AddIncomesToTheList(incomeEntity);

            Assert.Contains(incomeEntity, incomes);
        }

        [Theory]
        [InlineData(1200, "food", "10-12-2002", "2-12-2002")]
        [InlineData(400, "Transport", "10-12-2002", "2-12-2002")]
        [InlineData(900, "Gadgets", "10-12-2002", "2-12-2002")]
        public void ValidExpenseParamters_AddExpenseToTheList_ExpenseSuccesfullyAdded(double expenseAmount, string expenseCategory, string CreatedAt, string updatedAt)
        {
            DateTime createdDateTime = DateTime.Now;
            DateTime UpdatedDateTime = DateTime.Parse(updatedAt);
            ExpenseEntity expenseEntity = new ExpenseEntity(expenseAmount, expenseCategory, createdDateTime, UpdatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();
            List<ExpenseEntity> expenses = financeTracker.GetExpense();

            financeTracker.AddExpenseToTheList(expenseEntity);

            Assert.Contains(expenseEntity, expenses);
        }
        [Fact]
        public void ValidExpenseParametersToTheList_EditSpecifiExpenseFromTheList_ExpenseSuccesfullyEdited()
        {
            ExpenseEntity expenseEntity = AddExpense(out FinanceTracker financeTracker);
            double newExpenseAmount = 200;
            string newExpenseCategory = "food";

            financeTracker.EditExpenseWithReferenceObject(expenseEntity, newExpenseAmount, newExpenseCategory);
            List<ExpenseEntity> expenses = financeTracker.GetExpense();

            Assert.Contains(expenseEntity, expenses);
        }

        [Fact]
        public void AddedExpenseParametersToTheList_IsExpenseCtaegoryUnique_ReturnsTrue()
        {
            ExpenseEntity expenseEntity = AddExpense(out FinanceTracker financeTracker);
            string newExpenseCategory = "food";

            bool result = financeTracker.IsExpenseCategoryUnique(newExpenseCategory);

            Assert.False(result);
        }

        [Fact]
        public void AddedExpenseParametersToTheList_IsExpenseCtaegoryUnique_ReturnsFalse()
        {
            ExpenseEntity expenseEntity = AddExpense(out FinanceTracker financeTracker);
            string newExpenseCategory = "juice";

            bool result = financeTracker.IsExpenseCategoryUnique(newExpenseCategory);

            Assert.True(result);
        }

        [Fact]
        public void AddedIncomeParametersToTheList_EditSpecificIncomeFromTheList_IncomeSuccesfullyEdited()
        {
            IncomeEntity incomeEntity = AddIncome(out FinanceTracker financeTracker);
            double newIncomeAmount = 200000;
            string newIncomeCategory = "freelancer";


            financeTracker.EditIncomeWithReferenceObject(incomeEntity, newIncomeAmount, newIncomeCategory);
            List<IncomeEntity> incomes = financeTracker.GetIncome();

            Assert.Contains(incomeEntity, incomes);
        }

        [Fact]
        public void AddedIncomeParametersToTheList_IsIncomeSourceUnique_ReturnTrue()
        {
            IncomeEntity incomeEntity = AddIncome(out FinanceTracker financeTracker);
            string newIncomeCategory = "freelancer";

            bool result = financeTracker.IsIncomeSourceUnique(newIncomeCategory);

            Assert.True(result);
        }

        [Fact]
        public void AddedIncomeParametersToTheList_IsIncomeSourceUnique_ReturnFalse()
        {
            IncomeEntity incomeEntity = AddIncome(out FinanceTracker financeTracker);
            string newIncomeCategory = "salary";

            bool result = financeTracker.IsIncomeSourceUnique(newIncomeCategory);

            Assert.False(result);
        }

        [Fact]
        public void AddedExpenseParametersToTheList_RemoveSpecifiExpenseFromTheList_ExpensesSuccesfullyRemoved()
        {
            ExpenseEntity expenseEntity = AddExpense(out FinanceTracker financeTracker);

            financeTracker.RemoveExpenseFromTheList(expenseEntity);
            List<ExpenseEntity> expenses = financeTracker.GetExpense();

            Assert.DoesNotContain(expenseEntity, expenses);
        }

        [Fact]
        public void AddedExpenseParametersToTheList_SearchSpecifiExpenseFromTheList_ReturnsTheSpecificObjcet()
        {
            ExpenseEntity expenseEntity = AddExpense(out FinanceTracker financeTracker);
            string searchCategory = "Food";

            ExpenseEntity searchResult = financeTracker.SearchExpenseFromTheList(searchCategory);

            Assert.Equal(searchResult, expenseEntity);
        }

        [Fact]
        public void AddedIncomeParametersToTheList_RemoveSpecifiIncomeFromTheList_IncomeSuccessfullyRemoved()
        {
            IncomeEntity incomeEntity = AddIncome(out FinanceTracker financeTracker);

            financeTracker.RemoveIncomeFromTheList(incomeEntity);
            List<IncomeEntity> incomes = financeTracker.GetIncome();

            Assert.DoesNotContain(incomeEntity, incomes);
        }

 
        [Theory]
        [InlineData("Salary")]
        public void AddedIncomeParametersToTheList_SearchSpecifiIncomeFromTheList_ReturnsTheSpecificObjcet(string searchCategory)
        {
            IncomeEntity incomeEntity = AddIncome(out FinanceTracker financeTracker);

            IncomeEntity searchResult = financeTracker.SearchIncomeFromTheList(searchCategory);

            Assert.Equal(searchResult, incomeEntity);
        }

        public IncomeEntity AddIncome(out FinanceTracker financeTrackerOut)
        {
            DateTime createdDateTime = DateTime.Now;
            DateTime updatedDateTime = DateTime.Parse("2-12-2002");
            IncomeEntity incomeEntity = new IncomeEntity(12000, "Salary", createdDateTime, updatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();
            financeTracker.AddIncomesToTheList(incomeEntity);
            financeTrackerOut = financeTracker;
            return incomeEntity;
        }
        public ExpenseEntity AddExpense(out FinanceTracker financeTrackerOut)
        {
            DateTime createdDateTime = DateTime.Now;
            DateTime updatedDateTime = DateTime.Parse("2-12-2002");
            ExpenseEntity expenseEntity = new ExpenseEntity(1200, "Food", createdDateTime, updatedDateTime);
            FinanceTracker financeTracker = new FinanceTracker();
            financeTracker.AddExpenseToTheList(expenseEntity);
            financeTrackerOut = financeTracker;
            return expenseEntity;
        }

    }
}