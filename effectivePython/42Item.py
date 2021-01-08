from functools import wraps
def trace(func):
    @wraps(func)
    def wrapper(*args, **kwargs):
        result = func(*args, **kwargs)
        print('%s(%r, %r) -> %r' %
            (func.__name__, args, kwargs, result))
        return result
    return wrapper

@trace
def fibonacci(n):
    """Return the n-th Fibonacci number"""
    if n in (0, 1):
        return n
    return (fibonacci(n - 2) + fibonacci(n - 1))

help(fibonacci)


''' Decorators are Python syntax for allowing one function to modify
another function at runtime.

- Using decorators can cause strange behaviors in tools that 
do introspection, such as debuggers.

- Use the wraps decorator from the functools built-in module
when you define your own decorators to avoid any issues.
