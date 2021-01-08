

import queue
import string
import random
import threading
import time 
Q = queue.Queue()

Q1 = queue.Queue()
def write_thread():
    while True:
        Q.put(rnumber(1))

def rnumber(length):
    return ''.join(random.choice(string.ascii_letters) for m in range(length))
data = ''

def other_thread():
    while True:
        if not Q1.empty():
            data = Q1.get()

write_thread = threading.Thread(target=write_thread)
write_thread.start()

# other_thread = threading.Thread(target=other_thread)


# other_thread.start()


def read_func(length):
    s =''
    t = time.time()
    while True:
        if not Q.empty():
            data = Q.get()
            s+=data
        else:
            pass
        if len(s) == length:
            print(time.time()-t)
            return ''

        
        
        
read_func(5000)
input('new')
    