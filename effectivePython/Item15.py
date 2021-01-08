def sort_priority(values,group):
    def helper(x):
        if x in group:
            return (0,x)
        return (1,x)
    values.sort(key=helper)

numbers = [8,3,1,2,5,4,7,6]
group = {2,3,5,7}
sort_priority(numbers,group)
print(numbers)



def sort_priority2(numbers,group):
    found = False
    def helper(x):
        if x in group:
            found = True
            return (0,x)
        return (1,x)
    numbers.sort(key=helper)
    return found

found = sort_priority2(numbers,group)
print('Found:',found)
print(numbers)



''' In Python3, there is special syntax for getting data out of a 
closure. The nonlocal statement is used to indicate that scope 
traversal should happen upon assignment for a specific variable name.
The only limit is that nonlocal won't traverse up to the module-level scope
(to avoid polluting globals).

It's complementary to the global statement, which indicates that 
a variable's assignment should go directly into the module scope.

Here,I define the same function again using nonlocal:
'''
def sort_priority3(numbers,group):
    found = False
    def helper(x):
        nonlocal found
        if x in group:
            found = True
            return (0,x)
        return (1,x)
    numbers.sort(key=helper)
    return found

found = sort_priority3(numbers,group)
print('Found:',found)
print(numbers)

'''

- Closure functions can refer to variables from any of the scopes
in which they were defined.

- By default, closures can't affect enclosing scopes by assigning
variables.

- In Python 3, use the nonlocal statement to indicate when a closure
can modify a variable in its enclosing scopes.

- In Python 2, use a mutable value(like a single-item list) to work around
the lack of the nonlocal statement.

- Avoid using nonlocal statements for anything beyond simple functions

'''

def testA():
    found = '1'
    def testAA():
        found = '11'
        def testAAA():
            nonlocal found
            found ='111'
            print('in testAAA %s'%(found))
        testAAA()
        print('in testAA %s' %(found))
    testAA()
    print('in testA %s' %(found))

testA()