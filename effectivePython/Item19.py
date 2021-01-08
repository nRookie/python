'''
Item 19:Provide Optional Behavior with Keyword
Arguments

'''
def remainder(number,divisor):
    return number % divisor

assert remainder(20,7) == 6

'''

All positional arguments to Python functions can also be passed
by keyword, where the name of the argument is used in an assignment
within the parentheses of a function call. The keyword arguments
can be passed in any order as long as all of the required positional
arguments are specified. You can mix and match keyword and positional
arguments. These call are equivalent:
'''


''' The flexibility of keyword arguments provides three significant benefits.


The first advantage is that keyword arguments provides three significant
benefits.

The first advantage is that keyword arguments make the function call
clearer to new readers of the code. With the call remainder(20,7),
it's not evident which argument is the numebr and which is the divisor
without looking at the implementation of the remainder method. In the call
with keyword arguments, number = 20 and divisor = 7 make it immediately
obvious which parameter is being used for each purpose.

The second impact of keyword arguments is that they can have default 
values specified in the function definition. This allows a function
to provide additional capabilities when you need them but lets you accept
the default behavior most of the time. This can eliminate repetitive
code and reduce noise.


For example, say you want to compute the rate of fluid flowing into
a vat. If the vat is also on a scale, then you could use the difference
between two weight measurements at two different times to determine
the flow rate.



The third reason to use keyword arguments is that they provide a pwerful
way to extend a function's paramters while remaining backwards compatible with
existing callers. This lets you provide additional functionality without
having to migrate a lot of code, reducing the chance of introducing bugs.


''' 

''' Things to Remember

- Function arguments can be specified by position or by keyword.

- Keywords make it clear what the purpose of each argument is when 
it would be confusing with only positional arguments.

- Keyword arguments with default values make it easy to add new behaviors
to a function, especially when the function has existing callers.

- Optional keyword arguments should always be passed by keyword instead of
by position.




