from decorators import do_twice

@do_twice
def return_greeting(name):
    print("Creating greeting")
    return f"Hi {name}"

    

    ''' Oops your decorator ate the return value from the functiom.
    Because the do_twice_wrapper() doesn't explicitly return a value, the call return_greeting("Adam") ended up returning None.

To fix this, you need to make sure the wrapper function returns the return value of the deorated function. Change your decorators.py file:



    '''