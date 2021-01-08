import logging
import threading
import time

def thread_function(name):
    logging.info("Thread %s: starting", name )
    #time.sleep(1)
    logging.info("Thread %s: finishing", name)
    
# if __name__ == "__main__":
def method1():
    format = "%(asctime)s: %(message)s"
    logging.basicConfig(format=format, level=logging.INFO,datefmt="%H:%M:%S")
    
    
    threads = list()
    
    for index in range(3):
        logging.info("Main : Create and start thread %d." , index)
        x = threading.Thread(target=thread_function, args = (index,))
        threads.append(x)
        x.start()
        
        
    for index, thread in enumerate(threads):
        logging.info("Main  : before joining thread %d. ", index)
        thread.join()
        logging.info("Main  : thread %d done", index)



import concurrent.futures


def method2():
    format = "%(asctime)s: %(message)s"
    logging.basicConfig(format=format, level =logging.INFO,
    datefmt="%H:%M:%S")


    with concurrent.futures.ThreadPoolExecutor(max_workers=3) as executor:
        executor.map(thread_function,range(4))