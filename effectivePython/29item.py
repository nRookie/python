''' Use Plain Attributes Instead of Get and Set Methods


Programmers coming to Python from other languages may naturally
try to implement explicit getter and setter method in their classes.
'''

class OldResistor(object):
    def __init__(self, ohms):
        self._ohms = ohms

    def get_ohms(self):
        return self._ohms

    def set_ohms(self, ohms):
        self._ohms = ohms

''' Using these setters and getters is simple, but it's not pythonic.

'''

r0 = OldResistor(50e3)

print('Before: %5r' % r0.get_ohms())
r0.set_ohms(10e3)
print('After: %5r' % r0.get_ohms())



''' Such methods are especially clumsy for operations
like incrementing in place.
'''

r0.set_ohms(r0.get_ohms() + 5e3)

''' These utility methods do help define the interface for your
class, making it easier to encapsulate functionality, validate
usage, and define boundaries. Those are important goals when 
designing a class to ensure you don't break callers as your class
evolves over time.

In Python, however, you almost never need to implement explicit
setter or getter methods. Instead, you should always start your
implementations with simple public attributes.
'''

class Resistor(object):
    def __init__(self, ohms):
        self.ohms = ohms
        self.voltage = 0
        self.current = 0
    
''' These make operations like incrementing in place natural
and clear.
'''
 

'''
Later, if you decide you need special behavior when an attribute
is set, you can migrate to the @property decorator and its
corresponding setter attribute. Here, I define a new subclass
of Resistor that lets me vary the current by assigning
the voltage property. Note that in order to work properly the
name of both the setter and getter method must match the 
intended property name.
'''

class VoltageResistance(Resistor):
    def __init__(self, ohms):
        super().__init__(ohms)
        self._voltage = 0
    @property
    def voltage(self):
        return self._voltage
    
    @voltage.setter
    def voltage(self, voltage):
        self._voltage = voltage
        self.current  = self._voltage / self.ohms

''' Now, assigning the voltage property will run the voltage
setter method, updating current property of the object to match
'''
r2 = VoltageResistance(0.1)
print('Before:%5r amps' % r2.current)
r2.voltage = 10
print('After: %5r amps' % r2.current)


'''  Specifying a setter on a property also lets you 
perform type checking and validation on values passed to your
class. Here, I define a class that ensures all resistance values
are above zero ohms:

'''

class BoundedResistance(Resistor):
    def __init__(self, ohms):
        super().__init__(ohms)

    @property
    def ohms(self):
        return self._ohms
    
    @ohms.setter
    def ohms(self, ohms):
        if ohms <= 0:
            raise ValueError('%f ohms must be >0' % ohms)
        self._ohms = ohms

'''
Assigning an invalid resistance to the attribute raises an exception
'''

r3 = BoundedResistance(1e3)

'''
This happens because BoundedResistance.__init__ calls
Resistor.__init__, which assigns self.ohms = -5. That assignment
causes the @ohms.setter method from BoundedResistance to be called,
immediately running the validation code before object construction
has completed.

You can even use @property to make attributes from parent classes
immutable
'''

class FixedResistance(Resistor):
    # ...
    @property
    def ohms(self):
        return self._ohms
    @ohms.setter
    def ohms(self, ohms):
        if hasattr(self, '_ohms'):
            raise AttributeError("Can't set attribute")
        self._ohms = ohms

''' Trying to assign to the property after construction
raises an exception '''

#r4 = FixedResistance(1e3)
#r4.ohms = 2e3


''' The biggest shortcoming of @property is that the methods
for an attribute can only be shared by subclasses. Unrelated
classes can't share the same implementation. However, Python
also supports descriptors (see Item31:"Use Descriptors for Reusable
@property Methods") that enable reusable property logic and many other
use cases.

Finally, when you use @property methods to implement setters and getters,
be sure that the behavior you implement is not surprising. For example,
don't set other attributes in getter property methods.

'''

class MysteriousResisotr(Resistor):
    @property
    def ohms(self):
        self.voltage = self._ohms * self.current
        return self._ohms 


#This leads to extremely bizzare behavior

r7 = MysteriousResisotr(10)

r7.current = 0.01

print('Before: %5r' % r7.voltage)
r7.ohms
print('After: %5r' % r7.voltage)



''' The best policy is to only modify related object state
in @property.setter methods. Be sure to avoid any other
side effects the caller may not expect beyond the object,
such as importing modules dynamically, running slow helper functions,
or making expensive database queries. Users of your class
will expect its attributes to be like any other Python object:
quick and easy. Use normal methods to do anything more complex
or slow'''


''' Things to Remember

- Define new class interface using simple public attributes,
and avoid set and get methods.

- Use @property to define special behavior when attributes are 
accessed on your objects, if necessary.

- Follow the rule of least surprise and avoid weird side effects
in your @property methods.

- Ensure that @property methods are fast; do slow or complex work
using normal methods.

