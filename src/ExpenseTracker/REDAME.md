# Expense Tracker Console Application

## Features
- User friendly Console Interface
- Adding Incomes and Expense with Date, category and notes
- Tracking one's total income and expenditure
- Creating a financial summary with Current Balance
- Editing and Delete Inocme as well as expenditure

## Classes 

- This project works in the basis of the object oriented programming which enables to easy debugging and adding functionalities
- We use three classes for this not a derived classes of one class. rather for each charecteristics we are createing classes

### Class - FinanceManager 
- This is the class which holds the fields and constructors of common of those two classes
- this class only contains filds and constructors

### Class - Income Tracker
- This Class contains the list of objects that is created in the instantce of the Class FinanceManager
- This List will store objects income which contains the Income entities. Like Category,Date and Notes
#### Methods

This class has seperate methods like 

- AddIncome - Adding income entities
- EditIncome - Editing the past income
- DeleteIncome - deleting past incomes
- GenerateIncomeRecord - Adding all Incomes

 ### Class - Expense Tracker
- This Class contains the list of objects that is created in the instantce of the Class FinanceManager
- This List will store objects income which contains the Expense entities. Like Category,Date and Notes

#### Methods
This class has seperate methods like 

- AddIncome - Adding Expense entities
- EditIncome - Editing the past expenses
- DeleteIncome - deleting past expenses
- GenerateIncomeRecord - Adding all Expense

### Financial Summary
- Generates the financial summary by Adding Incomes and Subtracting Expenditures
