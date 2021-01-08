from socket import *

sock = socket(AF_INET,SOCK_DGRAM)
sock.bind(('',5231))
(data,address) = sock.recvfrom(1024)
print(data)
sock.sendto(b'hello',address)