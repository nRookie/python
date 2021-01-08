''' A mix-in is a small class that only defines
a set of additional methods that a class should provide.
Mix-in classes don't define their own instance attributes
nor require their __init__ constructor to be called.

Writing mix-ins is easy because Python makes it trivial
to inspect the current state of any object regardless of its
type. Dynamic inspection lets you write generic functionality
a single time, in a mix-in, that can be applied to many other
classes. Mix-ins can be composed and layered to minimize
repetitive code and maximize reuse.

For example, say you want the ability to convert a Python
object from its in-memory representation to a dictionary that's
ready for serialization. Why not write this functionality
generically so you can use it with all of your classes?

Here, I define an example mix-in that accomplishes this wtih
a new public method that's added to any class that inherits
from it:
'''
import json

class ToDictMixin(object):
    def to_dict(self):
        return self._traverse_dict(self.__dict__)

    def _traverse_dict(self, instance_dict):
        output = {}
        for key, value in instance_dict.items():
            output[key] = self._traverse(key, value)
        return output
        
    def _traverse(self, key, value):
        if isinstance(value, ToDictMixin):
            return value.to_dict()
        elif isinstance(value, dict):
            return self._traverse_dict(value)
        elif isinstance(value, list):
            return [self._traverse(key,i) for i in value]
        elif hasattr(value, '__dict__'):
            return self._traverse_dict(value.__dict__)
        else:
            return value
            


'''
The implementation details are straightforward and rely on dynamic
attribute access using hasattr,dynamic type inspection with
isinstance,and accesssing the instance dictionary __dict__.
'''


'''

Here, I define an example class that uses the mix-in to make a 
dictionary representation of a binary tree:

'''

class BinaryTree(ToDictMixin):
    def __init__(self, value, left = None, right=None):
        self.value = value
        self.left  = left
        self.right = right

'''
Translating a large number of related Python objects
into a dictionary becomes easy.
'''

tree = BinaryTree(10,
    left=BinaryTree(7,right=BinaryTree(9)),
    right=BinaryTree(13,left=BinaryTree(11)))
print(tree.to_dict())


''' The best part about mix-ins is that you can make
their generic functionality pluggable so behaviors can be 
overriden when required. For example, here I define a 
subclass of BinaryTree that holds a reference to its parent.
This circular reference would cause the default implementation
of ToDictMixin.to_dict to loop forever.
'''

class BinaryTreeWithParent(BinaryTree):
    def __init__(self, value, left= None,
                right=None, parent=None):
        super().__init__(value, left=left, right=right)
        self.parent = parent
    def _traverse(self, key, value):
        if (isinstance(value, BinaryTreeWithParent) and
                key == 'parent'):
            return value.value # Prevent cycles
        else:
            return super()._traverse(key, value)

'''
The solution is to override the ToDictMixin._traverse method
in the BinaryTreeWithParent class to only process values
that matter, preventing cycles encountered by the mix-in.
Here, I override the _traverse method to not traverse
the parent and just insert its numerical value:

'''

root = BinaryTreeWithParent(10)
root.left = BinaryTreeWithParent(7, parent = root)
root.left.right = BinaryTreeWithParent(9, parent= root.left)
print(root.to_dict())

class NamedSubTree(ToDictMixin):
    def __init__(self, name, tree_with_parent):
        self.name = name
        self.tree_with_parent = tree_with_parent

my_tree = NamedSubTree('foobar', root.left.right)
print(my_tree.to_dict())    # No infinite loop

''' Mix-ins can also be composed together. For example,
say you want a mix-in that provides generic JSON serialization
for any class. You can do this by assuming that a class provides
a to_dict method (which may or may not be provided by the ToDictMixin class)
'''

class JsonMixin(object):
    @classmethod
    def from_json(cls,data):
        kwargs = json.loads(data)
        return cls(**kwargs)

    def to_json(self):
        return json.dumps(self.to_dict())


class DatacenterRack(ToDictMixin, JsonMixin):
    def __init__(self, switch=None, machines=None):
        self.switch = Switch(**switch)
        self.machines = [
            Machine(**kwargs) for kwargs in machines
        ]
''' Serializing these classes to and from JSON is simple.
Here, I verify that the data is able to be sent round-trip
through serializing and deserializing:
'''

serialized = """{
    "switch":{"ports": 5, "speed": 1e9},
    "machines": [
        {"cores":8,"ram":32e9,"disk":5e12},
        {"cores":4,"ram":16e9,"disk":1e12},
        {"cores":2,"ram":4e9,"disk":500e9}
        ]
}"""

deserialized = DatacenterRack.from_json(serialized)
roundtrip = deserialized.to_json()
assert json.loads(serialized) == json.loads(roundtrip)