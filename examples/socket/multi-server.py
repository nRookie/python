#!/usr/bin/env python3

import sys
import socket
import selectors
import types

'''
 A selectorKey is a namedtuple used to associate a file object to its underlying file descriptor, selected event mask and attached
 data. It is returned by several BaseSelector methods.

  fileobj
    file object registered.
  fd
    Underlying file descriptor
  events
    Events that must be waited for on this file object.
  data 
    Optional opaque data associated to this file object: for example, this could be used to store a per-client 
    Session ID.
'''
sel = selectors.DefaultSelector()


def accept_wrapper(sock):
    conn, addr = sock.accept()  # Should be ready to read
    print("accepted connection from", addr)
    conn.setblocking(False)
    data = types.SimpleNamespace(addr=addr, inb=b"", outb=b"")
    events = selectors.EVENT_READ | selectors.EVENT_WRITE
    sel.register(conn, events, data=data)


def service_connection(key, mask):
    sock = key.fileobj
    data = key.data
    if mask & selectors.EVENT_READ:
        recv_data = sock.recv(1024)  # Should be ready to read
        if recv_data:
            data.outb += recv_data
        else:
            print("closing connection to", data.addr)
            sel.unregister(sock)
            sock.close()
    if mask & selectors.EVENT_WRITE:
        if data.outb:
            print("echoing", repr(data.outb), "to", data.addr)
            sent = sock.send(data.outb)  # Should be ready to write
            data.outb = data.outb[sent:]


if len(sys.argv) != 3:
    print("usage:", sys.argv[0], "<host> <port>")
    sys.exit(1)

host, port = sys.argv[1], int(sys.argv[2])
lsock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
lsock.bind((host, port))
lsock.listen()
print("listening on", (host, port))
lsock.setblocking(False)
sel.register(lsock, selectors.EVENT_READ, data=None)

try:
    while True:
        ''' Wait until some registered file object become ready,or the timeout expires.
        If timeout >0, this specifies the maximum wait time, in seconds. If timeout <= 0, the call won't block,
        and will report the currently ready file objects. If timeout is None, the call will block until a monitored file
        object becomes ready.

        This returns a list of (key,events) tuples , one for each ready file object.

        key is the SelectorKey instance corresponding to a ready file object. events is a bitmask of events ready on this 
        file object.
        '''
        events = sel.select(timeout=None)
        for key, mask in events:
            if key.data is None:
                accept_wrapper(key.fileobj)
            else:
                service_connection(key, mask)
except KeyboardInterrupt:
    print("caught keyboard interrupt, exiting")
finally:
    sel.close()