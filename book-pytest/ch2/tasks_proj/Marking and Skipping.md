## Marking

pytest provides a cool mechanism to let you put markers on test functions. A test can have more than one marker, and a marker can be on multiple tests.


Markers make sense after you see them in action. Let's say we want to run a subset of our tests as a quick "smoke test" to get a sense for whether or not there is some major break in the system. Smoke tests are by convention not all-inclusive, thorough test suites, but a select subset that can be run quickly and give a developer a decent idea of the health of all parts of the system.

To add a smoke test suite to the Tasks project, we can add @mark.pytest.smoke to some of the tests.


(note that the markers smoke and
get aren’t built into pytest; I just made them up):

### run those tests that are marked with -m marker_name

``` python
PS D:\leisureGit\python\book-pytest\ch2\tasks_proj> pytest -v -m 'smoke' .\tests\func\test_api_exceptions.py
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1 -- c:\users\qna\.virtualenvs\book-pytest-c9u1pnoz\scripts\python.exe
cachedir: .pytest_cache
rootdir: D:\leisureGit\python\book-pytest\ch2\tasks_proj\tests, configfile: pytest.ini
collected 7 items / 5 deselected / 2 selected                                                                                                                           

tests\func\test_api_exceptions.py::test_list_raises PASSED                                                                                                       [ 50%] 
tests\func\test_api_exceptions.py::test_get_raises PASSED                                                                                                        [100%] 

=================================================================== 2 passed, 5 deselected in 0.05s =================================================================== 
PS D:\leisureGit\python\book-pytest\ch2\tasks_proj> 
``` 


``` python
PS D:\leisureGit\python\book-pytest\ch2\tasks_proj> pytest -v -m 'get' .\tests\func\test_api_exceptions.py
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1 -- c:\users\qna\.virtualenvs\book-pytest-c9u1pnoz\scripts\python.exe
cachedir: .pytest_cache
rootdir: D:\leisureGit\python\book-pytest\ch2\tasks_proj\tests, configfile: pytest.ini
collected 7 items / 6 deselected / 1 selected                                                                                                                           

tests\func\test_api_exceptions.py::test_get_raises PASSED                                                                                                        [100%] 

=================================================================== 1 passed, 6 deselected in 0.03s =================================================================== 
PS D:\leisureGit\python\book-pytest\ch2\tasks_proj> 
```

``` python
PS D:\leisureGit\python\book-pytest\ch2\tasks_proj> pytest -v -m 'get and get' .\tests\func\test_api_exceptions.py
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1 -- c:\users\qna\.virtualenvs\book-pytest-c9u1pnoz\scripts\python.exe
cachedir: .pytest_cache
rootdir: D:\leisureGit\python\book-pytest\ch2\tasks_proj\tests, configfile: pytest.ini
collected 7 items / 6 deselected / 1 selected                                                                                                                           

tests\func\test_api_exceptions.py::test_get_raises PASSED                                                                                                        [100%] 

=================================================================== 1 passed, 6 deselected in 0.03s =================================================================== 
PS D:\leisureGit\python\book-pytest\ch2\tasks_proj> 
``` 

``` python
PS D:\leisureGit\python\book-pytest\ch2\tasks_proj> pytest -v -m 'get and not get' .\tests\func\test_api_exceptions.py
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1 -- c:\users\qna\.virtualenvs\book-pytest-c9u1pnoz\scripts\python.exe
cachedir: .pytest_cache
rootdir: D:\leisureGit\python\book-pytest\ch2\tasks_proj\tests, configfile: pytest.ini
collected 7 items / 7 deselected                                                                                                                                        

======================================================================== 7 deselected in 0.04s ======================================================================== 
PS D:\leisureGit\python\book-pytest\ch2\tasks_proj> 
```


## Skipping tests


while the markers discussed in Marking Test Functions . were names of your own choosing, pytest includes a few helpful builtin markers: skip, skipif, and xfail, and xfail. I'll discuss skip and skipif in this section, and xfail in the next.


The skip and skipif markers enable you to skip tests you don't want to run. For example, let's say we weren't sure how tasks.unique_id() was supposed to work. Does each call to it return a different number ? Or is it just a number that doesn't exist in the database already ?

First, let's write a test (note that the initialized_tasks_db fixture is in this file, too; it's just not shown here):





``` python
==================================================================== 1 passed, 1 skipped in 0.14s ===================================================================== 
PS D:\leisureGit\python\book-pytest\ch2\tasks_proj> pytest -v -rs  .\tests\func\test_unique_id_3.py
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1 -- c:\users\qna\.virtualenvs\book-pytest-c9u1pnoz\scripts\python.exe
cachedir: .pytest_cache
rootdir: D:\leisureGit\python\book-pytest\ch2\tasks_proj\tests, configfile: pytest.ini
collected 2 items                                                                                                                                                       

tests\func\test_unique_id_3.py::test_unique_id_1 SKIPPED (not supported until version 0.2.0)                                                                     [ 50%] 
tests\func\test_unique_id_3.py::test_unique_id_2 PASSED                                                                                                          [100%] 

======================================================================= short test summary info ======================================================================= 
SKIPPED [1] tests\func\test_unique_id_3.py:8: not supported until version 0.2.0
==================================================================== 1 passed, 1 skipped in 0.09s ===================================================================== 
```


``` shell
pytest --help

-r chars
show extra test summary info as specified by chars
(f)ailed, (E)error, (s)skipped, (x)failed, (X)passed,
(p)passed, (P)passed with output, (a)all except pP.

```

## Marking Tests as Expecting to Fail


With the skipif markers, a test isn't even attempted if skipped. With the xfail marker,
we are telling pytest to run a test function, but that we expect it to fail. Let's modify our 
unique_id() test again() to use xfail:

``` python
PS D:\leisureGit\python\book-pytest\ch2\tasks_proj> pytest -v -s  .\tests\func\test_unique_id_4.py
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1 -- c:\users\qna\.virtualenvs\book-pytest-c9u1pnoz\scripts\python.exe
cachedir: .pytest_cache
rootdir: D:\leisureGit\python\book-pytest\ch2\tasks_proj\tests, configfile: pytest.ini
collected 4 items                                                                                                                                                       

tests\func\test_unique_id_4.py::test_unique_id_1 XFAIL (not supported until version 0.2.0)
tests\func\test_unique_id_4.py::test_unique_id_is_a_duck XFAIL
tests\func\test_unique_id_4.py::test_unique_id_not_a_duck XPASS
tests\func\test_unique_id_4.py::test_unique_id_2 PASSED

=============================================================== 1 passed, 2 xfailed, 1 xpassed in 0.22s =============================================================== 
```

