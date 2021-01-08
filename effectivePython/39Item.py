''' Item 39: Use Queue to Coordinate Work Between Threads

When the worker functions vary in speeds, an earlier phase can
prevent progress in later phases, backing up the pipeline. This 
causes later phases to starve and constantly check their input
queues for new work in a tight loop. The outcome is that worker 
threads waste CPU time doing nothing useful(they're constantly raising
and catching IndexError exceptions).

But that's just the beginning of what's wrong with this implementation.
There are three more problems that you should also avoid. First,
determining that all of the input work is complete requires yet another
busy wait on the done_queue. Second, in Worker the run method will execute
forever in its busy loop. There's no way to signal to a worker thread
that it's time to exit.

Third, and worst of all, a backup in the pipeline can cause the program
to crash arbitrarily. If the first phase makes rapid progress but the second
phase makes slow progress, then the queue connecting the first phase to the second phase
will constantly increase in size. The second phase won't be able to
keep up. Given enough time and input data, the program will eventually
run out of  memory and die.

The lesson here isn't that pipelines are bad; it's that it's hard
to build a good producer-consumer queue yourself.

Queue to the Rescue

The Queue class from the queue built-in module provides all of the
functionality you need to solve these problems.

Queue eliminates the busy waiting in the worker by making the get
method block until new data is available. For example, here I start
a thread that waits for some input data on a queue:

'''

from queue import Queue
from threading import Thread
import time
queue = Queue()

def consumer():
    print('Consumer waiting')
    queue.get()
    print('Consumer done')

thread = Thread(target=consumer)
thread.start()

'''
Even though the thread is running first, it won't finish until an item is put
on the Queue instance and the get method has something to return.
'''

print('Producer putting')
queue.put(object())
thread.join()
print('Producer done')

''' 
To solve the pipeline backup issue, the Queue class
lets you specify the maximum amount of pending work
you'll allow between two phases. This buffer size causes
calls to put to block when the queue is already full. 
For example, here I define a thread that waits for a while
before consuming a queue:

'''
print('\r\n\r\n\r\r\r\r\r\r')

queue = Queue(1)

def consumer1():
    time.sleep(0.1)
    queue.get()
    print('Consumer got 1')
    queue.get()
    print('Consumer got 2')

thread = Thread(target=consumer1)

thread.start()


''' The wait should allow the producer thread to put both
objects on the queue before the consume thread ever calls
get. But the Queue size is one. That means the producer 
adding items to the queue will have to wait for the consumer
thread to call get at least once before the second call
to put will stop blocking and add the second item to the queue.

'''

queue.put(object())       #Runs first
print('Producer put 1')
queue.put(object())
print('Producer put 2')
thread.join()
print('Producer done')

'''
The Queue class can also track the progress of work using the task_done
method. This lets you wait for a phase's input queue to drain and
eliminates the need for polling the done_queue at the end of your pipeline.
For example, here I define a consumer thread that calls taks_done
when it finishes working on an item.

'''

print('\r\r\r\r\r\r\r\r')

in_queue = Queue()

def consumer2():
    print('Consumer waiting')
    work = in_queue.get()         # Done second
    print('Consumer working')
    # Doing work
    # ...
    print('Consumer done')
    in_queue.task_done()           # Done third

Thread(target= consumer2).start()

'''
Now the producer code doesn't have to join the consumer thread
or poll. The producer can just wait for the in_queue to finish
by calling join on the Queue instance. Even once it's empty,
the in_queue won't be joinable until after task_Done is called
for every item that was ever enqueued.

'''

in_queue.put(object())
print('Producer waiting')
in_queue.join()  # wait in_Queue to finish
print('Producer done')


''' 
I can put all of these behaviors together into a Queue subclass
that also tells the worker thread when it should stop processing.
Here, I define a close method that adds a special item to the
queue that indicates there will be no more input items after it:

'''

class ClosableQueue(Queue):
    SENTINEL = object()

    def close(self):
        self.put(self.SENTINEL)

    '''
    Then I define an iterator for the queue that looks for this special
    object and stops iteration when it's found. This __iter__ method also
    calls taks_done at appropriate times, letting me track the progress
    of work on the queue.
    '''
    def __iter__(self):
        while True:
            item = self.get()
            try:
                if item is self.SENTINEL:
                    return 
                yield item
            finally:
                self.task_done()


''' Now, I can redefine my worker thread to rely on the behavior
of the CloseableQueue class. The thread will exit once the for loop 
is exhausted.
'''

class StoppableWorker(Thread):
    def __init__(self, func, in_queue, out_queue):
        pass 
    
    def run(self):
        for item in self.in_queue:
            result = self.func(item)
            self.out_queue.put(result)

'''
Here, I re-create the set of worker threads using the new worker class:

'''

download_queue = ClosableQueue()

threads = [
    StoppableWorker(download, download_queue, resize_queue),
]

'''
After running the worker threads like before, I also send the
stop signal once all the input work has been injected by closing
the input queue of the first phase.
'''

for thread in threads:
    thread.start()
for _ in range(1000):
    download_queue.put(object())
download_queue.close()



''' Things to Remember

- Pipelines are a great way to organize sequences of work that run
concurrently using multiple Python threads

- Be aware of the many problems in building concurrent pipelines:
busy waiting, stopping workers, and memory explosion.

- The Queue class has all of the facilities you need to build robust
pipelines: blocking operations , buffer sizes, and joingning.
