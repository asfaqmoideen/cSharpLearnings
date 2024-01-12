# Inventory Management Console

## Features
- User friendly Console
- Error free Product Entry
- Stores in Memory (Run Time)
- Ale to search edit and delete with product name and IDs
- Easy to debug as uses different methods inside the class
- Menu Bar for easy access 

 ## Class

 The parent class Product is used and the Each product is created as objects in that instance. 
 Lis of objects were created to store products with its aspects. This list of objects makes easily accesbile 
 and user friendly

 ## Methods

 ### AddProduct()

 It uses List.Add() to add the objects in the list _productLit
 Only add the elements as defined, .i.e
 Name - String, ProductID - String, Price - Double or Int, Quantity - Int
 Used do while loop and try parse to have this error handling
 Each Product will have objects of the CLass Product. 
 
 ### DeleteProduct()

 The index of the object in the list _productList is acceses via a for loop which is iterated with count of list
 by the index value the element i.e object is deleted via a fuction

  Removes the particular element i.e object craeted for the product


 ### ViewProducts()

 Foreach loop is used to acces the filed of the objects which is stored in the list. which will print the all details of 
 all products in the list
 Same as delete product a for loop which returns the index of the object is retuned the specific 


****It will only executed if the list has some items in it. it will show no pruducts if the list is empty

 ## SearchProduct()

 This method is as same as we used in edit and delete products. But it just checks the entered product ID or Name is equal to the existing 
 one in the list if its same it print the details. 

 ****It will only executed if the list has some items in it. it will show no pruducts if the list is empty  