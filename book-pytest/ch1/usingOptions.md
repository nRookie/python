## --collect-only

The --collect-only option shows you which tests will be run with the given options and configuration. It's convenient to show this option first so that the output can be used as a reference for the rest of the examples. If you start in the ch1 directory, you should see all of the test functions you've looked at so far in this chapter:



``` python 
PS D:\leisureGit\python\book-pytest\ch1> pytest --collect-only
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1
rootdir: D:\leisureGit\python\book-pytest\ch1
collected 6 items                                                                                                                                                       

<Module test_four.py>
  <Function test_asdict>
  <Function test_replace>
<Module test_one.py>
  <Function test_passing>
<Module test_three.py>
  <Function test_defaults>
  <Function test_member_access>
<Module test_two.py>
  <Function test_failing>

===================================================================== 6 tests collected in 0.04s ======================================================================

```

## -k EXPRESSION

The -k option lets you use an expression to find what test functions to run. Pretty powerful. It can be used as a shortcut to running an individual test if its name is unique, or running a set of tests that have a common prefix or suffix in their names.


``` python
PS D:\leisureGit\python\book-pytest\ch1> pytest -k "asdict or defaults" --collect-only
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1
rootdir: D:\leisureGit\python\book-pytest\ch1
collected 6 items / 4 deselected / 2 selected                                                                                                                           

<Module test_four.py>
  <Function test_asdict>
<Module test_three.py>
  <Function test_defaults>

============================================================= 2/6 tests collected (4 deselected) in 0.04s =============================================================
```
### remove the collect-only
``` python
PS D:\leisureGit\python\book-pytest\ch1> pytest -k "asdict or defaults"
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1
rootdir: D:\leisureGit\python\book-pytest\ch1
collected 6 items / 4 deselected / 2 selected                                                                                                                           

test_four.py .                                                                                                                                                   [ 50%] 
test_three.py .                                                                                                                                                  [100%] 

=================================================================== 2 passed, 4 deselected in 0.05s =================================================================== 
``` 



## -m MARKEXPR

Markers are one of the best ways to mark a subset of your test functions so that they can be run together. As an example, one way to run test_replace() and test_member_access(), even though they are in separate files, is to mark them.

You can use any marker name. Let's say you want to use run_these_please. You'd mark a test using the decorator @pytest.mark.run_these_please, like so.



## -x -exitfirst

Normal pytest behavior is to run every test it finds. If a test function encounters a failing assert or an exception, the execution for that test stops there and the test fails. And then pytest runs the next test. Most of the time, this is what you want. However, especially when debugging a problem, stopping the entire test session immediately when a test fails is the right thing to do. That's what the -x options does.


``` python
PS D:\leisureGit\python\book-pytest\ch1> pytest -x
========================================================================= test session starts =========================================================================
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1
rootdir: D:\leisureGit\python\book-pytest\ch1
collected 6 items

test_four.py ..                                                                                                                                                  [ 33%] 
test_one.py .                                                                                                                                                    [ 50%] 
test_three.py ..                                                                                                                                                 [ 83%] 
test_two.py F                                                                                                                                                    [100%] 

============================================================================== FAILURES =============================================================================== 
____________________________________________________________________________ test_failing _____________________________________________________________________________ 

    def test_failing():
>       assert (1, 2, 3) == (3, 2, 1)
E       assert (1, 2, 3) == (3, 2, 1)
E         At index 0 diff: 1 != 3
E         Use -v to get the full diff

test_two.py:2: AssertionError
======================================================================= short test summary info ======================================================================= 
FAILED test_two.py::test_failing - assert (1, 2, 3) == (3, 2, 1)
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! stopping after 1 failures !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
===================================================================== 1 failed, 5 passed in 0.15s ===================================================================== 
```
## --tb=no

turn off the stack trace.

## --maxfail=num

The -x option stops after one test failure. If you want to let some failures happen, but not a ton, use the --maxfail option to specify how many failures are okay with you.

It's hard to really show this only one failing test in our system so far, but let's look anyway. Since there is only one failure, if we set --maxfail = 2, all of the tests should run, and --maxfail=1 should act just like -x:

``` python
PS D:\leisureGit\python\book-pytest\ch1> pytest --maxfail=2 --tb=no
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1
rootdir: D:\leisureGit\python\book-pytest\ch1
collected 6 items                                                                                                                                                       

test_four.py ..                                                                                                                                                  [ 33%] 
test_one.py .                                                                                                                                                    [ 50%] 
test_three.py ..                                                                                                                                                 [ 83%] 
test_two.py F                                                                                                                                                    [100%] 

======================================================================= short test summary info ======================================================================= 
FAILED test_two.py::test_failing - assert (1, 2, 3) == (3, 2, 1)
===================================================================== 1 failed, 5 passed in 0.06s ===================================================================== 
``` 

