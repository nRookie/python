from socket import *


csock = socket(AF_INET,SOCK_DGRAM)

csock.sendto(b'hi',('192.168.220.1',5231))
n = 1024*1024
(data,address) = (csock.recvfrom(n))
print(1)
print(len(data))