class MyValidationError(Exception):
    pass

def my_function():
    if True:
        raise MyValidationError("Error messageddd")
    return 4

def foo():
    
try:
    result = my_function()
except MyValidationError as exception:
    raise exception