## -s and --capture=method

Ths -s flag allows print statements -- or really any output that normally would be printed to stdout--to actually be printed to stdout while tests are running. It is a shortcut for --capture=no. This makes sense once you understand that normally the output is captured on all tests. This make sense once you understand that normally the output is captured on all tests. Failing tests will have the output recored after the tests runs on the assumption that the output will help you understand what went wrong. The -s or --capture=no option runs off output capture. When developing tests, I find it useful to add several print() statements so that I can watch the flow of the test.

Another option that may help you to not need print statement in your code is -l//--showlocals, which prints out the local variables in a test if the test fails.

Other options for capture method are --capture=fd and --captures=sys. The --capture=sys option replaces sys.stdout/stderr with in-mem files. The --capture=fd option points file descriptors 1 and 2 to a temp file.

I'm including descriptions of sys and fd for completeness. But to be honest, I've never needed or used either. I frequently use -s. And to fully describe how -s works, I needed to touch an capture methods.

We don't have any print statements in our tests yet; a demo would be pointless. However, I encourage you to play with this a bit so you see it in action.


## --lf, --last-failed


When one or more tests fails, having a convenient way to run just the failing tests is helpful for debugging. Just use --lf and you're ready to debug.

``` python
PS D:\leisureGit\python\book-pytest\ch1> pytest --lf
========================================================================= test session starts =========================================================================
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1
rootdir: D:\leisureGit\python\book-pytest\ch1
collected 1 item                                                                                                                                                        
run-last-failure: rerun previous 1 failure (skipped 3 files)

test_two.py F                                                                                                                                                    [100%] 

============================================================================== FAILURES =============================================================================== 
____________________________________________________________________________ test_failing _____________________________________________________________________________ 

    def test_failing():
>       assert (1, 2, 3) == (3, 2, 1)
E       assert (1, 2, 3) == (3, 2, 1)
E         At index 0 diff: 1 != 3
E         Use -v to get the full diff

test_two.py:2: AssertionError
======================================================================= short test summary info ======================================================================= 
FAILED test_two.py::test_failing - assert (1, 2, 3) == (3, 2, 1)
========================================================================== 1 failed in 0.12s ==========================================================================
```
## --ff, --failed-first

``` python
PS D:\leisureGit\python\book-pytest\ch1> pytest --ff
========================================================================= test session starts =========================================================================
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1
rootdir: D:\leisureGit\python\book-pytest\ch1
collected 6 items
run-last-failure: rerun previous 1 failure first

test_two.py F                                                                                                                                                    [ 16%] 
test_four.py ..                                                                                                                                                  [ 50%] 
test_one.py .                                                                                                                                                    [ 66%] 
test_three.py ..                                                                                                                                                 [100%] 

============================================================================== FAILURES =============================================================================== 
____________________________________________________________________________ test_failing _____________________________________________________________________________ 

    def test_failing():
>       assert (1, 2, 3) == (3, 2, 1)
E       assert (1, 2, 3) == (3, 2, 1)
E         At index 0 diff: 1 != 3
E         Use -v to get the full diff

test_two.py:2: AssertionError
======================================================================= short test summary info ======================================================================= 
FAILED test_two.py::test_failing - assert (1, 2, 3) == (3, 2, 1)
===================================================================== 1 failed, 5 passed in 0.14s ===================================================================== 
``` 


## -v, --verbose

The -v/--verbose option reports more information than without it. The most obvious different is that each test gets its own line, and the name of the test and the outcome are spelled out instead of indicated with just a dot.

``` python
PS D:\leisureGit\python\book-pytest\ch1> pytest -v --ff --tb=no
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1 -- c:\users\qna\.virtualenvs\ch1-_vxzh-nf\scripts\python.exe
cachedir: .pytest_cache
rootdir: D:\leisureGit\python\book-pytest\ch1
collected 6 items                                                                                                                                                       
run-last-failure: rerun previous 1 failure first

test_two.py::test_failing FAILED                                                                                                                                 [ 16%] 
test_four.py::test_asdict PASSED                                                                                                                                 [ 33%] 
test_four.py::test_replace PASSED                                                                                                                                [ 50%] 
test_one.py::test_passing PASSED                                                                                                                                 [ 66%] 
test_three.py::test_defaults PASSED                                                                                                                              [ 83%] 
test_three.py::test_member_access PASSED                                                                                                                         [100%] 

======================================================================= short test summary info ======================================================================= 
FAILED test_two.py::test_failing - assert (1, 2, 3) == (3, 2, 1)
===================================================================== 1 failed, 5 passed in 0.09s ===================================================================== 
```


