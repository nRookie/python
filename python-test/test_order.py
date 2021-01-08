import pytest
import logging

@pytest.fixture(scope="session")
def session():
    logging.info("scope session")
    
@pytest.fixture(scope="package")
def package():
    logging.info("scope package")

@pytest.fixture(scope="module")
def module():
    logging.info("scope module")

@pytest.fixture(scope="class")
def class_():
    logging.info("scope class")

@pytest.fixture(scope="function")
def function():
    logging.info("scope function")

def test_order(module, class_, session, function):
    assert True