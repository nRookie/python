from socket import *
import time

sock = socket(AF_INET,SOCK_STREAM,0)
address = ('192.168.220.1',5231)
sock.connect( address)

mystr = 'hello from {}'.format(address)
sock.sendall(mystr.encode('utf-8') )

#time.sleep(10)

#print(sock.recv(1024))

time.sleep(5)
sock.close()