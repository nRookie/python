import os

basepath = '/'

with os.scandir(basepath) as entries:
    for entry in entries:
        if entry.is_file():
            print(entry.name)