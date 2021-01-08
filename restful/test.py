import requests

BASE = "http://127.0.0.1:5000/"

# data = [{"likes": 70,"name": "joe","views": 10020},
#         {"likes": 2320,"name": "how to make rest ","views": 100320},
#         {"likes": 32320,"name": "tim","views": 100230},
#         {"likes": 1343,"name": "no way","views": 102200},]


# for i in range(len(data)):
#     response = requests.put(BASE + "video/" + str(i), data[i])
#     print(response.json())

response = requests.patch(BASE + "video/2", {"views":101})
print(response.json())
input()

response = requests.get(BASE + "video/1")
print(response.json())

input()

 