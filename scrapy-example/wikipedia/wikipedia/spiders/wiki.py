import scrapy

from scrapy import Spider
from scrapy.selector import Selector

from wikipedia.items import WikipediaItem

from urllib.parse import urljoin

class WikiSpider(scrapy.Spider):
    name = 'wiki'
    allowed_domains = ['en.wikipedia.org']
    start_urls = ['http://en.wikipedia.org/wiki/Category:2014_films']

    def parse(self, response):
        titles = Selector(response).xpath('//div[@id="mw-pages"]//li')
        
        for title in titles:
            item = WikipediaItem()
            url = title.xpath("a/@href").extract()
            item["title"] = title.xpath("a/text()").extract()
            item["url"] = url[0]
            yield item

        # for title in titles:
        #     item = WikipediaItem()
        #     url = title.xpath("a/@href").extract()
        #     if url:
        #         item["title"] = title.xpath("a/text()").extract()
        #         item["url"] = urljoin("http://en.wikipedia.org", url[0])
        #         yield item
