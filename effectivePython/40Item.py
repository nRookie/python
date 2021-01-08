''' Python can work around all these issues with coroutines.
Coroutines let you have many seemingly simultaneous functions
in your Python programs. They're implemented as an extension
to generators (See Item 16: "Consider Generators Instead of Returning
Lists"). The cost of starting a generator coroutine is a function
call. Once active, they each use less than 1 KB of memory until
they're exhausted.

Coroutines work by enabling the code consuming a generator to send
a value back into the generator function after each yield expression.
The generator function receives the value passed to the send function as the
result of the corresponding yiled expression.
'''

def my_coroutine():
    while True:
        received = yield
        print('Received:', received)

it = my_coroutine()
next(it)
it.send('First')
it.send('Second')
it.send('Third')

''' The initial call to next is required to prepare the generator
for receiving the first send by advancing it to the first yield
expression. Together, yield and send provide generators with a 
standard way to vary their next yielded value in response to 
external input.

For example, say you want to implement a generator coroutine
that yields the minimum value it's been sent so far. Here, the 
bare yield prepares the coroutine with the initial minimum value
sent in from the outside. Then the generator repeatedly yields the new
minimum in exchange for the next value to consider.

'''

def minimize():
    current = yield
    while True:
        value = yield current
        current = min(value, current)

'''
The code consuming the generator can run one step at a time
and will output the minimum value seen after each input
'''

it = minimize()
next(it)
print(it.send(10))
print(it.send(4))
print(it.send(22))
print(it.send(-1))

''' The generator function will seemingly run forever, making forward
progress with each new call to send. Like threads, coroutines
are independent functions that can consume inputs from their
environment and produce resulting outputs. The difference is that
coroutines pause at each yield expression in the generator and
resume after each call to send from the outside. This is the magical
mechanism of coroutines.

This behavior allows the code consuming the generator to take action
after each yield expression in the coroutine. The consuming code can
use the generator's output values to call other functions and update
data structures. Most importantly , it can advance other generator
functions until their next yield expressions. By advancing many separate 
generaotrs in lockstep, they will all seem to be running simultaneously,mimicking the 
concurrent behavior of Python threads.

'''

'''

The Game of Life

Let me demonstrate the simultaneous behavior of coroutines with an example.
Say you want to use coroutines to implement Conway's Game of Life.
The rules of the games are simple. You have a two-dimensional grid
of an arbitrary size. Each cell in the grid can either be alive or empty.

ALIVE = '*'
EMPTY = '-'

The game progresses one tick of the clock at a time. At each tick,
each cell counts how many of its neighboring eight cells are still alive.
Based on its neighbor count, each cell decides if it will keep living,die,
or regenerate. Here's an example of a 5x5 Game of Life grid after
four generations with time going to the right. I'll explain the
specific rules further below.
'''
from collections import namedtuple
Query = namedtuple('Query', ('y','x'))

ALIVE = '*'
EMPTY = '-'

def count_neighbors(y, x):
    n_ = yield Query(y + 1, x + 0) # North
    ne = yield Query(y + 1, x + 1) # Northeast
    e_ = yield Query(y + 0, x + 1)
    se = yield Query(y - 1, x + 1)
    w_ = yield Query(y + 0, x - 1)
    sw = yield Query(y - 1, x - 1)
    nw = yield Query(y + 1, x - 1)
        #...
    neighbor_states = [n_, ne, e_, se, se_, sw, w_, nw]
    count = 0
    for state in neighbor_states:
        if state == ALIVE:
            count += 1
    return count

it = count_neighbors(10, 5)
q1 = next(it)
print('First yield: ', q1)
q2 = it.send(ALIVE)
print('Second yiled: ', q2)
q3 = it.send(ALIVE)
print('Third yield: ', q3)

try:
    count = it.send(EMPTY)
except StopIteration as e:
    print('Count: ', e.value)


''' Things to Remember

- Coroutines provide an efficient way to run tens of thousands
of functions seemingly at the same time.

- Within a generator, the value of the yield expression will be
whatever value was passed to the generator's send method from
the exterior code.

- Coroutines give you a powerful tool for separating the core logic
of your program from its interaction with the surrounding environment.

