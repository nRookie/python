import json

class dict_log(object):
    def __init__(self,data,dir_,layer,idx,timestamp,level,src):
        self.data = data
        print(self.data)
        self.dir_ = dir_
        print(self.dir_)
        self.layer = layer
        self.idx = idx
        self.timestamp = timestamp
        self.level = level
        self.src =src 
        #logs = (layer,dir_,level,data,timestamp,src,idx)
        


def decode_log(dct):

    # print(dct["data"])
    # print(dct["dir"])
    # print(dct["layer"])
    # print(dct["idx"])
    # print(dct["src"])
    # print(dct["idx"])
    # print(dct["level"])
    # print(dct["timestamp"])

    print(type(dct))
    print("this is dict")
    for _ in dct:
        print(type(_))
        print(_)
        print('\r\n')

    return

 
 

with open("em.json") as log2:
    # #("2")
    # zz = json.load(log2,object_hook=decode_log)
    # print(type(zz))
    data = log2.read()
    print(type(data))
    print(data+'\r\n')
    z = json.loads(data,object_hook=decode_log)
    #print(type(z))

# # with open("what.json","w") as log3:
# #      
# #     print(type(zz))
# #     # json.dump(zz,log3)



