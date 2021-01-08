import pytest
import json
import logging

@pytest.fixture
def read_config():
    with open("app.json") as f:
        # app.json is an empty JSON file
        config = json.load(f)
    return config

def test1(read_config):
    assert read_config == {}