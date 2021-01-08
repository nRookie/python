''' Use Lock to Prevent Data Races in Threads

After learning about the global interpreter lock,
may new Python programmers assume they can forgo using mutual-
exclusion locks(mutexes) in their code altogether. If the 
GIL is already preventing Python threads from running on
multiple CPU cores in parallel, it must also act as a lock
for a program's data structures, right? Some testing on
types like lists and dictionaries may even show that this assumption
appears to hold.

But beware, this is truly not the case. The GIL will not protect
you.Although only one Python thread runs at a time, a thread's
operations on data structures can be interrupted between any two
bytecode instructions in the Python interpreter. This is dangerous
if you access the same object from multiple threads simulatenously.
The invariants of your data structures could be violated at practically
any time because of these interruptions, leaving your program in a corrupted
state.

For example, say you want to write a program that counts many things
in parallel, like sampling light levels from a whole network of
sensors. If you want to determine the total number of light samples over time,
you can aggregate them with a new class.

'''
from threading import Thread
from threading import Lock
class   Counter(object):
    def __init__(self):
        self.count = 0
    
    def increment(self, offset):
        self.count += offset

'''
Imagine that each sensor has its own worker thread because reading
from the sensor requires blocking I/O. After each sensor measurement,
the worker thread increments the counter up to a maximum number of desired
readings.
'''


def worker(sensor_index, how_many, counter):
    for _ in range(how_many):
        # Read from the sensor
        # ...
        counter.increment(1)

def run_threads(func, how_may, counter):
    threads = []
    for i in range(5):
        args = (i, how_many, counter)
        thread = Thread(target= func, args=args)
        threads.append(thread)
        thread.start()
    for thread in threads:
        thread.join()

''' Running five threads in parallel seems simple,
and the outcome should be obvious.
'''


how_many = 10**5
counter = Counter()
run_threads(worker, how_many, counter)
print('Counter should be %d, found %d' % (5 * how_many, counter.count))

'''
But this result is way off! What happend here? How could
something so simple go so wrong, especially since only one
Python interpreter thread can run at a time ?

The Python interpreter enforces fairness between all of
the threads that are executing to ensure they get a roughly
equal amount of processing time. To do this, Python will
suspend a thread as it's runnign and will resume another
thread in turn. The problem is that you don't know exactly
when Python will suspend your threads. A thread can even be
paused seemingly halfway through what looks like an atomic
operation. That's what happened in this case.

The counter object's increment method looks simple.

counter.count += offset

But the += operator used on an object attribute actually instructs
Python to do three separate operations behind the scenes. The
statement above is equivalent to this:

value = getattr(counter, 'count')
result = value + offset
setattr(counter, 'count', result)



Python threads incrementing the counter can be suspended between
any two of these operations. This is problematic if the way
the operations interleave causes old versions of value to be assigned to the 
counter. Here's an example of bad interaction between two threads,
A and B:

# Running in Thread A
value_a = getattr(counter, 'count')
# Context switch to Thread B 
value_b = getattr(counter, 'count')
result_b = getattr(counter,'count')
setattr(counter, 'count', result_b)
#Context switch back to Thread A
result_a = value_a + 1
setattr(counter, 'count', result_a)


Thread A stomped on thread B, erasing all of its progress
incrementing the counter. This is exactly what happend in the 
light sensor example above.

To prevent data races like these and other forms of data structure
corruption, Python includes a robust set of tools in the threading
built-in module. The simplest and most useful of them is the 
Lock class, a mutual-exclusion lock(mutex).

By using a lock, I can have the Counter class protect its 
current value against simultaneous access from multiple threads.
Only one thread will be able to acquire the lock at a time.
Here, I use a with statement to acquire and release the lock;
this makes it easier to see which code is executing while
the lock is held(see Item 43:"Consider contextlib and with Statements
for Reusable try/finally Behavior" for details):

'''

class LockingCounter(object):
    def __init__(self):
        self.lock = Lock()
        self.count = 0
    def increment(self, offset):
        with self.lock:
            self.count += offset

'''
Now I run the worker threads as before,but use a LockingCounter
instead.

'''

counter = LockingCounter()
run_threads(worker, how_many, counter)
print(' Counter should be %d, found %d' % (5 * how_many, counter.count))



''' Things to Remember

- Even though Python has a global interpreter lock,
you're still responsible for protecting against data races
between the threads in your programs.

- Your programs will corrupt their data structure if you
allow multiple threads to modify the same objects without locks.

- The Lock class in the threading built-in module is Python's
standard mutual exclusion lock implementaiton.

'''
