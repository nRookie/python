import requests

task = {"summary": "Take out trash", "description": "" }
resp = requests.get('https://api.github.com/',
                    json=task,
                    headers={'Accept': 'application/vnd.github.v3+json'},
)
if resp.status_code != 200:
    # This means something went wrong.
    raise ApiError('GET /tasks/ {}'.format(resp.status_code))


#resp = requests.post('https://api.github.com/',json=task)