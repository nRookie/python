
import json

dct = '{"action":"print","method":[],"data":"Madan Mohan"}'

print(type(dct))
class Payload(object):
    def __init__(self, action, method, data):
        self.action = action
        self.method = method
        self.data = data


def as_payload(dct):
    return Payload(dct['action'], dct['method'], dct['data'])

payload = json.loads(dct, object_hook = as_payload)

print(type(payload))
print(payload.action)
print(payload.method)
