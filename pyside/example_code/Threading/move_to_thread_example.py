
import sys
import time
import logging
from PySide2.QtWidgets import QMainWindow, QApplication
from PySide2.QtCore import Signal, QObject, QThread

class Worker(QObject):
    print_signal = Signal(str, int)
    exit_signal =Signal(object)
    def __init__(self):
        super().__init__()


    def ok(self):
            self.print_signal.emit("strings", 10)
            time.sleep(1)
            self.exit_signal.emit(None)

class Mainwindow(QMainWindow):
    def __init__(self):
        super().__init__()
        self.worker = Worker()
        self.workerThread = QThread()
        self.workerThread.started.connect(self.worker.ok)  # Init worker run() at startup (optional)
        self.worker.print_signal.connect(self.printing)  # Connect your signals/slots
        self.worker.moveToThread(self.workerThread)  # Move the Worker object to the Thread object
        self.workerThread.start()
        self.worker.exit_signal.connect(self.closing)

    def __del__(self):
        pass

    def closing(self):
        self.workerThread.exit()
        self.workerThread.wait()
        self.close()

    def printing(self, text, number):
        print(text)
        print(number)

if __name__== '__main__':
    app = QApplication()
    mainwindow = Mainwindow()
    sys.exit(app.exec_())
