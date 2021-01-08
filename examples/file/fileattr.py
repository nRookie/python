import os
with os.scandir('/') as dir_contents:
    for entry in dir_contents:
        info = entry.stat()
        print(info.st_mtime)