## -q, --quiet

The -q/--quiet option is the opposite of -v/--verbose; it decreases the information reported . I like to use it in conjunction with --tb= line, which reports just the failing line of any failing tests.

``` python
PS D:\leisureGit\python\book-pytest\ch1> pytest -q
.....F                                                                                                                                                           [100%] 
============================================================================== FAILURES =============================================================================== 
____________________________________________________________________________ test_failing _____________________________________________________________________________ 

    def test_failing():
>       assert (1, 2, 3) == (3, 2, 1)
E       assert (1, 2, 3) == (3, 2, 1)
E         At index 0 diff: 1 != 3
E         Full diff:
E         - (3, 2, 1)
E         ?  ^     ^
E         + (1, 2, 3)
E         ?  ^     ^

test_two.py:2: AssertionError
======================================================================= short test summary info ======================================================================= 
FAILED test_two.py::test_failing - assert (1, 2, 3) == (3, 2, 1)
1 failed, 5 passed in 0.12s
```




The -q option makes the output pretty terse, but it’s usually enough. We’ll use the -q option
frequently in the rest of the book (as well as --tb=no) to limit the output to what we are
specifically trying to understand at the time.

## -l, showlocals

If you use the -l/--showlocals option, local variables and their values are displayed with tracebacks for failing tests.

So far, we don't have any failing tests that have local variables. If I take the test_replace() test and change t_expected = Task('finish book', 'brian', True, 10) to t_expected = Task('finish book', 'brian', True, 11)

the 10 and 11 should cause a failure. Any change to the expected value will cause a failure. But this is enough to demonstrate the command-line option --l/--showlocals:

PS D:\leisureGit\python\book-pytest\ch1> pytest  -l .\test_four_failed.py
========================================================================= test session starts =========================================================================
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1
rootdir: D:\leisureGit\python\book-pytest\ch1
collected 2 items

test_four_failed.py .F                                                                                                                                           [100%]

============================================================================== FAILURES =============================================================================== 
____________________________________________________________________________ test_replace _____________________________________________________________________________ 

    def test_replace():
        """ replace() should change passed in fields. """
        t_before = Task('finish book', 'brian', False)
        t_after = t_before._replace(id=10, done=True)
        t_expected = Task('finish book', 'brian', True, 11)
>       assert t_after == t_expected
E       AssertionError: assert Task(summary=...e=True, id=10) == Task(summary=...e=True, id=11)
E
E         Omitting 3 identical items, use -vv to show
E         Differing attributes:
E         ['id']
E
E         Drill down into differing attribute id:
E           id: 10 != 11...
E
E         ...Full output truncated (2 lines hidden), use '-vv' to show

t_after    = Task(summary='finish book', owner='brian', done=True, id=10)
t_before   = Task(summary='finish book', owner='brian', done=False, id=None)
t_expected = Task(summary='finish book', owner='brian', done=True, id=11)

test_four_failed.py:23: AssertionError
======================================================================= short test summary info ======================================================================= 
FAILED test_four_failed.py::test_replace - AssertionError: assert Task(summary=...e=True, id=10) == Task(summary=...e=True, id=11)
===================================================================== 1 failed, 1 passed in 0.13s ===================================================================== 


## --tb=style

The --tb=style option modifies the way traceback for failures are output. When a test fails, pytest lists the failures and what's called a traceback, which shows you the exact line where the failure occurred. Although tracebacks are helpful most of time, there may be times when they get annoying. That's where the --tb=style option comes in handy. The styles I find useful are **short**, **line** and **no**. **short** prints just the assert line and the E evaluated line with no context; **line** keeps the failure to one line; **no** removes the traceback entirely.

### --tb=no

``` python
PS D:\leisureGit\python\book-pytest\ch1> pytest --tb=no
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1
rootdir: D:\leisureGit\python\book-pytest\ch1
collected 8 items                                                                                                                                                       

test_four.py ..                                                                                                                                                  [ 25%] 
test_four_failed.py .F                                                                                                                                           [ 50%] 
test_one.py .                                                                                                                                                    [ 62%] 
test_three.py ..                                                                                                                                                 [ 87%] 
test_two.py F                                                                                                                                                    [100%] 

======================================================================= short test summary info ======================================================================= 
FAILED test_four_failed.py::test_replace - AssertionError: assert Task(summary=...e=True, id=10) == Task(summary=...e=True, id=11)
FAILED test_two.py::test_failing - assert (1, 2, 3) == (3, 2, 1)
===================================================================== 2 failed, 6 passed in 0.10s ===================================================================== 
```

