# Download stock quotes in CSV


import requests
import time


i = 0


# obtain quote once every 3 seconds for the next 6 seconds

while (i < 2):
    # define the base url
    base_url = 'https://query1.finance.yahoo.com/v7/finance/quote?lang=en-US&region=US&corsDomain=finance.yahoo.com&symbols=FB&fields=regularMarketPrice'


    # retrieve data from web server
    data = requests.get(
    base_url,
    params={'s': 'GOOG', 'f': 'sl1d1t1c1ohgv', 'e': '.json'})
    # write the data to csv
    with open('stocks.json', 'wb') as code:
        code.write(data.content)
        i += 1
        # pause for 3 seconds
        time.sleep(3)