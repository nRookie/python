import requests
from getpass import getpass

# By using a context manager, you can ensure the resources used by
# the session will be released after use
with requests.Session() as session:
    session.auth = ('228611676@qq.com', getpass())

    # Instead of requests.get(), you'll use session.get()
    response = session.get('https://api.github.com/user')

# You can inspect the response just like you did before
print(response.headers)
print(response.json())