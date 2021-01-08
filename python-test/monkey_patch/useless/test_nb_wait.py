
# class MockResponse:
#     @staticmethod
#     def json():
#         return {"mock_key": "mock_response"}


# def test_nb_wait(monkeypatch):
#     def mock_get(*args, **kwargs):
#         return MockResponse
    
#     monkeypatch.setattr(requests, "get", mock_get)

#     result = app.get_json("https://fakeurl")
#     assert result["mock_key"] == "mock_response"


from low_level_nb_at_api import low_level_nb_at_api


def test_parse_event_string(monkeypatch):

    def mock_decode(*args, **kwargs):

        _EVENT_BUFFER = bytearray()
        _EVENT_BUFFER.extend(b'AT+CFUN=1\r')
        _EVENT_BUFFER.extend(b'\r\nOK\r\n')
        _EVENT_BUFFER.extend(b'\r\n+CPIN: READY\r\n')
        _EVENT_BUFFER.extend(b'\r\n+CEREG: 2\r\n')
        _EVENT_BUFFER.extend(b'\r\n+CEREG: 1,"0002","01A2D102",9\r\n')
        _EVENT_BUFFER.extend(b'\r\n+LWM2M:conn,0\r\n')
        _EVENT_BUFFER.extend(b'\r\n+LWM2M:reg failed back off\r\n')
        _EVENT_BUFFER.extend(b'\r\n+IP: 2001:468:3001:2:2001:468:3001:2\r\n')
        _EVENT_BUFFER.extend(b'\n\rF1: 00')
        _EVENT_BUFFER.extend(b'00 0000\n\rV0: 0000 0000 [0001]\n\r00: 0006 000C\n\r01: 0000 0000\n\rU0: 0000 0001 [0000]\n\rT0: 0000 00B4\n\rLeaving the BROM\n\r\n\r')
        _EVENT_BUFFER.extend(b'BL_V01')
        return bytes(_EVENT_BUFFER).decode(encoding='utf-8', errors='ignore')

    nb = low_level_nb_at_api()
    monkeypatch.setattr("low_level_nb_at_api.low_level_nb_at_api.test_good", mock_decode)
    # monkeypatch.setattr(low_level_nb_at_api, "_eventBuffer", _EVENT_BUFFER)
    # monkeypatch.setattr("low_level_nb_at_api.low_level_nb_at_api._eventBuffer", _EVENT_BUFFER)
    nb._parse_event_string()
    for event in nb._event_list:
        print(event.encode())
        print()
    print(nb._eventBuffer)

    print('\n\n\n seond time')
    def mock_decode1(*args, **kwargs):
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
        return bytes(_EVENT_BUFFER).decode(encoding='utf-8', errors='ignore')

    monkeypatch.setattr("low_level_nb_at_api.low_level_nb_at_api.test_good", mock_decode1)


    nb._parse_event_string()
    for event in nb._event_list:
        print(event.encode())
        print()
    print(nb._eventBuffer)