
""" Low-level serial communications handling """

import sys, threading, logging
import re
import time
import websocket
import select
import selectors
from .low_level_base_api import low_level_base_api
#from exceptions import TimeoutException

class low_level_ws_api(low_level_base_api):
    """ Libraries for Low level websocket client APIs

    This Library can only be used with STFNBLibrary on RPI, And provide below APIs
    ws_client_open
    ws_client_close
    ws_client_send
    ws_client_recv
    """

    def __init__(self):
        """ Constructor

        """
        super(low_level_ws_api, self).__init__()

        #load default settings
        self.ws_selector = selectors.DefaultSelector()
        self.ws_server_host = self.read_value("ws_server_host")
        self.ws_server_port = self.read_value("ws_server_port")
        self.ws_valid_fid = None
        #self.ws_client_fid = None
        self.ws_client_fid_list = []
        self.ws_events = selectors.EVENT_READ | selectors.EVENT_WRITE
    def ws_client_open(self, host = '127.0.0.1', port = 8765):
        """[Open a websocket client and connect to a server]
        low level websocket api

        Open a websocket client and connect to a server with *host* and *port*

        Arguments:
        host {[string]} -- [remote server IP]
        host {[int]} -- [remote server port]
        """
        self.ws_server_host = host
        self.ws_server_port = int(port)

        if self.ws_server_host is None:
            raise ValueError('Host could not be None')
        else :
            return self._create_connection()

    def ws_client_close(self):
        """ close websocket client.
        """
        try:
            if self.ws_client_fid_list is []:
                self.log.error("websocket connection has not established")
                raise websocket.WebSocketException("websocket connection has not established")

            self.log.debug("websocket client close connection")


            
            for ws_client_fid in self.ws_client_fid_list:
                self.ws_selector.unregister(ws_client_fid.sock)
                ws_client_fid.close()
            self.ws_client_fid = []
            self.ws_valid_fid = None

        except websocket.WebSocketConnectionClosedException as e:
            self.log.error(e.__repr__())
            raise #websocket.WebSocketConnectionClosedException("Websocket Client Close Connection Error")

    def ws_client_send(self, msg=''):
        """ send msg to websocket server.
        """
        try:
            if self.ws_client_fid_list is []:
                self.log.error("websocket connection has not established")
                raise websocket.WebSocketException("websocket connection has not established")
            
            events = self.ws_selector.select(timeout=5)

            if events:
                length = self._process_write_event(events,msg)
                if length != len(msg):
                    print(length)
                    return False
            return True
        except websocket.WebSocketConnectionClosedException as e:
            self.log.error(e.__repr__())
            raise
            
    def ws_client_recv(self):
        """ recv msg from websocket server.
        """
        try:
            if self.ws_client_fid_list is []:
                self.log.error("websocket connection has not established")
                raise websocket.WebSocketException("websocket connection has not established" )

            events = self.ws_selector.select(timeout=5)
            if events:
                return self._process_event(events)
 
        except websocket.WebSocketConnectionClosedException as e:
            self.log.error(e.__repr__())
            raise #websocket.WebSocketConnectionClosedException("websocket client recv Error")

    def ws_client_set_valid_fid(self,host,port):
        try:
            if self.ws_client_fid_list is []:
                self.log.error("websocket connection has not established")
                raise websocket.WebSocketException("websocket connection has not established")

            for ws_client_fid in self.ws_client_fid_list:
                print(ws_client_fid.sock.getpeername())
                if (host,port) == ws_client_fid.sock.getpeername():
                    print('set valid')
                    self.ws_valid_fid = ws_client_fid
                    
        except websocket.WebSocketConnectionClosedException as e:
            self.log.error(e.__repr__())

    def _create_connection(self):
        ''' 
            create a websocket connection to remote server and add the socket to the selector
        '''
        try:
            ws_client_fid = websocket.create_connection("ws://{}:{}".format(self.ws_server_host,self.ws_server_port))
            #self.ws_client_fid.sock.setblocking(False)
            self.log.debug(ws_client_fid.sock)
            print(ws_client_fid.sock)
            # add the socket to the selector
            self.ws_selector.register(ws_client_fid.sock,self.ws_events,self)
            self.ws_client_fid_list.append(ws_client_fid)
            self.ws_valid_fid = ws_client_fid 
            return True

        except ConnectionRefusedError as e:
            self.log.error(e.__repr__())
            raise
        except OSError as e:
            self.log.error("websocket client open connection Error" + e.__repr__())
            raise 
    
    def _process_read_event(self,events):
        for key,mask in events:
            if mask & selectors.EVENT_READ:
                for ws_client_fid in self.ws_client_fid_list:
                    if key.fileobj is ws_client_fid.sock:
                        return ws_client_fid.recv()

    def _process_write_event(self,events,msg):
        for key,mask in events:
            print(mask)
            if mask & selectors.EVENT_WRITE:
                if key.fileobj is self.ws_valid_fid.sock: 
                    self.log.debug("websocket client send messge "+ msg + str(self.ws_valid_fid))
                    print("websocket client send messge "+ msg + str(self.ws_valid_fid))
                    return self.ws_valid_fid.send(msg)

            return True
if __name__ == "__main__":
    test = low_level_ws_api()
    test.ws_client_open()
    test.ws_client_send('This message is sent by the low_level_websocket')
    st = test.ws_client_recv()
    print(st)
    test.ws_client_close()
