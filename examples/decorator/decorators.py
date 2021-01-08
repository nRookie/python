import functools
import logging 
import time 
UART_TMP_PATH = 'no.txt'
def startlogging(func):
    @functools.wraps(func)
    def wrapper_logger(*args,**kwargs):
        uart_logger = UARTLogger()
        uart_log_handler = logging.FileHandler(UART_TMP_PATH, 'w')
        uart_logger._add_handler(uart_log_handler)
        value = func(*args,**kwargs)
        return value
    return wrapper_logger


def stoplogging(func):
    @functools.wraps(func)
    def wrapper_logger(*args,**kwargs):
        value = func(*args,**kwargs)
        uart_logger = UARTLogger()
        if uart_logger.fileHandler != None:
            uart_logger._remove_handler(uart_logger.fileHandler)
            uart_logger.fileHandler = None
        return value
    return wrapper_logger

def singleton(cls):
    """Make a class a Singleton class"""
    @functools.wraps(cls)
    def wrapper_singleton(*args, **kwargs):
        if not wrapper_singleton.instance:
            wrapper_singleton.instance = cls(*args, **kwargs)
        return wrapper_singleton.instance
    wrapper_singleton.instance = None
    return wrapper_singleton

@singleton
class UARTLogger(object):
    def __init__(self):
        self._logger = logging.getLogger('uartLogger')
        self.fileHandler = None
        self.formatter = logging.Formatter('%(asctime)s %(message)s')
        self._logger.setLevel(logging.DEBUG)
        self._uart_last_logged_time = None
        self._uart_log_buffer = []

    def _rx_log(self, data=b''):
        current_time = time.time()

        if self._uart_last_logged_time is None:
            self._uart_last_logged_time = current_time
        elif current_time - self._uart_last_logged_time < 0.05:
            pass
        else:
            self._uart_last_logged_time = current_time
            if len(self._uart_log_buffer) != 0:
                self._formatted_output('rx', b''.join(self._uart_log_buffer))
                self._uart_log_buffer.clear()
        if data != b'':
            self._uart_log_buffer.append(data)

    def _tx_log(self, data):
        self._formatted_output('tx', data)

    def _formatted_output(self, uart_type, data):
        data = f"{uart_type}: {data}"
        self._logger.debug(data)

    def _add_handler(self, handler):
        handler.setFormatter(self.formatter)
        self._logger.addHandler(handler)

    def _remove_handler(self, handler):
        self._logger.removeHandler(handler)

