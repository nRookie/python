from collections import deque
from random import randint
from collections import OrderedDict

a = OrderedDict()
a['foo'] = 1
a['bar'] = 2
b = OrderedDict()
b['foo'] = 'red'
b['bar'] = 'blue'


for value1, value2 in zip(a.values(), b.values()):
    print(value1, value2)

# Default dictionary