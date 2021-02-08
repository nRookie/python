''' Here's a common interview-style problem

You have three $20 dollar bills, five $10 dollar bills, two $5 dollar bills, 
and five $1 dollar bills. How many ways can you make change for a $100 dollar bill?
'''


'''
To "brute force" this problem , you just start listing off the ways there are to choose 
one bill from your wallet, check whether any of these makes change for $100, then list the 
ways to pick two bills from your wallet, check again, and so on and so forth.

But you are a programmer, so naturally you want to automate this process.

First, create a list of the bills you have in your wallet:
'''


'''
bills = [20, 20, 20, 10, 10, 10, 10, 10, 5, 5, 1, 1, 1, 1, 1]
'''


''' 
A choice of k things from a set of n things is called a combination, and itertools has your back here.
The itertools.combinations() function takes two arguments-- an iterable inputs and a positive integer n -- and produces
an iterator over tuples of all combinations of n elements in inputs.

For example, to list the combinations of three bills in your wallet, just do:
'''

'''
list(it.combinations(bills, 3))
 [(20, 20, 20), (20, 20, 10), (20, 20, 10), ... ]
'''
'''
To solve the problem, you can loop over the positive integers from 1 to len(bills), then 
check with combinations of each size add up to  $100:
'''

''' python
makes_100 = []
for n in range(1, len(bills) + 1):
    for combination in it.combinations(bills, n):
        if sum(combination) == 100:
            makes_100.append(combination)
'''

''' 
if you print out makes_100, you will notice there are a lot of repeated combinations. This makes sense because you can make
change for $100 with three $20 dollar bills and four $100 bills, but combinations() does this with the first four $10 dollars bills in your 
wallet: the first, third, foruth and fifth dollar bills: the first, second, fourth, and fifth $10 bills; and so on.
'''

'''
To remove duplicates from makes_100, you can convert it to a set:
'''
'''
set(makes_100)
'''



'''
references:
https://realpython.com/python-itertools/
'''