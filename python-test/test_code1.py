import logging 
import json

def test1(read_config):
    logging.info("Test function 1")
    assert read_config == {}

def test2(read_config):
    logging.info("Test function 2")
    assert read_config == {}