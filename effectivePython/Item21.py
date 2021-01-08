def safe_division(number,divisor,*,ignore_overflow=False,
ignore_zero_division=False):
    try:
        return number / divisor
    except OverflowError:
        if ignore_overflow:
            return 0
        else:
            raise
    except ZeroDivisionError:
        if ignore_zero_division:
            return float('inf')
        else:
            raise

## Using this function is straightforward. This call
## will ignore the float overflow from division and will return 0

#result = safe_division(1,10**500,True,False)
#print(result)

''' redefine the safe_division function to accept keyword-only arguments.
The * symbol in the argument list indicates the end of positional arguments
and the beginning of keyword-only arguments.

'''

try:
    safe_division(1,0,ignore_zero_division=True)
except ZeroDivisionError:
    pass


''' Things to Remember

- Keyword arguments make the intention of a function call more clear.

- Use keyword-only arguments to force callers to supply keyword arguments
for potentially confusing functions, especially those that accept
multiple Boolean flags.

- Python 3 supports explicit syntax for keyword-only arguments in functions.


