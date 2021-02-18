## sharing fixture
to share fixture among multiple test files, you need to use a conftest.py

From there , the fixtures can be shared by any test.

Although conftest.py is a Python module, it should not be imported by test files. Don't import conftest from anywhere. The conftest.py file gets read by pytest, and is considered a local plugin, which will make sense once we start talking about plugins in Chapter 5, Plugins . For now, think of tests/conftest.py as a place where we can put fixtures used by all tests under the test directory.

Next, let's rework some our tests for tasks_proj to properly use fixtures.


## Using fixtures for setup and teardown


Most of the tests in the Tasks project will assume that the Tasks database is already set up and
running and ready. And we should clean things up at the end if there is any cleanup needed. And
maybe also disconnect from the database. Luckily, most of this is taken care of within the tasks
code with tasks.start_tasks_db(<directory to store db>, ’tiny’ or ’mongo’) and
tasks.stop_tasks_db(); we just need to call them at the right time, and we need a temporary
directory.


Fortunately, pytest includes a cool fixture called tmpdir that we can use for testing and don't have to worry about cleaning up. It's not magic, just good coding by the pytest folks. (Don't worry; we look at tmpdir and it's session-scoped relative tmpdir_factory in more depth)



When I'm developing fixtures, I like to see what's running and when. Fortunately, pytest provides a command-line flag,
--setup-show, that does just that:

``` shell
PS D:\leisureGit\python\book-pytest\ch3\tasks_proj> pytest --setup-show .\tests\func\test_add.py -k valid_id
========================================================================= test session starts =========================================================================
platform win32 -- Python 3.8.5, pytest-6.2.1, py-1.10.0, pluggy-0.13.1
rootdir: D:\leisureGit\python\book-pytest\ch3\tasks_proj\tests, configfile: pytest.ini
collected 2 items / 1 deselected / 1 selected

tests\func\test_add.py
SETUP    S tmp_path_factory
        SETUP    F tmp_path (fixtures used: tmp_path_factory)
        SETUP    F tmpdir (fixtures used: tmp_path)
        SETUP    F tasks_db (fixtures used: tmpdir)
        func/test_add.py::test_add_returns_valid_id (fixtures used: request, tasks_db, tmp_path, tmp_path_factory, tmpdir).
        TEARDOWN F tasks_db
        TEARDOWN F tmpdir
        TEARDOWN F tmp_path
TEARDOWN S tmp_path_factory

=================================================================== 1 passed, 1 deselected in 0.08s ===================================================================
```


## Using Fixture for test data

Fixtures are a great place to store data to use for testing. You can return anything. Here's a fixture returning a tuple of 
mixed type.



What happens if the assert (or any exception) happens in the fixture?

A couple of things happen. The stack trace shows correctly that the assert happened in the fixture
function. Also, test_other_data is reported not as FAIL, but as ERROR. This distinction is great.
If a test ever fails, you know the failure happened in the test proper, and not in any fixture it
depends on.


But what about the Tasks project? For the Tasks project, we could probably use some data
fixtures, perhaps different lists of tasks with various properties:



### Using multiple Fixtures


You’ve already seen that tmpdir uses tmpdir_factory. And you used tmpdir in our tasks_db
fixture. Let’s keep the chain going and add some specialized fixtures for non-empty tasks
databases:
``` python

@pytest.fixture()
def db_with_3_tasks(tasks_db, tasks_just_a_few):
    """ Connected db with 3 tasks, all unique. """
    for i in tasks_just_a_few:
        tasks.add(i)

@pytest.fixture()
def db_with_multi_per_owner(tasks_db, tasks_mult_per_owner):
    """ Connected db with 9 tasks, 3 owners , all with 3 tasks. """
    for i in tasks_mult_per_owner:
        tasks.add(t)
```
''' These fixtuers all include two fixtures each in their paramter list: tasks_db and a test set. 
The data set is used to add tasks to the database. Now tests can use these when you want the test to start 
from a non-empty database, like this:

'''

## Specifying  Fixture Scope.

Fixtures include an optional paramter called scope, which controls how often a fixture gets set up and torn down. The scope paramter to @pytest.fixture() can have the values of function, class, module, or session. The default scope is function. The tasks_db fixture and all of the fixtures so far don't specify a scope. Therefore, they are functon scope fixtures.


### scope=’function’
    Run once per test function. The setup portion is run before each test using the fixture. The
teardown portion is run after each test using the fixture. This is the default scope used
when no scope parameter is specified.

### scope=’class’
    Run once per test class, regardless of how many test methods are in the class.

### scope=’module’
    Run once per module, regardless of how many test functions or methods or other fixtures
in the module use it.

### scope=’session’
    Run once per session. All test methods and functions using a fixture of session scope share
one setup and teardown call.
Here’s how the scope values look in action:





### Scope is defined with the fixture.

### Fixture can only depend on other fixtures of their same scope or wider. So a function scope fixture can depend on other function scope fixtures.



## Using autouse for Fixtures that always get used 


## Parametrizing Fixtures


In Parametrized Testing, we parametrized tests. We can also parametrize fixtures. We still use our list of tasks, list of task identifiers, and an equivalence function, just as before.

### fixtures definition

``` shell
pytest --fixtures
```


### Parametrizing Fixtures in the Tasks Project

Now, let's see how we can use parametrized fixtures in the Tasks project. So far, we used TinyDB for all of the testing.
But we want to keep our options open until later in the project. Therefore, any code we write, and any tests we write, should work with both TinyDB and with MongoDB.

The decision(in the codee) of which database to use is isolated to the start_tasks_db() call in the tasks_db_session fixture.

