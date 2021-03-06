import time
import json
from datetime import datetime
'''
Use None and Docstrings to Specify Dynamic Default Arguments

Sometimes you need to use a non-static type as a keyword argument's default
value. For example, say you want to print logging messages that are
marked with the time of the logged event. In the default case,you want 
the message to include the time when the arguments are reevaluated
each time and the function is called.

'''

def log(message,when = datetime.now()):
    print('%s: %s' %(when,message))

log('Hi there!')
time.sleep(0.1)
log('Hi again!')

''' The timestamps are the same because datetime.now is only executed
a single time:

when the function is defined.Default argument values are evaluated only
once per module load, which usually happens when a program starts up.
After the module containing this code is loaded, the datetime.now default argument
will never be evaluated again.

The convention for achieving the desired result in Python is to provide
a default value of None and to document the actual behavior in the docstring().
When your code sees an argument value of None, you allocate the default
value accordingly.
'''

def log1(message,when =None):
    """ Log a message with a timestamp

    Args:
        message: Message to print.
        when: datetime of when the message occurred.
            Defaults to the present time.
    """

    when = datetime.now() if when is None else when
    print('%s:%s' %(when,message))

log1('Hi there!')
time.sleep(0.1)
log1('Hi again!')


''' 
Using None for default argument values is especially important when
the arguments are mutable. For example, say you want to load
a value encoded as JSON data. If decoding the data fails, you want an
empty dictionary to be returned by default. You might try this approach.
'''

def decode(data, default={}):
    try:
        return json.loads(data)
    except ValueError:
        return default

'''
The problem here is the same as the datetime.now example above.
The dictionary specified for default will be shared by all calls
to decode because default argument values are only evaluated once(at module
load time). This can cause extremely surprising behavior.
'''
foo = decode ('bad data')
foo['stuff'] = 5
bar = decode('also bad')
bar['meep']  = 1
print('Foo:',foo)
print('Bar:',bar)

#assert foo is bar

''' You'd expect two different dictionaries,each with a single
key and value. But modifying one seems to also modify the other.
The culprit is that foo and bar are both equal to the default 
parameter. They are the same dictionary object.

The fix is to set the keyword argument default value to None and then
document the behavior in the funciton's docstring.
'''

def decode1(data, default=None):
    """Load JSON data from a string.

    Args:
        data: JSON data to decode.
        default: Value to return if decoding fails.
            Default to an empty dictionary.
    """

    if default is None:
        default ={}
    try:
        return json.loads(data)
    except ValueError:
        return default
    
foo = decode1('bad data')
foo['stuff'] = 5
bar = decode1('also bad')
bar['meep'] = 1 
print('Foo:',foo)
print('Bar:',bar)

'''
Things to remember

- Default arguments are only evaluated once: during function
definition at module load time. This can cause odd behaviors
for dynamic values (like {} or []).

- Use None as the default value for keyword arguments that have
a dynamic value. Document the actual default behavior in the function's
docstring.

