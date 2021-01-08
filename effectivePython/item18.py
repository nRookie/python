'''

Item 18: Reduce Visual Noise with Variable positional Arguments

'''

'''

Accepting optional positional arguments (often called star args
in reference to the conventional name for the paramter,*args) can make
a function call more clear and remove noise.

For example, say you want to log some debug information. With a fixed number
of arguments, you would need a function that takes a message and a list
of values.

'''

def log(message,values):
    if not values:
        print(message)
    else:
        values_str = ','.join(str(x) for x in values)
        print('%s: %s' % (message,values_str))
    
log('My numbers are',[1,2])
log('Hi there',[])


def log1(message,*values):
    if not values:
        print(message)
    else:
        values_str = ','.join(str(x) for x in values)
        print('%s:%s' % (message,values_str))

log1('My numbers are', 1 , 2 )
log1('Hi there')

''' There are two problems with accepting a variable number of positional
arguments.

The first issue is that the variable arguments are always
turned into a tuple before they are passed to your function.

This means that if the caller of your function uses the * operator
on a generator, it will be iterated until it's exhausted. The resulting
tuple will include every value from the generator,which could consume
a lot of memory and cause your program to crash.
'''

def my_generator():
    for i in range(10):
        yield i

def my_func(*args):
    print(args)

it = my_generator()

my_func(*it)

''' Functions that accept *args are best for situations where you
know the number of inputs in the argument list will be reasonably
small.It's ideal for function calls that pass many literals or variable
names together. It's primarily for the convenience of the programmer
and the readability of the code.

The second issue with *args is that you can't add new positional arguments
to your function in the future without migrating every caller.
If you try to add a positional argument in the front of the argument
list, existing callers will subtly break if they aren't updated.

'''

def log2 (sequence,message,*values):
    if not values:
        print('%s: %s' % (sequence, message))
    else:
        values_str = ','.join(str(x) for x in values)
        print('%s: %s: %s' % (sequence,message,values_str))

log2(1,'Favorites',7,33)      # New usage is OK
log2('Favorite numbers',7,33)


'''

Things to Remember

- Functions can accept a variable number of positional arguments
by using *args in the def statement.

- You can use the items from a sequence as the positional arguments
for a function with the * operator.

- Using the * operator with a generator may cause your program to run out
of memory and crash.

- Adding new positional parameters to functions that accept *args can
introduce hard-to-find bugs.

'''