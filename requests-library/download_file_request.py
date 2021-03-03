import requests
from pathlib import Path
from zipfile import ZipFile
from urllib.request import urlopen
from urllib.parse import urljoin
import logging
import yaml

from lxml import etree

FILE_URL = ''
FOLDER_URL = ''
YAML_FILE = 'xxx.yaml'

def walk_url(url):
    ''' walk a given url directory, lists file lists '''
    response = urlopen(url)
    htmlparser = etree.HTMLParser()
    tree = etree.parse(response, htmlparser)
    return tree.xpath('//a[contains(@href, "whl")]/text()')

def download_file(url):
    ''' download a file from a given url '''
    local_filename = url.split('/')[-1]
    # NOTE the stream=True parameter below
    try:
        with requests.get(url, stream=True) as r:
            r.raise_for_status()
            with open(local_filename, 'wb') as f:
                for chunk in r.iter_content(chunk_size=8192):
                    f.write(chunk)
    except Exception as e:
        logging.debug('ok')
    return local_filename


def extract_file(filename):
    '''extract a zip file'''
    zip_path = Path(filename)
    if zip_path.exists():
        with ZipFile(zip_path, 'r') as myzip:
            myzip.extractall(zip_path.stem)
            logging.debug(f'{filename}: extracted.')

# filename = download_file(FILE_URL)
# extract_file(filename)

def get_file_url(filename):
    return urljoin(FOLDER_URL, filename.strip())

def update_yaml(filenames):
    yaml_file = None
    with open(YAML_FILE) as fid:
        yaml_file = yaml.load(fid, Loader=yaml.FullLoader)
        print(yaml_file)
        extensions = yaml_file.get('extensions')
        if extensions:
            for filename in filenames:
                logging.debug(type(filename))
                logging.debug(type(extensions))
                if extensions.get(filename) is None:
                    extensions.update(
                        { str(filename.strip()): [
                            {'downloaded': False }, 
                            {'download_address': get_file_url(filename)}, 
                            {'path': ''} 
                           ]
                        }
                    )
        else:
            raise ValueError("TBD")

    with open('YAML_FILE.yaml', 'w') as fid:
        yaml.dump(yaml_file, fid)

def main():
    logging.basicConfig(format='%(filename)s %(lineno)d %(message)s')
    logging.getLogger().setLevel(logging.DEBUG) 
    filenames = walk_url(FOLDER_URL)
    update_yaml(filenames)
    # for filename in filenames:
    #     file_url = urljoin(FOLDER_URL, filename.strip())
    #     filename = download_file(file_url)
    #     extract_file(filename)


if __name__ == "__main__":
    main()