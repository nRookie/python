## The Python Mock Library
### ref 
https://realpython.com/courses/python-mock-object-library/

The python mock object library is unittest.mock. It provides an easy way to introduce mocks into your tests.



unittest.mock provides a class called Mock which you will use to imitate real objects in your code base. Mock
offers incredible flexibility and insightful data. This, along with its subclasses, will meet most python mocking needs that you will face in your tests.

The library also provides a function, called patch(), which replaces the real objects in your code with Mock instance. You can patch() as either a decorator or a context manager, giving you control over the scope in which the object will be mocked. Once the designated scope exits, patch() will clean up your code by replacing the mocked objects with their original counterparts.


Finally, unittest.mock provides solutions for some of the issues inherent in mocking objects.

Now, you have a better understanding of what mocking is and the library you'll be using to do it.
Let's dive in and explore what features and functionalities unittest.mock offers.


``` python
from unittest.mock import Mock
mock = Mock()
mock

```

Now, you are able to substitute an object in your code with your new Mock. You can do this by passing it as an argument to a function or by redefining another object:

``` python
# Pass mock as an argument to do_something()
do_something(mock)

# Patch the json library
json = mock
```

When you substitute an object in your code, the Mock must look like the real object it is replacing. Otherwise, your code will not be able to use the Mock in place of the original object.

For example, if you are mocking the json library and your program calls dumps(), then your Python mock object must also contain dumps().

Next, you’ll see how Mock deals with this challenge.



### Lazy Attributes and Methods

A mock must simulate any object that it replaces. To achieve such flexibility, it creates its attributes when you access them:

``` python
mock.some_attribute
mock.do_something
```

Since Mock can create arbitrary attributes on the fly  , it is suitable to replace any object.

Using an example from earlier, if you're mocking the json library and you call dumps(), the Python mock object
will create the method so that its interface can match the library's interface.

``` python
json = Mock()
json.dumps()
```


1. Notice two key characteristics of this mocked method requires no arguments. In fact, it will accept any arguments that you pass to it.

2. The return value of dumps() is also a Mock. The capability of Mock to recursively define other mock allows for you to use mocks in complex situation.

``` python
json = Mock()
json.loads('{"k":"v"}').get('k')
```

because the return value of each mocked method is also a Mock, you can use your mocks in a multitude of ways.

Mocks are flexible, but they're also informative. Next, you'll learn how you can uses mocks to understand your code better.


## Configuring Your Mock

You can configure a Mock to set up some of the object's behaviors. Some configurable members include .side_effect, .return_value,
and .name. You configure a Mock when you create one or when you use .configure_mock().


You can configure a Mock by specifying certain attributes when you initialize an object:

``` python
>>> mock = Mock(side_effect=Exception)
>>> mock()
Traceback (most recent call last):
  File "<stdin>", line 1, in <module>
  File "/usr/local/Cellar/python/3.6.5/Frameworks/Python.framework/Versions/3.6/lib/python3.6/unittest/mock.py", line 939, in __call__
    return _mock_self._mock_call(*args, **kwargs)
  File "/usr/local/Cellar/python/3.6.5/Frameworks/Python.framework/Versions/3.6/lib/python3.6/unittest/mock.py", line 995, in _mock_call
    raise effect
Exception

>>> mock = Mock(name='Real Python Mock')
>>> mock
<Mock name='Real Python Mock' id='4434041432'>

>>> mock = Mock(return_value=True)
>>> mock()
True
```

While .side_effect and .return_value can be set on the Mock instance, itself, other attributes like .name can only
be set through .__init__() or .configure_mock(). If you try to set the .name of the Mock on the instance, you will get a different result:

``` python
>>> mock = Mock(name='Real Python Mock')
>>> mock.name

<Mock name = 'Real Python Mock.name' id = '4434041544'>

>>> mock = Mock()
>>> mock.name = 'Real Python Mock'
>>> mock.name
'Real Python Mock'
```

.name is a common attribute for objects to use. So, Mock doesn't let you set that value on the instancein the same way you can with .return_value or .side_effect. If you access mock.name you will create a .name attribute instead of configuring your mock.

You can configure an existing Mock using .configure_mock():

``` python
>>> mock = Mock()
>>> mock.configure_mock(return_value=True)
>>> mock()
True
```

By unpacking a dictionary into either .configure_mock() or Mock.__init__(), you can even configure your Python mock object’s attributes. Using Mock configurations, you could simplify a previous example:

``` python
# Verbose, old Mock
response_mock = Mock()
response_mock.json.return_value = {
    '12/25': 'Christmas',
    '7/4': 'Independence Day',
}

# Shiny, new .configure_mock()
holidays = {'12/25': 'Christmas', '7/4': 'Independence Day'}
response_mock = Mock(**{'json.return_value': holidays})
```

