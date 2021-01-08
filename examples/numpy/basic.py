class A(object):
    def __init__(self):
        self.good = None 
        
    def say_hello(self):
        print('hello')
        
        
        
class B(A):
    def __init__(self):
        super().__init__() # with this method will extend the property of parent class
        ## will extend the method automatically
    
    
    

import requests

task = {"summary": "Take out trash", "description": "" }
resp = requests.post('https://www.baidu.com', data=task)
if resp.status_code != 201:
    print('No')
    pass
    #raise ApiError('POST /tasks/ {}'.format(resp.status_code))
print('Created task. ID: {}'.format(resp.json()["id"]))


# resp = requests.get('https://www.baidu.com')

# if resp.status_code != 200:
#         # This means something went wrong.
#        # raise ApiError('GET /tasks/ {}'.format(resp.status_code))
#         pass
# for todo_item in resp.json():
#     print('{} {}'.format(todo_item['id'],todo_item['summary']))
    
    
