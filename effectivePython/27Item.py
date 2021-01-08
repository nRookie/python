'''Prefer Public Attributes Over Private Ones.
'''
class MyObject(object):
    def __init__(self):
        self.public_field = 5
        self.__private_field = 10

    def get_private_field(self):
        return self.__private_field


''' Public attributes can be accessed by anyone using the dot
operator on the object.

'''
foo = MyObject()
assert foo.public_field == 5
print(foo.get_private_field())
assert foo.get_private_field() == 10

''' Class methods also have access to private attributes because
they are declared within the surrounding class block'''

class MyOtherObject(object):
    def __init__(self):
        self.__private_field = 71

    @classmethod
    def get_private_field_of_instance(cls, instance):
        return instance.__private_field 

bar = MyOtherObject()
assert MyOtherObject.get_private_field_of_instance(bar) == 71


class MyParentObject(object):
    def __init__(self):
        self.__private_field = 71

class MyChildObject(MyParentObject):
    def get_private_field(self):
        return self.__private_field

baz = MyChildObject()
print(baz._MyParentObject__private_field)  

print(baz.__dict__)





''' This is the wrong approach. Inevitably someone,including you,
will want to subclass your class to add new behavior or to work
around deficiencies in existing methods (like above, how MyClass.get_value
always returns a string). By choosing private attributes, you're
only making subclass overrides and extensions cumbersome and brittle.
Your potential subclassers will still access the private fields when
they absolutely need to do so.

'''


'''
But if the class hierarchy changes beneath you, these classes will
break because the private references are no longer valid. Here,
the MyIntegerSubclass class's immediate parent, MyClass,has had
another parent class added called MyBaseClass:
'''
 

class MyBaseClass(object):
    def __init__(self, value):
        self.__value = value
    
class MyClass(MyBaseClass):
    pass
    
    def get_value(self):
        return str(self.__value)

class MyIntegerSubclass(MyClass):
    def get_value(self):
        return int(self._MyBaseClass__value)

foo = MyIntegerSubclass(5)
assert foo.get_value()

''' In general, it's better to err on the side of allowing subclasses
to do more by using protected attributes. Document each protected field
and explain which are internal APIs available to subclasses and which
should be left alone entirely. This is as much advice to other programmers
as it is guidance for your future self on how to extend your own code safely.

'''

class MyClass(object):
    def __init__(self,value):
        # This stores the user-supplied value for the object.
        # It should be coercible to a string. Once assigned for
        # the object it should be treated as immutable.
        self._value = value

'''
The only time to seriously consider using private attributes
is when you're worried about naming conflicts with subclasses.
This problem occurs when a child class unwittingly defines an
attribute that was already defined by its parent class.
'''

class ApiClass(object):
    def __init__(self):
        self._value = 5
    def get(self):
        return self._value

class Child(ApiClass):
    def __init__(self):
        super().__init__()
        self._value = 'hello'  # Conflicts

a = Child()
print(a.get(), 'and', a._value, 'should be different')


''' This is primarily a concern with classes that are part of
a public API; the subclasses are out of your control, so you can't
refactor to fix the problem. Such a conflict is especially possible
with attribute names that are very common(like value).To reduce the 
risk of this happening, you can use a private attribute in the parent
class to ensure that there are no attribute names that overlap with child
classes.
'''

class ApiClass(object):
    def __init__(self):
        self.__value = 5
    def get(self):
        return self.__value

class Child(ApiClass):
    def __init__(self):
        super().__init__()
        self._value = 'hello' # OK!

a = Child()
print(a.get(), 'and', a._value, 'are different')



''' Things to Remember

- Private attributes aren't rigorously enforced by the Python compiler.

- Plan from the beginning to allow subclasses to do more with your
internal APIs and attributes instead of locking them out by default.

- Use documentation of protected fields to guide subclasses instead of
trying to force access control with private attributes.

- Only consider using private attributes to avoid naming conflicts with 
subclasses that are out of our control.
'''
