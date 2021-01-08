import logging
from contextlib import contextmanager
def my_function():
    logging.debug('Some debug data')
    logging.error('Error log here')
    logging.debug('More debug data')

my_function()


@contextmanager
def debug_logging(level):
    logger = logging.getLogger()
    old_level = logger.getEffectiveLevel()
    logger.setLevel(level)
    try:
        yield 
    finally:
        logger.setLevel(old_level)


with debug_logging(logging.DEBUG):
    print('Inside:')
    my_function()
print('After:')
my_function()


@contextmanager
def log_level(level, name):
    logger = logging.getLogger(name)
    old_level = logger.getEffectiveLevel()
    logger.setLevel(level)
    try:
        yield logger
    finally:
        logger.setLevel(old_level)

with log_level(logging.DEBUG, 'my-log') as logger:
    logger.debug('This is my message!')
    logging.debug('This will not print')

''' Things to Remember

- The with statement allows you to reuse logic from try/finally
blocks and reduce visual noise.

- The contextlib built-in module provides a contextmanager decorator that
makes it easy to use your own functions in with statements.

- The value yielded by context managers is supplied to the as
part of the with statement. It's useful for letting your code
directly access the cause of the special context.

