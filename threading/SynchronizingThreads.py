#Synchronizing Threads

''' The threading module provided with Python includes a simple-to-implement locking
mechanism that allows you to synchronize threads. A new lock includes
created by calling the Lock() method,which returns the new clock.

The acquire(blocking) method of the new lock object is 
used to force the threads to run synchronously. The optional
blocking parameter enables you to control whether the thread waits to
acquire the lock.

If blocking is set to 0, the thread returns immediately with a 0 value if the lock
cannot be acquired and with a 1 if the lock was acquired. If blocking is set to 1,
the thread blocks and wait for the lock to be released.

The release() method of the new lock object is used to release the lock when it is no longer
required.

'''


import threading
import time

class myThread(threading.Thread):
    def __init__(self,threadID,name,counter):
        threading.Thread.__init__(self)
        self.threadID = threadID
        self.name = name
        self.counter = counter
    def run(self):
        print ("Starting " + self.name)
        #Get lock to synchronize threads
        threadLock.acquire()
        print_time(self.name,self.counter,3)
        # Free lock to release next thread
        threadLock.release()
def print_time(threadName,delay,counter):
    while counter:
        time.sleep(delay)
        print("%s: %s" % (threadName,time.ctime(time.time())))
        counter -=1

threadLock = threading.Lock()
threads = []

thread1 = myThread(1,"Thread-1",1)
thread2 = myThread(2,"Thread-2",2)

thread1.start()
thread2.start()
'''
threads.append(thread1)
threads.append(thread2)

for t in threads:
    t.join()
    '''
print("Exiting Main Thread")