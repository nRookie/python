# import os

# for f_name in os.listdir('/'):
#     if f_name.endswith('.txt'):
#         print(f_name)



import os
import fnmatch
for filename in os.listdir('.'):
    if fnmatch.fnmatch(filename,'*'):
        print(filename)