# Task 5 Garbage Collector

### Implementation

- Created a Loop with high index and which creates a object for each iteration
- Each object contains list with maximum capacity. 
- first the objcet created with passing the list while calling the constructor. 
- and then it set to null, whcich enables the Garbage Collector to free up the memory alloctaed.

- Then in an Another method which Garbage Collector is explicityly called in that function. 
- Both the memory diagnostic tool, there was a difference between explicitly caling the GC and just setting it ti null. 