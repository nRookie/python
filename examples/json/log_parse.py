import json

# class dict_log(object):
#     def __init__(self,data,dir_,layer,idx,timestamp,level,src):
#         self.data = data
#         self.dir_ = dir_
#         self.layer = layer
#         self.idx = idx
#         self.timestamp = timestamp
#         self.level = level
#         self.src =src 
#         #logs = (layer,dir_,level,data,timestamp,src,idx)
        


# def decode_log(dct):

#     # print(dct["data"])
#     # print(dct["dir"])
#     # print(dct["layer"])
#     # print(dct["idx"])
#     # print(dct["src"])
#     # print(dct["idx"])
#     # print(dct["level"])
#     # print(dct["timestamp"])

#     log_item = dict_log(dct["data"],dct["dir"],dct["layer"],dct["idx"],dct["timestamp"],dct["level"],dct["src"])
#     return log_item



with open("log_get1.json") as log2:
    # #("2")
    # zz = json.load(log2,object_hook=decode_log)
    # print(type(zz))
    log_list = []
    data = log2.read()

    z = json.loads(data)
    print(type(z))

    if z.get('message') is 'log_get':
        for key,value in z.items():
            if key is 'logs':
                for _ in value:
                    log_list.append()

    
# # with open("what.json","w") as log3:
# #      
# #     print(type(zz))
# #     # json.dump(zz,log3)

# def log_should_contain(Layer,Value):
#     for log in log_list:
#         if log.layer == Layer:
#             for data in log.data:
#                 if data.find(Value) != -1:
#                     return True

# print(log_should_contain('NAS','Attach request'))
