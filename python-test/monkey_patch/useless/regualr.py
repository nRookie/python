import time

_EVENT_BUFFER = bytearray()
# _EVENT_BUFFER.extend(b'BL_V01\rAT+CFUN?\rAT+CFUN=1\r')
_EVENT_BUFFER.extend(b'\r\n*MATREADY: 1\r\n\r\n+CFUN: 0\r\n')
_EVENT_BUFFER.extend(b'\r\n+CEREG: 0\r\n')
_EVENT_BUFFER.extend(b'\r')
_EVENT_BUFFER.extend(b'AT')
_EVENT_BUFFER.extend(b'+CFUN?\r\r\n+CFUN: 0\r\n\r\nOK\r\n')
_EVENT_BUFFER.extend(b'AT+CFUN=1\r')
_EVENT_BUFFER.extend(b'\r\nOK\r\n')
_EVENT_BUFFER.extend(b'\r\n+CPIN: READY\r\n')
_EVENT_BUFFER.extend(b'\r\n+CEREG: 2\r\n')
_EVENT_BUFFER.extend(b'\r\n+CEREG: 1,"0002","01A2D1')
_EVENT_BUFFER.extend(b'02",9\r\n')
_EVENT_BUFFER.extend(b'\r\n+IP: 2001:468:3001:2:2001:468:3001:2\r\n')
_EVENT_BUFFER.extend(b'\r\n+LWM2M:conn,0\r\n')
_EVENT_BUFFER.extend(b'\r\n+LWM2M:reg faile')
_EVENT_BUFFER.extend(b'd back off\r\n')



import re
_EVENT_REGEXP = re.compile(r'[\s\S]*\n\r[\s\S]+\n\r\n\r|\r\n.+?\r\n'.encode())

def init():
    global _EVENT_BUFFER
    _EVENT_BUFFER.extend(b'\r\n*MATREADY: 1\r\n\r\n+CFUN: 0\r\n')
    _EVENT_BUFFER.extend(b'\r\n+CEREG: 0\r\n')
    _EVENT_BUFFER.extend(b'\r')
    _EVENT_BUFFER.extend(b'AT')
    _EVENT_BUFFER.extend(b'+CFUN?\r\r\n+CFUN: 0\r\n\r\nOK\r\n')
    _EVENT_BUFFER.extend(b'AT+CFUN=1\r')
    _EVENT_BUFFER.extend(b'\r\nOK\r\n')
    _EVENT_BUFFER.extend(b'\r\n+CPIN: READY\r\n')
    _EVENT_BUFFER.extend(b'\r\n+CEREG: 2\r\n')
    _EVENT_BUFFER.extend(b'\r\n+CEREG: 1,"0002","01A2D1')
    _EVENT_BUFFER.extend(b'02",9\r\n')
    _EVENT_BUFFER.extend(b'\r\n+IP: 2001:468:3001:2:2001:468:3001:2\r\n')
    _EVENT_BUFFER.extend(b'\r\n+LWM2M:conn,0\r\n')
    _EVENT_BUFFER.extend(b'\r\n+LWM2M:reg faile')
    _EVENT_BUFFER.extend(b'd back off\r\n')

# _EVENT_REGEXP

def parse(keywords):
    keywords += r'[^\r\n]*[\r\n]{2}'
    keywords = keywords.encode()
    global _EVENT_BUFFER
    m = re.search(keywords, _EVENT_BUFFER)
    event = None
    if m:
        print(_EVENT_BUFFER)
        event = _EVENT_BUFFER[:m.end()]
        print(event)
        _EVENT_BUFFER = _EVENT_BUFFER[m.end():]
        print(_EVENT_BUFFER)
    
    return event

def parse_to_list(event):
    event_list =[]
    m = re.search(_EVENT_REGEXP, event)
    while m:
        print(m.start())
        if m.start():
            print(event)
            raise ValueError("cannot decode this as list because it does not match the event format")
        print(event)
        event_list.append(m[0])
        event = event[m.end():]
        # print("after")
        # print(event)
        m = re.search(_EVENT_REGEXP, event)

    if len(event):
        return event_list
    else:
        raise ValueError("cannot decode this as list because it does not match the event format")

def uart_wait_event(keywords, timeout=1, multi_event=False, format= 'list'):
    """[read UART event with "keywords" within timeout in seconds]

    Arguments:
        keywords {[string]} -- [pop event from the queue and check the keywords, untill find the correct event within timeout in seconds]

    Keyword Arguments:
        timeout {int} -- [search keywords timeout in seconds] (default: {10})

    Returns:
        [string] -- [return the uart event, if failed would raise Error with error message]
    """
    start_time = time.time()
    end_time = start_time + timeout
    while True:
        remain_time = end_time - time.time()
        if remain_time > 0:
            event = parse(keywords)
            print("event is:" ,event)
            # found the keywords in the buffer
            if event:
                if format == 'list':
                    return parse_to_list(event)
                elif format ==  'str':
                    return event.decode()
                elif format == 'bytes':
                    return event
                else:
                    raise ValueError(f"un Supported format:{format}, format should be list, str, or bytes")
            time.sleep(0.1)
        elif remain_time <= 0:
            raise TimeoutError(f"No event matched with {keywords} within {timeout} seconds!")