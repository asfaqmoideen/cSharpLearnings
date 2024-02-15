# Reflection on Memory Management

### Memory leaks

- Memory Leaks will happen if the memory were allocated to long living short objects or short living long objects were created. 
- The long living short objects will be in Generation 0 and often the garbage cllector will do action frequently in the same thread. 
- The short living long objects will be pushed to the Generation 2 GC which will not be frequently mark or sweep. 
- Hence the memory leaks happen. 
- We should work according to the Assumptions of the GC to have optimised memory Allocation.

### Garbage Collection

- Is a  Technique performs the memory optimisation with specific algorithm
- In a short note, Freeing up the memory often when the objects are not in use. 
- it works in the generation based approach. Generation 1 , Generation 2 and Generation 0.

#### Generation 0 
- Often it will be executed in the same thread. This gen is for short objects which will live shorter.
- Because, the short lived objects memory should be freed up in the Heap

#### Generation 1
- Generation 1 is the intermediate generation which the objects classified as long lived in gen 0 is pushed to gen 1
- Before gen 2, the objects will be there in the gen 1. 

#### Generation 2 
- It will not executed often, because it is only for long lived long objects. 
- But also it reserves a specific memory for those objects. 

### Object lifetime and Object size Tradeoff

- As per the assumptions of GC that 
**Large objects are long lived** and **Short Objects are short Lived**
- We should program according to Assumptons of the GC
- But the problem starts when we make Short lived long objects and Long Lived Short Lived.
- The Sort Lived long objects are pushed to the GC gen 2 which is a short lived and GC is not executed often.
- The Long lived short objecst are stagnented in Gen 1 which requires lot of memory and making the procces of Gen 1 tidy and affecting the current thread. 

## Reflection

- We made short living large objects in the `Allocate()` as List of Large List of 1000 value Integer arrays. It is still in the Gen 1
- Makes the memory allocation large and exponentially growing. 
- In Task 2 we made a finally block which will clear the list of integer array. that is we are clearing the array which is placed in Gen 2 and mapped from gen 1 making it short lived