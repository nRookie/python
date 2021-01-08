import requests
from requests.exceptions import HTTPError

for url in ['https://api.github.com','https://api.github.com/invalid']:
    try:
        response = requests.get(url)
        
        # If the response was sucessful, no Exception will be raised
        response.raise_for_status()
    except HTTPError as http_err:
        print(f'Other error occured: {err}')
    else:
        print('Success!')