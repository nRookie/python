import threading

class MyThread(threading.Thread):
    def __init__(self,number):
        super(MyThread,self).__init__()
        self.number = number
        # Can setup other things before the thread starts
    def run(self):
        print (self.number)


thread_list = []
for i in range(4):
    thread = MyThread(i)
    thread_list.append(thread)
    thread.start()