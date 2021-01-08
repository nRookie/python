'''
Python provides another composite data type called
a dictionary, which is similar to a list in that it is a collection
of objects.

Here's what you'll learn in this tutorial: You'll cover the basic 
characteristics of Python dictionaries and learn how to access and manage dictionary data.
Once you have finished this tutorial, you should have a goo sense of when 
a dictionary is the appropriate type to use, and how to do so.


Dictionaries and lists share the following characteristics:

    - Both are mutable.
    - Both are dynamic. They can grow and shrink as needed.
    - Both can be nested. A list can contain another list. A dictionary can contain
    another dictionary. A dictionary can also contain a list, and vice versa.

Dictionaries differ from lsits primarily in how elements are accessed:

    - List elements are accessed by their position in the list, via indexing.
    - Dictionary elements are accessed via keys.



Defining a Dicctionary 
    Dictionaries are Python's implementation of a data structure that is more
    generally known as an associative array. A dictionary consists of a collection of key-value
    pairs. Each key-value pair maps the key to its associated value.

    You can define a dictionary by enclosing a comma-separated list of key-value pairs
    in curly braces({}). A colon(:) separates each key from its associated value:


    d = {
        <key>:<value>
        <key>:<value>
            .
            .
            .
        <key>:<value>
    }

The following defines a dictionary that maps a location to the name of its
corresponding Major League Baseball team:


Python
MLB_team =  {
        'Colorado' : 'Rockies',
        'Boston'   : 'Red Sox',
        'Minnesota' : 'Twins',
        'Milkaukee' : 'Brewers',
        'Seattle'   : 'Mariners'
}

You can also construct a dictionary with the built-in dict() function.
The arugment to dict() should be sequence of key-value pairs. A list of 
tuples works well for this:

d = dict([
    (<key>,<value>),
    (<key>,<value>),
    .
    .
    .
    (<key>,<value>)
])

MLB_team can then also be defined this way:

MLB_team = dict([
    ('Colorado','Rockies'),
    ('Boston,'Red Sox'),
    ('Minnesota','Twins'),
    ('Milwaukee','Brewers'),
    ('Seattle','Mariners')
])

If the key values are simple strings, they can be specified
as keyword arguments. So here is yet another way to define
MLB_team:

MLB_team = dict(
    Colorado = 'Rockies',
    Boston = 'Red Sox',
    Minnesota = 'Twins',
    Milkaukee = 'Brewers',
    Seattle = 'Mariners'
)

Once you've defined a dictionary, you can display its contents,
the same as you can do for a list. All three of the definitions shown above appear
as follows when displayed:

Python

type(MLB_team)
<class 'dict'>

MLB_team
{'Colorado': ' Rockies','Boston':'Red Sox', 'Minnesota':'Twins',
'Milkwaukee': 'Brewers', 'Seattle': 'Mariners'}

The entries in the dictionay display in the order they were defined. But that 
is irrelevant when it comes to retrieving them. Dictionary elements are not accessed
by numerical index:


Accessing Dictionary Values

Of course, dictionary elements must be accessible somehow. If you don't get them by index,
then how do you get them?

A value is retrieved from a dictionary by specifying its corresponding key in square brackets([]):

>>> MLB_team['Minnesota']
'Twins'
>>> MLB_team['Colorado']
'Rockies'

Adding an entry to an existing dictionary is simply a matter of assigning a new key and value:

>>> MLB_team['Kanas City] = 'Royals'

If you want to update an entry, you can just assign a new value to an existing key:

>>> MLB_team['Seattle'] = 'Seahawks'
>>> MLB_team

To delete an entry, use the del statement, specifying the key to delete.

>>>del MLB_team['Seattle']

Dictionary Keys vs. List Indices

You may have noticed that the interpreter raises the same exception,KeyError,
when a dictionary is accessed with either an undefined key or by a numeric index:

Python
>>> MLB_team['Toronto']

In fact, it's the same error. In the latter case,[1] looks like a numerical index,
but it isn't.

You will see later in this tutorial that an object of any immutable type can be used 
as a dictionary key. Accordingly, there is no reason you can't use integers:

Python
d = {0:'a',1:'b',2:'c',3:'d'}
>>>d
{0:'a',1:'b',2:'c',3:'d'}

In the expressions MLB_team[1],d[0],and d[2], the numbers in square brackets
appear as though they might be indices. But they have nothing to do with the order
of the items in the dictionary. Python is interpreting them as dictioanry
keys. If you define this same dictionary in reverse order, you still get the same values
using the same keys:

Note: Although access to items in a dictionary does not depend on order,
Python does guarantee that the order of items in a dictionary is preserved.
When displayed, items will appear in the order they were defined,and 
iteration through the keys will occur in that order as well. Items added to a 
dictionary are added at the end. If items are deleted, the order of the 
remaining items is retained.

You can only count on this preservation of order very recently. It was added as
a part of the Python language specification in version 3.7. However, it was true
as of version 3.6 as well- by happenstance as a result of the implementation
but not guaranteed by the language specification.



Building a Dictionary Incrementally

Defining a dictionary using curly braces and a list of key-value
pairs, as shown above, is fine if you know all the keys and values
in advance. But what if you want to build a dictionary on the fly?


You can start by creating a empty dictionary, which is specified by empty curly
braces. Then you can add new keys and values one at a time:

Person = {}
type(person)

person['fname'] = 'Joe'
person['lname'] = 'Fonebone'
person['age'] = 51
person['spouse'] = 'Edna'
person['children'] = ['ralph','Betty','Joey]
person['pets'] = {'dog':'Fido','cat':'Sox}

Once the dictionary is created in this way, its values
accessed the same way as any other dictionary:

Retrieving the values in the sublist or subdictionary requires an additional
index or key:

person['children'][-1]
'Joey'
person['pets']['cat']
Sox

This example exhibits another feature of dictionaries:
the values contained in the dictionary don't need to be the same type.
In person, some of the values are strings,
one is an integer, one is a list, and one is another dictionary.

Just as the values in a dicitonary don't need to be of the same type,
the keys don't either:

Python
>>> foo = {42: 'aaa', 2.78:'bbb', True:'ccc'}
>>> foo
{42: 'aaa',2.78:'bbb',True:'ccc'}

Here,one of the keys is an integer, one is a float, and one is 
a Boolean. It's not obvious how this would be useful, but you never know.

Notice how versatile Python dictionaries are, In MLB_team, the same piece
of information(the baseball team name) is kept for each of several
different geographical locations. person, on the other hand, stores varying
types of data for a single person.

You can use dicitonaries for a wide range of purposes because there are so few limitations
on the keys and values that are allowed. But there are some. Read on!

Restriction on Dictionary Keys

Almost any type of value can be used as a dictionary key in Python. You just saw this 
example, where integer,float,and Boolean objects are used as keys:


You can even use built-in objects like types and functions:
d = {int:1 , float:2 , bool:3}
>>> d
{<class 'int'>: 1, <class 'float'>:2 , <class 'bool'>: 3}
>>> d[float]
2

However, there are a couple of restrictions that dictionary keys must abide by.

First, a given key can appear in a dictionary only once. Duplicate keys are not 
allowed. A dictionary maps each key to a corresponding value, so it doesn't
make sense to map a particular key more than once.

Secondly, a dictionary key must be of a type that is immutable. You have already
seen example where several of the immutables types you are familiar with --integer,
float,string,and Boolean -- have served as dictionary keys.

A tuple can also be a dictionary key, because tuples are immutables:

d = {(1,1):'a',(1,2):'b',(2,1):'c',(2,2):'d'}
>>>d[(1,1)]
'a'
>>>d[(2,1)]
'c'

(Recall from the discussion on tuples that one 
rationale for using a tuple instead of a list
 is that there are circumstances where an 
 immutable type is required)

 However, neither a list nor another dictionary can serve
 as a dictionary key, because lists and dictionaries are mutable:

 >>> d = {[1,1]: 'a', [1,2]: 'b', [2,1]:'c',[2,2]:'d'}



Note: Why does the error message say "unhashable"?

Technically, it is not quite correct to say an object must be immutable
to be used as a dictionary key. More precisely, an object must be 
hashable,which means it can be passed to a hash function.
A hash function takes data of arbitrary size and maps it to a relatively
simpler fixed-size value called a hash value(or simply hash),which is used for 
table lookup and comparison.

Python's built-in hash() function returns the hash value for an object which is 
hashable,and raises an exception for an object which isn't:

All of the built-in immutable types you have learned about so far are hashable,and
the mutable container types(lists and dictionaries) are not. So for present
purporses, you can think of hashable and immutable as more or less
synonymous.

In future tutorials, you will encounter mutable objects which are also hashable.


Restrictions on Dictionary values 

By contrast, there are no restrictions on dictionary values. Literally none at all. A dictionary
value can be any type of object Python supports, including mutable types like lists and dictionaries,
and user-defined objects, which you will learn about in upcoming tutorials.

There is also no restriction against a particular value appearing in a dictionary multiple times:

Python

>>> d= {0: 'a',1:'a',2:'a',3:'a'}

Operators and Built-in Functions

You have already become familiar with many of the operators and built-in functions
that can be used with strings,lists,and tuples. Some of these work with dictionaries as well.

For example, the in and not in operators return True or False according to whether
the specified operand occurs as a key in the dictionary:

MLB_team = {
    'Colorado' : 'Rockies',
    'Boston'   : 'Red Sox',
    'Minnesota': 'Twins',
    'Milkwaukee': 'Mariners'
}


You can use the in operator together with short-circuit 
evaluation to avoid raising an error when trying to access 
a key that is not in the dicitonary.

The len() function returns number of key-value pairs in a dictionary:

MLB_team = {
    'Colorado' : 'Rockies',
    'Boston'   : 'Red Sox',
    'Minnesota': 'Twins',
    'Milwaukee': 'Brewers',
    'Seattle'  : 'Mariners'
}

Built-in Dictionary Methods

As with strings and lists, there are several built-in methods that can be invoked 
on dictionaries, In fact, in some cases, the list and dictionary methods share
the same name. (In the discussion on object-oriented programming, you will see that it is perfectly
acceptable for different types to have methods with the same name.)

The following is an overview of methods that apply to dictionaries:

d.clear() 

d.clear() empties dictionary d of all key-value pairs:

d.get(<key>[,<default>])

The Python dictionary.get() method provides a convenient way of getting
the values of a key from a dictionary without checking ahead of time whether the key
exists,and without raising an error.
d.get(<key>) searches dictionary d for <key> and returns the associated value if 
it is found. If <key> is not found, it returns None:

if <key> is not found and the optional<default> argument is specified, that value is
returned instead of None:

>>>print(d.get('z',-1))
-1

d.items()
Return a list of key-value pairs in a dictionary

d.items() returns a list of tuples containing the key-value pairs in d.
The first item in each tuple is the key, and the second item is the key's value:

d.keys()
Returns a list of keys in a dictionary.

d.keys() returns a list of all keys in d:

d.values()
Returns a list of values in a dictionary

Any duplicate values in d will be returned as many times as
they occur:


