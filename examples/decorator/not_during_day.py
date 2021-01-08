from datetime import datetime
import functools


def not_during_the_night(func):
    @functools.wraps(func)
    def wrapper():
        if 7 <= datetime.now().hour < 22:
            func()
        else:
            pass # Hush , the neighbors are asleep
    return wrapper

def say_whee():
    print("Whee!")

say_whee = not_during_the_night(say_whee)