### tb=line

``` python
PS D:\leisureGit\python\book-pytest\ch1> pytest --tb=line
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1
rootdir: D:\leisureGit\python\book-pytest\ch1
collected 8 items                                                                                                                                                       

test_four.py ..                                                                                                                                                  [ 25%] 
test_four_failed.py .F                                                                                                                                           [ 50%] 
test_one.py .                                                                                                                                                    [ 62%] 
test_three.py ..                                                                                                                                                 [ 87%] 
test_two.py F                                                                                                                                                    [100%] 

============================================================================== FAILURES =============================================================================== 
D:\leisureGit\python\book-pytest\ch1\test_four_failed.py:23: AssertionError: assert Task(summary=...e=True, id=10) == Task(summary=...e=True, id=11)
D:\leisureGit\python\book-pytest\ch1\test_two.py:2: assert (1, 2, 3) == (3, 2, 1)
======================================================================= short test summary info ======================================================================= 
FAILED test_four_failed.py::test_replace - AssertionError: assert Task(summary=...e=True, id=10) == Task(summary=...e=True, id=11)
FAILED test_two.py::test_failing - assert (1, 2, 3) == (3, 2, 1)
===================================================================== 2 failed, 6 passed in 0.10s =====================================================================

```


### pytest --tb=short

``` python

PS D:\leisureGit\python\book-pytest\ch1> pytest --tb=short
========================================================================= test session starts =========================================================================
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1
rootdir: D:\leisureGit\python\book-pytest\ch1
collected 8 items

test_four.py ..                                                                                                                                                  [ 25%] 
test_four_failed.py .F                                                                                                                                           [ 50%]
test_one.py .                                                                                                                                                    [ 62%] 
test_three.py ..                                                                                                                                                 [ 87%]
test_two.py F                                                                                                                                                    [100%] 

============================================================================== FAILURES =============================================================================== 
____________________________________________________________________________ test_replace _____________________________________________________________________________ 
test_four_failed.py:23: in test_replace
    assert t_after == t_expected
E   AssertionError: assert Task(summary=...e=True, id=10) == Task(summary=...e=True, id=11)
E     
E     Omitting 3 identical items, use -vv to show
E     Differing attributes:
E     ['id']
E     
E     Drill down into differing attribute id:
E       id: 10 != 11...
E     
E     ...Full output truncated (2 lines hidden), use '-vv' to show
____________________________________________________________________________ test_failing _____________________________________________________________________________ 
test_two.py:2: in test_failing
    assert (1, 2, 3) == (3, 2, 1)
E   assert (1, 2, 3) == (3, 2, 1)
E     At index 0 diff: 1 != 3
E     Use -v to get the full diff
======================================================================= short test summary info ======================================================================= 
FAILED test_four_failed.py::test_replace - AssertionError: assert Task(summary=...e=True, id=10) == Task(summary=...e=True, id=11)
FAILED test_two.py::test_failing - assert (1, 2, 3) == (3, 2, 1)
===================================================================== 2 failed, 6 passed in 0.16s =====================================================================
```


pytest --tb=long will show you the most exhaustive, informative traceback possible. pytest --
tb=auto will show you the long version for the first and last tracebacks, if you have multiple
failures. This is the default behavior. pytest --tb=native will show you the standard library
traceback without any extra information.


## --duration=N


The --durations=N option is incredibly helpful when you're trying to speed up your test suite. It doesn't change how your tests are run; it reports the slowest N number of tests/setups/teardowns after the tests run. If you pass in --durations=0, it reports everything in order of slowest to fastest.


``` python

PS D:\leisureGit\python\book-pytest\ch1> pytest --durations=3 .\test_four.py .\test_three.py
========================================================================= test session starts ========================================================================= 
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1
rootdir: D:\leisureGit\python\book-pytest\ch1
collected 4 items                                                                                                                                                       

test_four.py ..                                                                                                                                                  [ 50%] 
test_three.py ..                                                                                                                                                 [100%] 

========================================================================= slowest 3 durations ========================================================================= 
1.00s call     test_four.py::test_asdict

(2 durations < 0.005s hidden.  Use -vv to show these durations.)
========================================================================== 4 passed in 1.04s ========================================================================== 
``` 


The slow test with the extra sleep shows up right away with the label call, followed by setup and
teardown. Every test essentially has three phases: call, setup, and teardown. Setup and teardown
are also called fixtures and are a chance for you to add code to get data or the software system
under test into a precondition state before the test runs, as well as clean up afterwards if
necessary. I cover fixtures in depth in Chapter 3