Now, you can create and configure python mock objects. You can also use mocks to control the behavior
of your application. So far, you've used mocks as arguments to functions or patching objects in the same module as your tests.



Next, you’ll learn how to substitute your mocks for real objects in other modules.


## Patch()



unittest.mock provides a powerful mechanism for mocking objects, called patch(), which looks up an object in a given module and replaces that object with a Mock.

Usually, you use patch() as a decorator or a context manager to provide a scope in which you will mock the target object.

### patch() as  Decorator.

If you want to mock an object for the duration of your entire test function, you can use patch as a function decorator.

To see how it works, reorganize your my_calendar.py file by putting the logic and tests into separate files:



## patch() as a Context Manager


Sometimes, you'll want to use patch() as a context manager rather than a decorator. Some reasons why you
might prefer a context manager include the following:

- You only want to mock an object for a part of the test scope.
- You are already using too many decorators or parameters, which hurts your test's readability.

``` python
import unittest
from my_calendar import get_holidays
from requests.exceptions import Timeout
from unittest.mock import patch


class TestCalendar(unittest.TestCase):
    def test_get_holidays_timeout(self):
        with patch('my_calendar.requests') as mock_requests:
            mock_requests.get.side_effect = Timeout
            with self.assertRaises(Timeout):
                get_holidays()
                mock_requests.get.assert_called_once()
```

When the test exits the with statement, patch() replaces the mocked object with the original.

Until now, you've mocked complete objects, but sometimes you'll only want to mock a part of an object.


## Patching an Object's Attributes.

Let's say you only want to mock one method of an object instead of the entire object. You can do so by using
patch.object().


For example, test_get_holidays_timeout() really only needs to mock requests.get() and set its .side_effect to Timeout:


``` python
import unittest
from my_calendar import requests, get_holidays
from unitttest.mock import patch

class TestCalendar(unittest.TestCase):
    @patch.object(request, 'get', side_effect=requests.exceptions.Timeout)
    def test_get_holidays_timeout(self, mock_requests):
        with self.assertRaises(requests.exceptions.Timeout):
            get_holidays()

if __name__ == '__main__':
    unittest.main()
```

In this example, you've mocked only get() rather than all of requests. Every other attribute remains the same.

object() takes the same configuration parameters that patch() does. But instead of passing the target's path, you provide the target object, itself, as the first parameter. The second parameter is the attribute of the target object that you are trying to mock. You can also use object() as a context manager like patch().


Learning how to use patch() is critical to mocking objects in other modules. However, sometimes it's not obvious what the target object's path is.



### Where to Patch

Knowing where to tell patch() to look for the object you want mocked is important because if you choose the wrong target location, the result of patch() could be something you didn't expect.

Let's say you are mocking is_weekday() in my_calendar.py using patch():

``` python
>>> import my_calendar
>>> from unittest.mock import patch
>>> with patch('my_calendar.is_weekday'):
...  my_calendar.is_weekday()
...
<MagicMock name='is_weekday()' id='4336501256'>
```

First, you import my_calendar.py. Then you patch is_weekday(), replacing it with a Mock.
Great! This is working as expected.

Now, let's change this example slightly and import the function directly:

``` python
>>> from my_calendar import is_weekday
>>> from unittest.mock import patch

>>> with patch('my_calendar.is_weekday'):
...     is_weekday()
...
False
```


``` Note
Note: Depending on what day you are reading this tutorial ,your console output may read True or False,
The important thing is that the output is not a Mock like before.
```

Notice that even though the target location you passed to patch() did not change , the result of calling is_weekday()
is different. The difference is due to the change in how you imported the function.

from my_calendar import is_weekday binds the real function to the local scope. So, even though 
you patch() the function later, you ignore the mock because you already have a local reference to the un-mocked function.

A good rule of thumb is to patch() the object where it is looked up.

In the first example, mocking 'my_calendar.is_weekday()' works because you look up the function in the my_calendar module. In the second example, you have a local reference to is_weekday(). Since you use the function found in the local scope, you should mock the local function:

``` python
>>> from unittest.mock import patch
>>> from my_calendar import is_weekday

>>> with patch('__main__.is_weekday'):
...     is_weekday() 
...
<MagicMock name='is_weekday()' id='4502362992'>

```

Now, you have a firm grasp on the power of patch(). You've seen how to patch() objects and attributes 
as well as where to patch them.



Next, you'll see some common problems inherent in object mocking and solutions that unittest.mock provides.

## Common Mocking Problems


Mocking objects can introduce several problems into your tests. Some problems are inherent in mocking while 
others are specific to unitest.mock. Keep in mind that there are other issues with mocking that are not mentioned in this tutorial.

