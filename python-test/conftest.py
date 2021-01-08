# test/conftest.py
import pytest
import logging
import json

@pytest.fixture(scope="session")
def read_config():
    with open("app.json") as f:
        config = json.load(f)
        logging.info("Read config")
    return config
