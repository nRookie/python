# getting the data
import requests
from urllib.request import urlopen
from lxml import etree
# get html from site and write to local file
url = 'https://www.starwars.com/news/15-star-wars-quotes-to-use-in-everyday-life'
headers = {'Content-Type': 'text/html',}
response = requests.get(url, headers=headers)
html = response.text
with open ('star_wars_html', 'w', encoding='utf-8') as f:
    f.write(html)
    
# read local html file and set up lxml html parser
local = 'file:///D:/leisureGit/python/requests-library/star_wars_html.html'
# local = 'https://www.starwars.com/news/15-star-wars-quotes-to-use-in-everyday-life'
response = urlopen(local)
htmlparser = etree.HTMLParser()
tree = etree.parse(response, htmlparser)
# print(tree.xpath('//p/strong/text()'))


# # how do you get stuff that has stuff you want to search
# print(tree.xpath('//p[contains(text(), "Use")]/text()'))

# # get stuff that doesn't have other stuff
# print(tree.xpath('//p/strong[not(contains(text(), "\xa0"))]/text()') )

# print('\r\r\r\n')

# # # get starts-with
print(tree.xpath('//img[starts-with(@class, "alignnone")]/@src'))


# get all the stuff under something (descendant)
print(tree.xpath('//header[@class="article-header"]/descendant::node()/text()'))

# get stuff based on its index.
print(tree.xpath('//li[@class="related-post"]/a/@href'))