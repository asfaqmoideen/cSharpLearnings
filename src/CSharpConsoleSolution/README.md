# Project Solution Build Order

### Project

Project conatins all the files required for an application or a website which are compiled in a sametime.

### Project Files

Is a XML document which contains the build order of the source code
Conatins instruction for MSBuild to build that project

### Solution 
Solution is a container for all related projects. 

### Solution File
The solution files are the compilation of projects that need to be build together. 
The depended projects should be in the same solution file.

## GreetingsApp

This is the project which have MathApp as its dependency. 
This app will build first in the order.
This app only print Greetings message and call the methods to execute the simple calculator in math app

## MathApp
Math app conatains class to execute the calculator.
It gets option form the user and calls the required funtion to execute math operation.
The Inputs are got from the DisplayApp

## DisplayApp

DisplayApp consists of class that gets input from user and validates the input using the methods in UtilityApp

## UtilityApp

UtilityApp consists of OperandValidator and OptionValidator
The Option to execute is validated and operand to calculate is also validated which is called from display app. 