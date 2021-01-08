''' Item 34: Register Class Existance with Metaclasses

Another common use of metaclasses is to automatically register types
in your program. Registeration is useful for doing reverse lookups,
where you need to map a simple identifier back to a corresponding class.

For example, say you want to implement your own serialized representation of
a Python object using JSON. You need a way to take an object and
turn it into a JSON string. Here, I do this generically by defining
a base class that records the constructor parameters and turns them
into a JSON dictionary:

'''
import json
class Serializable(object):
    def __init__(self, *args):
        self.args = args
    
    def serialize(self):
        return json.dumps({'args': self.args})

'''This class makes it easy to serialize simple, immutable data
structures like Point2D to a string.

'''

class Point2D(Serializable):
    def __init__(self, x, y):
        super().__init__(x, y)
        self.x = x
        self.y = y
    
    def __repr__(self):
        return 'Point2D(%d, %d)' % (self.x, self.y)

point = Point2D(5, 3)
print('Object:     ', point)
print('Serialized: ', point.serialize())


''' Using Deserializable makes it easy to serialize and deserialize
simple,immutable objects in a generic way.
'''