def normalize(numbers):
    total = sum(numbers)
    result = []
    for value in numbers:
        percent = 100 * value / total
        result.append(percent)
    return result

visits = [15,35,80]

percentages = normalize(visits)
print(percentages)


def normalize_copy(numbers):
    numbers = list(numebrs) # Copy the iterator
    total = sum(numbers)
    result = []
    for value in numbers:
        percent = 100 * value / total
        result.append(percent)
    return result

''' The iterator protocol is how Python for loops and related
expressions traverse the contents of a container type. When Python
sees a statement like for x in foo it will actually call iter(foo).
The iter built-in function calls the foo. __iter__ special method in turn.
The __iter__ method must return an iterator object (which itself implements the
__next__ special method). Then the for loop repeatedly calls the next
built-in function on the iterator object until it's exhausted(and
raises a StopIteration exception) It sounds complicated,but practically
speaking you can achieve all of this behavior for your classes by implementing 
the __iter__ method as a generator. Here, I define an iterable container
class that reads the files containing tourism data:
'''

class ReadVisits(object):
    def __init__(self,data_path):
        self.data_path = data_path
    def __iter__(self):
        with open(self.data_path) as f:
            for line in f:
                yield int(line)

'''

Beware of functions that iterate over input arguments multiple times.
If these  arguments are iterators, you may see strange behavior and missing
values.

- Python's iterator protocol defines how containers and iterators
interact with the iter and next built-in functions, for loops ,and
related expressions.

- You can easily define your own iterable container type by implementing
the __iter__ method as a generator

-- You can detect that a value is an iterator if calling iter on it twice
produce the same result,which can then be progressed with the next built-infucntion
'''