The ones covered here are similar to each other in that the problem they cause is fundamentally the same. In each case, the test assertions are irrelevant. Though the intention of each mock is valid, the mocks themselves are not.

### changes to Object interfaces and Misspellings

Classes and function definitions change all the time. When the interface of an object changes, any tests replying on a Mock of that object may become irrelevant.

For example, you rename a method but forget that a test mocks taht method and invokes .assert_not_called(). After the change, .assert_not_called() is still True. The assertion is not useful, though, because the method no longer exists.


Irrelevant tests may not sound critical , but if they are your only tests and you assume that they work properly, the situation could be disastrous for your application.

A problem specific to Mock is that a misspelling can break a test. Recall that a Mock creates 
its interface when you access its members. So, you will inadvertently create a new attribute if you misspell its name.

If you call .asert_called() instead of .assert_called(), your test will not raise an AssertionError. This is because you've created a new method on the Python mock object named .asert_called() instead of evaluating an actual assertion.

``` Note
Interestingly, assret is a special misspelling of assert. If you try to access an attribute that starts with assret (or assert), Mock will automatically raise an AttributeErorr.
```
These problems occur when you mock objects within your own codebase. A different problem arises when you mock objects interacting with external codebases.


### changes to External Dependencies

Imagine again that your code makes a request to an external API. In this case, the external dependency is the API which is susceptible to change without your consent.

On one hand, unit tests isolated components of code. So, mocking the code that makes the request helps you to test your isolated components under controlled conditions. However, it also presents a potential problem.


If an external dependency changes its interface, your python mock objects will become invalid. If this happens (and the interface change is a breaking one), your tests will pass because your mock objects have masked the change, but your production code will fail.

Unfortunately, this is not a problem tht unittest.mock provides a solution for. You must exercise judgment when mocking external dependencies.

All three of these issues can cause test irrelevancy and potentially costly issues because they threaten the integrity of your mocks. unittest.mock gives you some tools for dealing with these problems.

### Avoiding Common Problems Using specificaitons.

As mentioned before, if you change a class or function definition or you misspell a Python mock object's attribute,
you can cause problems with your tests.

These problems occur because Mock creates attributes and methods when you access them. The answer to these issues is to prevent Mock from creating attributes that don't conform to the object you're trying to mock.


When configuring a Mock, you can pass an object specification to the spec parameter. The spec parameter accepts a list of names or another object and defines the mock's interface. If you attempt to access an attribute that does not belong to the specification, Mock will raise an AttributeError.


``` python
>>> from unittest.mock import Mock
>>> calendar = Mock(spec=['is_weekday', 'get_holidays'])
>>> calendar.is_weekday()
<Mock name ='mock.is_weekday()' id ='49432492923'>

>>> calendar.create_event()
Traceback (most recent call last):
  File "<stdin>", line 1, in <module>
  File "/usr/local/Cellar/python/3.6.5/Frameworks/Python.framework/Versions/3.6/lib/python3.6/unittest/mock.py", line 582, in __getattr__
    raise AttributeError("Mock object has no attribute %r" % name)
AttributeError: Mock object has no attribute 'create_event'

```

.is_weekday() is available to calendar because you configured calendar to match the my_calendar module’s interface.

Furthermore, unittest.mock provides convenient methods of automatically specifying a Mock instance’s interface.

One way to implement automatic specifications is create_autospec:


``` python
>>> import my_calendar
>>> from unittest.mock import create_autospec

>>> calendar = create_autospec(my_calendar)
>>> calendar.is_weekday()
<MagicMock name='mock.is_weekday()' id='4579049424'>
>>> calendar.create_event()
Traceback (most recent call last):
  File "<stdin>", line 1, in <module>
  File "/usr/local/Cellar/python/3.6.5/Frameworks/Python.framework/Versions/3.6/lib/python3.6/unittest/mock.py", line 582, in __getattr__
    raise AttributeError("Mock object has no attribute %r" % name)
AttributeError: Mock object has no attribute 'create_event'
```

Like before, calendar is a Mock instance whose interface matches my_calendar. If you’re using patch(), you can send an argument to the autospec parameter to achieve the same result:


``` python

>>> import my_calendar
>>> from unittest.mock import patch

>>> with patch('__main__.my_calendar', autospec=True) as calendar:
...     calendar.is_weekday()
...     calendar.create_event()
...
<MagicMock name='my_calendar.is_weekday()' id='4579094312'>
Traceback (most recent call last):
  File "<stdin>", line 1, in <module>
  File "/usr/local/Cellar/python/3.6.5/Frameworks/Python.framework/Versions/3.6/lib/python3.6/unittest/mock.py", line 582, in __getattr__
    raise AttributeError("Mock object has no attribute %r" % name)
AttributeError: Mock object has no attribute 'create_event'
```