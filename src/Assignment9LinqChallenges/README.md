# Assignment 9 - LINQ Challenges

 Here Products in a inventory manager is used. Class `Product` which consists of 
 Properties like 

 - ProductName `string`
- ProductPrice  `double`
- ProductId  `unit`
- Category `string`

The `ProductManager` Class conatins the entire methods to manipulate and manage the list
The List of Objects with the instances of class product is created. 
The `Supplier` with, `SupplierName` , `SupplierId` , `ProductId` as properties

### Task 1

 Undertsnding the Basic LINQ queries for a list of objects to sort, categorise and select particular set of elements.

- Products are filtered under the category "electronics" with a price greater than 500 selected only product name and product price.
- The list of the previous sorted query is filtered with descending price order
- The Average price of the products were found.

### Task 2

Understood the operations like grouping, demonstrating and joining the to lists with common coarse.

- Grouped the products as category and found expensive product.
- Inner join was used to link the products and suppliers wwith product id

### Task 3

Understood the LINQ Queries for in-memory objects line array was

- The second largest elemst of array was found
- Found All unique pairs of numbers in the array that add up to a specified target. 

### Task 4

Optimisation pf LINQ Queries
- Categorised and optimies the Linq Query with `AsParallel` used.

### TAsk 5

Some Advanced Linq features like `Func<Product, bool>` used as parameter and returns List of filtered objects. 