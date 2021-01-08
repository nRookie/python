import os 

basepath = '/'
for entry in os.listdir(basepath):
    if os.path.isdir(os.path.join(basepath,entry)):
        print(entry)