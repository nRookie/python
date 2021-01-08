''' One of the simplest application of metaclasses
is verifying that a class was defined correctly. When you're building
a complex class hierarchy, you may want to enforce style,
require overriding methods, or have strict relationships between
class attributes, Metaclasses enable these use cases by providing
a reliable way to run your validation code each time a new 
subclass is defined.
Often a class's validation code runs in the init method,
when an object of class's type is constructed().Using metaclasses
for validation can raise errors much earlier.

Before I get into how to define a metaclass for validating
subclasses, it's important to understand the metaclass
action for standard objects. A metaclass is defined by inheriting
from type. In the default case, a metaclass receives the contents
of associated class statements in its __new__ method. Here,
you can modify the class information before the type is actually
constructed:

'''
class Meta(type):
    def __new__(meta, name, bases, class_dict):
        print((meta, name, bases, class_dict))
        return type.__new__(meta, name, bases, class_dict)

class MyClass(object, metaclass=Meta):
    stuff = 123

    def foo(self):
        pass

''' You can add functionality to the Meta.__new__ method in order
to validate all of the parameters of a class before it's defined.
For example, say you want to represent any type of multisided polygon
.You can do this by defining a special validating metaclass and using
it in the base class of your polygon class hierarchy. Note that it's
important not to apply the same validation to the base class.

'''

class ValidatePolygon(type):
    def __new__(meta, name, bases, class_dict):
        if bases != (object, ):
            if class_dict['sides'] < 3:
                raise ValueError('Polygons need 3+ sides')
        return type.__new__(meta, name, bases, class_dict)

class Polygon(object, metaclass= ValidatePolygon):
    sides = None

    @classmethod
    def interior_angles(cls):
        return (cls.sides - 2) * 180

class Triangle(Polygon):
    sides = 3

'''
If you try to define a polygon with fewer than three sides, the
validation will cause the class statement to fail immediately after\
the class statement body, This means your program will not 
even be able to start running when you define such a class.
'''
print('Before class')
class Line(Polygon):
    print('Before sides')
    sides = 1
    print('After sides')
print('After class')

'''

Things to Remember 

    Use metaclasses to ensure that subclasses are well formed
    at the time they are defined, before objects of their type
    are constructed.

    metaclasses have slightly different syntax in Python2 vs.
    Python3.

    The __new__ method of metaclasses is run after the class
    statement's entire body has been processed.

'''


