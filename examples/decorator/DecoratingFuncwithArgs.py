from decorators import do_twice

@do_twice
def greet(name):
    print(f"Hello {name}")


''' The problem is that the inner function wrapper_do_twice() does not take any arguments, but name="World" was passed to it.
You could fix this by letting wrapper_do_twice() accept one argument, but then it would not work for the say_whee() function 
you created earlier.

The solution is to use *args and **kwargs in the inner wrapper function. Then it will accept an arbitrary number of positional 
and keyword arguments. Rewrite decorators.py as follows:
