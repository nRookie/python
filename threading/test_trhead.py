
""" Low-level serial communications handling """

import sys, threading, logging
import re
import random
import string
import queue
import time 
#from exceptions import TimeoutException

class low_level_uart_api(object):
    """ Libraries for Low level Uart APIs

    This Library can only be used with UIL Keywords in robotframework, And provide below APIs
    uart_open
    uart_close
    uart_write
    uart_read
    uart_wait_event
    uart_cfg_wait_rsp_flag
    uart_is_wait_rsp_flag
    uart_set_cmd_timeout
    uart_flush
    """
    # Default timeout for serial port reads (in seconds)
    def __init__(self):
        """ Constructor

        """
        super(low_level_uart_api, self).__init__()

        self._ll_alive = False
        #self.port = "/dev/ttyS0"
        #self.baudrate = 9600


        self._uart_rx_queue = queue.Queue()
        self._uart_tx_queue = queue.Queue()
        self._tx_lock = threading.Lock()
        self._rx_lock = threading.Lock()
        #self._lock_cmd_rsp = threading.Lock()
        self._ll_rx_timeout = 30
        #self._unsolicited_list=[]

        self._rxThread = None
        self._txThread = None

    def ll_uart_open(self):
        self._ll_alive = True
        self._txThread = threading.Thread(target=self._writeloop)
        self._txThread.daemon = True
        self._txThread.start()
        self._rxThread = threading.Thread(target=self._readloop)
        self._rxThread.daemon = True
        self._rxThread.start()
        return True
        # Start read thread
    def ll_uart_write(self,payload):
        """[push Uart cmd from tx queue]
        low level thread will pop from queue and send out through UART

        Arguments:
            payload {[string]} -- [uart cmd payload]
        """

        self._uart_tx_queue.put(payload)

    def ll_uart_read(self,length):
        """[read UART cmd response from rx queue]
        low level thread will push the cmd response to cmd response queue

        read response timeout {[int]} -is defined in **uart_set_cmd_timeout**

        Returns:
            [string] -- [return the uart cmd response, if failed return "NO RESPONSE"]
        """
        data=''
        time_begin = time.time()
        while True:
                #time_cnt = time.time() - time_begin
                # if int(time_cnt) >= self._ll_rx_timeout:
                #     print(time_cnt)
                #     print(len(data))
                #     return ''
                
                if not self._uart_rx_queue.empty():
                    #with self._rx_lock:
                    data += self._uart_rx_queue.get(1)
                    #self.log.debug("[RECV]:"+ str(data))
                else:
                    # time.sleep(0.01)
                    # time_cnt = time_cnt + 0.01
                    pass

                if len(data) == length:
                    print(time.time()-time_begin)
                    return data
                


    def ll_uart_set_cmd_timeout(self,timeout = 10):
        """[Set the UART cmd response timeout in seconds]

        Keyword Arguments:
            timeout {int} -- [UART cmd response timeout in seconds] (default: {10})
        """

        self._ll_rx_timeout = timeout

    def ll_uart_get_cmd_timeout(self):
        """[Get the UART cmd response timeout in seconds]

        """

        return self._ll_rx_timeout


    def ll_uart_close(self):
        """ Stops the read thread, waits for it to exit cleanly, then closes the underlying serial port """
        self._ll_alive = False
        self._rxThread.join(0.5)
        self._txThread.join(0.5)
        self._uart_rx_queue.queue.clear()
        self._uart_tx_queue.queue.clear()

    def _readloop(self):
        """ Read thread main loop

        Reads data from the connected device
        """

        while self._ll_alive:
            with self._rx_lock:
                data = self._Random(1)
                if len(data) != 0: # check for timeout
                    self._uart_rx_queue.put(data)


    def _writeloop(self):
        """ Read cmd from TX FIFO queue and send to DUT through UART

        write the cmd to the connected device
        """
        while self._ll_alive:
            ## Add a thread lock
            if not self._uart_tx_queue.empty():
                data = self._uart_tx_queue.get()
                #clear the response list before send the command
                #self._uart_rx_queue.clear()
                #self.log.debug("Uart send cmd:",data)
            #time.sleep(0.01)
    def _Random(self,length):
        return ''.join(random.choice(string.ascii_letters) for m in range(length))
    
    

 
uart = low_level_uart_api()

uart.ll_uart_open()

uart.ll_uart_read(5000)



input('origin')