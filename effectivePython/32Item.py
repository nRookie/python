'''

Python's language hooks make it easy to write generic code
for gluing system together. For example, say you want to 
represent the rows of your database as Python objects. Your database
has its schema set. Your code that uses objects correponding to
those rows must also know what your database looks like. However,
in Python, the code that connects your Python objects to the database
doesn't need to know the schema of your rows; it can be generic.

How is that possible? Plain instance attributes, @property
methods,and descriptors can't do this because they all need
to be defined in advance. Python makes this dynamic behavior
possible with the __getattr__ special method. If your class defines
__getattr__, that method is called every time an attribute can't
be found in an object's instance dictionary.
'''
class LazyDB(object):
    def __init__(self):
        self.exists = 5
    def __getattr__(self, name):
        value = 'Value for %s' %name
        setattr(self, name, value)
        return value

'''
Here, I access the missing property foo. This causes
Python to call the __getattr__ method above, which mutates
the instance dictionary __dict__:

'''

data = LazyDB()
print('Before:', data.__dict__)
print('foo:   ', data.foo)
print('After: ', data.__dict__)


'''
Here, I add logging to LazyDB to show when __getattr__ is actually
called. Note that I use super().__getattr__() to get the real property
value in order to avoid infinite recursion.

'''

class LoggingLazyDB(LazyDB):
    def __getattr__(self, name):
        print('Called __getattr__(%s)' %name)
        return super().__getattr__(name)

data = LoggingLazyDB()
print('exists:',data.exists)
print('foo:   ',data.foo)
print('foo:   ',data.foo)


'''

The enable this use case, Python has another language hook called
__getattribute__. This special method is called every time
an attribute is accessed on an object, even in cases where it
does exist in the attribute dictionary.This enables you to do 
things like check global transaction state on every property access.
HEer,I define vali 

'''

class ValidatingDB(object):
    def __init__(self):
        self.exists = 5
    
    def __getattribute__(self, name):
        print('Called __getattribute__(%s) ' % name)
        try:
            return super().__Getattribute__(name)
        except AttributeError:
            value = 'Value for %s' % name
            setattr(self, name, value)
            return value


data = ValidatingDB()
print('exists:', data.exists)
print('foo:   ', data.foo)
print('foo:   ', data.foo)


''' Python code implementing generic functionality often relies
on the hasattr built-in function to determine when properties
exist, and the getattr built-in function to retrieve 
property values. These functions also look in the instance
dictionary for an attribute name before calling __getattr__.

Click here to view code image.

data = LoggingLazyDB()
print()

'''
print('\r\n\r\r\r\r\r')
data = LoggingLazyDB()
print('Before:    ', data.__dict__)
print('foo exists:  ', hasattr(data, 'foo'))
print('After:     ', data.__dict__)
print('foo exists:  ', hasattr(data, 'foo'))



data = ValidatingDB()

print('foo exists: ', hasattr(data, 'foo'))
print('foo exists: ', hasattr(data, 'foo'))


''' Now , say you want to lazily push data back to the 
database when values are assigned to your Python object.
You can do this with __setattr__, a similar language hook 
that lets you intercept arbitrary attribute assignments.
Unlike retrieving an attribute with __getattr__ and
__getattribute__ , there's no need for two separate methods.
The __setattr__ method is always called every time an attribute
is assigned on an instance (either directly or through the setattr
built-in function).



'''

class SavingDB(object):
    def __setattr__(self, name, value):
        # Save some data to the DB log
        # ...
        super().__setattr__(name, value)

'''
Here, I define a logging subclass of SavingDB. Its __setattr__method
is always called on each attribute assignment:
'''

class LoggingSavingDB(SavingDB):
    def __setattr__(self, name, value):
        print('Called __setattr__(%s,%r)' % (name, value))
        super().__setattr__(name, value)

data = LoggingSavingDB()
print('Before:',data.__dict__)
data.foo = 5
print('After: ', data.__dict__)
data.foo = 7
print('Finally:',data.__dict__)




''' The problem is that __getattribute__ access self._data, which
causes __getattribute__ to run again, which accesss self._data
again, and so on. The solution is to use the super().__getattribute__
method on your instance to fetch values from the instance attribute
dictionary. This avoids the recursion.
'''
class Dictionary(object):
    def __init__(self, data):
        self._data = data
    
    def __getattribute__(self, name):
        data_dict = super().__getattribute__('_data')
        return data_dict[name]

''' Similarly,you'll need __setattr__ methods that modify attributes
on an object to use super().__setattr__.


'''

''' Things to Remember

Use __getattr__ and __setattr__ to lazily load and save attributes
for an object.

Understand that __getattr__ only gets called once when accessing
a missing attribute, whereas __getattribute__ gets called every time
an attribute is accessed.

- Avoid infinite recursion in __getattribute__ and __setattr__ by 
using methods from super() to access instance attributes directly.
