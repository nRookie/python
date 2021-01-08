import collections
names = ['Socrates','Archimedes','Plato','Aristotle']
names.sort(key=lambda x:len(x))
print(names)


def log_missing():
    print('Key added')
    return 0

current = {'green': 12, 'blue':3}
increments = [ ('red',5),('blue',17),('orange',9)]

result = collections.defaultdict(log_missing,current)
print('Before:',dict(result))
for key,amount in increments:
    result[key] += amount
print('After: ',dict(result))

Before: {'green': 12,'blue':3}

def increment_with_report(current,increments):
    added_count = 0
    def missing():
        nonlocal added_count
        added_count += 1
        return 0
    
    result = collections.defaultdict(missing,current)
    for key, amount in increments:
        result[key] += amount
    return result,added_count

result , count = increment_with_report(current,increments)
assert count == 2

class CountMissing(object):
    def __init__(self):
        self.added = 0
    def missing(self):
        self.added += 1
        return 0

''' In other languages, you might expect that now defaultdict
would have to be modified to accommodate the interface of 
CountMissing. But in Python,thanks to first-class functions,
you can reference the CountMissing. missing method directly
on an object and pass it to defaultdict as the default value
hook. It's trivial to have a method satisfy a function interface.
'''

counter = CountMissing()
result = collections.defaultdict(counter.missing,current) #Method ref

for key,amount in increments:
    result[key] += amount
assert counter.added ==2

''' Using a helper class like this to provide the behavior of
a stateful closure is clearer than the increment_with_report
function above.However,in isolation it's still not immediately
obvious what the purpose of the CountMissing class is.Who constructs
a CountMissing object? Who calls the missing method? will the class
need other public methods to be added in the future? Until you see
its usage with defaultdict, the class is a mystery.

To clarify this situation, Python allows classes to define the
__call__ special method. __call__ allows an object to be called
just like a function. It also causes the callable built-in function
to return True for such an instance.


'''

class BetterCountMissing(object):
    def __init__(self):
        self.added = 0
    def __call__(self):
        self.added +=1
        return 0


counter = BetterCountMissing()
counter()
assert callable(counter)

counter = BetterCountMissing()
result = collections.defaultdict(counter,current)
for key, amount in increments:
    result[key] += amount
assert counter.added == 2

