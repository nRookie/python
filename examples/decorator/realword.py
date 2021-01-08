import functools

def decorator(func):
    @functools.wraps(func)
    def wrapper_decorator(*args,**kwargs):
        # Do something before
        print('what')
        value = func(*args,**kwargs)
        # Do something after
        print('No')
        return value
    return wrapper_decorator

ws_server_host = '127.0.0.1'
ws_server_port = '8765'

class A:
    @decorator
    def hello_world(self):
        print('hello_world')


a = A()

@decorator
def hal_ws_client_open(host='127.0.0.1',port=8765):
    """Open a WebSocket client and connect to remote server with ``host`` and ``port``

    Takes two arguments ``host`` and ``port``
        default value of ``host`` is 127.0.0.1
        default value of ``port`` is 8765

    Examples:
        | `HAL WS CLIENT OPEN` | host=127.0.0.1 |
        | `HAL WS CLIENT OPEN` | port=8765 |
        | `HAL WS CLIENT OPEN` | host=127.0.0.1 | port=8765 |
    """
    if str(locals().get('host')) == '127.0.0.1':
        host = ws_server_host

    if  str(locals().get('port')) == '8765':
        port = ws_server_port
    return None