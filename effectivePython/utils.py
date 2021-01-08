'''Python doesn't have static type checking. There's nothing in the compiler
that will ensure that your program will work when you run it. With Python
you don't know whether the functions your program calls will be defined at
runtime, even when their existence is evident in the source code.
This dynamic behavior is a blessing and a curse.

The large numbers of Python programmers out there say it's worth it
because of the productivity gained from the resulting brevity and
simplicity. But most people have heard at least one horror story about
Python in which a program encountered a boneheaded error at runtime.

One of the worst examples I've heard is when a SyntaxError raised in production
as a side effect of a dynamic import. The programmer I know who was
hit by this surprising occurrence has since ruled out using Python ever again.

But I have to wonder, why wasn't the code tested before the program was deployed
to production? Type safety isn't everything. You should always test your
code, regardless of what language it's written in. However, I'll admit that
the big difference between Python and many other languages is that the only
way to have any cofidence in a Python program is by writing tests. There
is no veil of static type checking to make you feel safe. 

Luckily, the same dynamic features that prevent static type checking in Python
also make it exremely easy to write tests for your code. You can use
Python's dynamic nature and easily overridable behaviors to implement
tests and ensure that your programs work as expected.

You should think of tests as an insurance policy on your code. Good tests
give you confidence that your code is correct. If you refactor or expand
your code, tests make it easy to identify how behaviors have changed.
It sounds coutner-intuitive, but having good tests actually makes it 
easier to modify Python code, not harder.

The simplest way to write tests is to use the unittest built-in module.
For example, say you have the following utility function defined in utils.py

'''


def to_str(data):
    if isinstance(data, str):
        return data
    elif isinstance(data, bytes):
        return data.decode('utf-8')
    else:
        raise TypeError('Must supply str or bytes,'
                        'found: %r' % data)
                        
