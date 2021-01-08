import json

class dict_log(object):
    def __init__(self,data,timestamp,layer,level):
        self.data = data
        self.timestamp = timestamp
        self.layer = layer
        self.level = level
        self.dir = None
        self.ue_id = None
        self.cell = None
        self.rnti = None 
        self.src = None
        self.rnti = None
        self.frame = None
        self.channel = None
        self.src = None
        self.idx = None
        #logs = (layer,dir_,level,data,timestamp,src,idx)
        

class log_decoder:
    @staticmethod
    def decode_log(self,dct):
        log_item = dict_log(dct["data"],dct["timestamp"],dct["layer"],dct["level"])
        return log_item



with open("log_get1.json") as log2:
    # #("2")
    # zz = json.load(log2,object_hook=decode_log)
    # print(type(zz))
    log_list = []
    data = log2.read()

    z = json.loads(data,object_hook=log_decoder.decode_log)
    print(type(z))
    for _ in z:
        log_list.append(_)

    
# # with open("what.json","w") as log3:
# #      
# #     print(type(zz))
# #     # json.dump(zz,log3)

def log_should_contain(Layer,Value):
    for log in log_list:
        if log.layer == Layer:
            for data in log.data:
                if data.find(Value) != -1:
                    return True

print(log_should_contain('NAS','Attach request'))
