'''
Item 37: Use Threads for Blocking I/O , Avoid for Parallelism

The standard implementation of Python is called CPython. CPython
runs a Python program in two steps. First, it parses and
complies the source text into bytecode. Then, it runs the 
bytecode using a stack-based interpreter. The bytecode interpreter 
has state that must be maintained and coherent while the Python
program executes. Python enforces coherence with a mechanism called
the global interpreter lock (GIL).

Essentially, the GIL is a mutual-exclusion lock(mutex) that prevents
CPython from being affected by preemptive multithreading,where
one thread takes control of a program by interrupting another thread.
thread. Such an interruption could corrupt the interpreter state
if it comes at an unexpected time. The GIL prevents these interruptions
and ensures that every bytecode instruction works correctly with the CPython
implementation and its C-extension modules.

The GIL has an important negative side effect. With programs
written in languages like C++ or Java, having multiple threads
of execution means your program could utilize multiple CPU cores at the same
time. Although Python supports multiple threads of execution,
the GIL causes only one of them to make forward progress at a time.
This means that when you reach for threads to do parallel computation
and speed up your Python programs, you will be sorely disappointed.

For example, say you want to do something computationally intensive with Python.
I'll use a naive number factorization algorithm as a proxy.

'''
from time import time
def factorize(number):
    for i in range(1, number + 1):
        if number % i == 0:
            yield i 

''' Factoring a set of numbers in serial takes quite a long time'''

numbers = [42139079, 1214759, 1516637, 1852285]
start = time()

for number in numbers:
    list(factorize(number))

end = time()
print('Took %.3f seconds ' % (end - start))


'''
Using multiple threads to do this computation would make
sense in other languages because you could take advantage
of all of the CPU cores of your computer. Let me try that in
Python. Here, I define a Python thread for doing the same computation
as before:

'''

from threading import Thread

class FactorizeThread(Thread):
    def __init__(self, number):
        super().__init__()
        self.number = number
    
    def run(self):
        self.factors = list(factorize(self.number))

'''
Then, I start a thread for factorizing each number in parallel.

'''

start1 = time()
threads = []
for number in numbers:
    thread = FactorizeThread(number)
    thread.start()
    threads.append(thread)


for thread in threads:
    thread.join()
end1 = time()
print('Took %.3f seconds ' % (end1 - start1))



''' 
What's surprising is that this takes even longer than
running factorize in serial. With one thread per number,
you may expect less than a 4x speedup in other languages due to 
the overhead of creating threads and coordinating with them.
You may expect only a 2X speedup on the dual-core machine I 
used to run this code. But you would never expect the performance of
these threads to be worse when you have multiple CPUs to utilize.
This demonstrates the effect of the GIL on programs running
in the standard CPython interpreter.

There are ways to get CPython to utilize multiple cores, but it
doesn't work with the standard Thread class (see Item 41:"Consider
concurrent.futures for True Parallelism) and it can require
substantial effort. Knowing these limitations you may wonder,
why does Python support threads at all ? There are two good
reasons.

First, multiple threads make it easy for your program to seem
like it's doing multiple things at the same time. Managing
the juggling act of simultaneous tasks is difficult to implement
yourself(see Item 40: Consider coroutines to run many functions
concurrently for an example). With threads, you can leave it to Python
to run your functions seemingly in parallel. This works
because CPython ensures a level of fairness between Python
threads of execution, even though only one of them makes forward
progress at a time due to the GIL.

The second reason Python supports threads is to deal with blocking
I/O, which happens when Python does certain types of system calls.
System calls are how your Python program asks your computer's operating
system to interact with the external environment on your behalf.
Blocking I/O includes things like reading and writing files, interacting
with networks, communicating with devices like displays, etc.Threads
help you handle blocking I/O by insulating your program from the time
it takes for the operating system to respond to your request.


For example, say you want to send a signal to a remote-controlled
helicopter through a serial port. I'll use a slow system call (select)
as a proxy for this activity. This function asks the operating system
to block for 0.1 second and then return control to my program,
similar to what would happen when using a synchronous serial port.
'''

import select

def slow_systemcall():
    select.select([], [], [], 0.1)

'''
running this system call in serial requires a linearly increasing amount
of time

'''

start = time()
for _ in range(5):
    slow_systemcall()
end = time()
print('Took %.3f seconds ' % (end - start))

''' Python threads can't run bytecode in parallel on multiple
CPU cores because of the global interpreter lock(GIL).

- Python threads are still useful despite the GIL because they
provide an easy way to do multiple thigns at seemingly the same time.

- Use Python threads to make multiple system calls in parallel. This
allows you to do blocking I/O at the same time as computation.