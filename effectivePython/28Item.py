''' Item 28: Inherit from collections.abc for Custom Container Types

Much of programming in Python is defining classes that contain data
and describing how such objects relate to each other. Every Python
class is a container of some kind, encapsulating attributes and functionality
together. Python also provides built-in container types for managing
data:lists,tuples,sets,and dictionaries.

When you're designing classes for simple use cases like sequences,
it's natural that you'd want to subclass Python's built-in list type
directly. For example, say you want to create your own custom list
type that has additional methods for counting the frequency of its
members.

'''

class FrequencyList(list):
    def __init__(self, members):
        super().__init__(members)

    def frequency(self):
        counts = {}
        for item in self:
            counts.setdefault(item, 0)
            counts[item] += 1
            print("count[items] %s %d" %(item,counts[item]))
        return counts

'''
By subclassing list, you get all of list's standard functionality
and preserve the semantics familiar to all Python programmers.
Your additional methods can add any custom behaviors you need.

'''

foo = FrequencyList(['a','b','a','c','b','a','d'])
print('Length is',len(foo))
foo.pop()
print('After pop:',repr(foo))
print('Frequency:',foo.frequency())


''' Now, imagine you want to provide an object that feels
like a list, allowing indexing, but isn't a list subclass.
For example, say you want to provide sequence semantics (like list or
tuple) for a binary tree class.

'''

class BinaryNode(object):
    def __init__(self, value, left = None, right = None):
        self.value = value
        self.left = left
        self.right = right

'''
How do you make this act like a sequence type ? Python
implements its container behaviors with instance methods that 
have special names. When you access a sequence item by index:

bar = [1, 2, 3]
bar [0]

it will be interpreted as:

bar.__getitem__(0)

To make the BinaryNode class act like a sequence, you can provide
a custom implementation of __getitem__ that traverses the object
tree depth first.

'''

class IndexableNode(BinaryNode):
    def _search(self, count, index):
        #...
        return (0, 0)
    def __getitem__(self, index):
        found, _ = self._search(0, index)
        if not found:
            raise IndexError('Index out of range')
        return found.value
'''
You can construct your binary tree as usual.
'''

tree = IndexableNode(
    10,
    left=IndexableNode(
        5,
        left=IndexableNode(2),
        right=IndexableNode(
            6, right=IndexableNode(7))),
    right=IndexableNode(
        15, left=IndexableNode(11)))
print('LRR =', tree.left.right.right.value)
print('Index 0 =', tree[0])
print('Index 1 =', tree[1])
print('11 in the tree?', 11 in tree)
print('Tree is',list(tree))