def better_grouper(inputs, n):
    iters = [iter(inputs)] * n
    return zip(*iters)

''' python
There's a lot going on in this little function, so let's break it down with a concrete example.
The expression [iters(inputs)] * n creates a list of n references to the same iterator.

nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
iters = [iter(nums)] * 2
list(id(itr) for itr in iters) 


Next, zip(*iters) returns an iterator over pairs of corresponding elements of each iterator in iters, When the first element , 1, is taken from the "first" iterator,
 the "second" iterator now starts at 2 since it is just a reference to the "first" iterator and has therefore been advanced one step. So, the first tuple 
 produced by zip() is (1, 2).
 
 At this point , "both" iterators in iters start at 3 , so when zip() pulls  from the "first" iterator, it gets 4 from the "second" to produce the tuple (3, 4).
 This process continues until zip() finally produces (9, 10) and "both" iterators in iters are exhausted:
 

'''

'''

The better_grouper() function is better for a couple of reasons.First, without the reference to the len() built-in, better_grouper() can take any iterable as an 
argument (even infinite iterators). Second , by returning an iterator rather than a list, better_grouper() can process enormous iterables without trouble and uses much less
memory.

Store the following in a file called better.py and run it with time from the console again.
'''

for _ in better_grouper(range(100000000), 10):
    pass



''' The grouper Recipe

The problem with better_grouper() is that it doesn't handle situations where the value passed to the second argument isn't a factor of the length of the iterable in the 
first argument:
'''

''' 
>>> nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
>>> list(better_grouper(nums, 4))
[(1, 2, 3, 4), (5, 6, 7, 8)]
'''



''' 

The elements 9 and 10 are missing from the grouped output. 
This happens because zip() stops aggregating elements once the shortest iterable passed to it is exhausted. 
It would make more sense to return a third group containing 9 and 10.

To do this, you can use itertools.zip_longest(). 
This function accepts any number of iterables as arguments and a fillvalue keyword argument that defaults to None. 
The easiest way to get a sense of the difference between zip() and zip_longest() is to look at some example output:
'''


'''
>>> import itertools as it
>>> x = [1, 2, 3, 4, 5]
>>> y = ['a', 'b', 'c']
>>> list(zip(x, y))
[(1, 'a'), (2, 'b'), (3, 'c')]
>>> list(it.zip_longest(x, y))
[(1, 'a'), (2, 'b'), (3, 'c'), (4, None), (5, None)]
'''

import itertools as it

def grouper(inputs, n, fillvalue=None):
    iters = [iter(inputs)] * n
    return it.zip_longest(*iters, fillvalue=fillvalue)


'''

Now you can get a better result
>>> nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
>>> print(list(grouper(nums, 4)))
[(1, 2, 3, 4), (5, 6, 7, 8), (9, 10, None, None)]

'''

''' 
The grouper() function can be found in the Recipes section of the itertools docs.
 The recipes are an excellent source of inspiration for ways to use itertools to your advantage.



'''