import pytest
import tasks
from tasks import Task

# @pytest.fixture()
# def tasks_db(tmpdir):
#     """ Connect to db before tests, disconnect after."""
#     # Setup : start db
#     tasks.start_tasks_db(str(tmpdir), 'tiny')
    
#     yield # This is where the testing happens
    
#     # Teardown: stop db
#     tasks.stop_tasks_db()

@pytest.fixture()
def tasks_db(tasks_db_session):
    """ An empty tasks db. """
    tasks.delete_all()


""" The value of tmpdir isn't a string -- it's an object that represents a directory. However, it implements __str__,
so we can use str() to get a string to pass to start_task_db(). We're still using 'tiny' for tinyDB, for now."""



@pytest.fixture()
def tasks_just_a_few():
    """ All summaries and owners are unique. """
    return (
        Task('Write some code', 'Brian', True),
        Task("Code review Brian's code", 'Katie', False),
        Task('Fix what Brian did', 'Michelle', False)
    )

@pytest.fixture()
def tasks_mult_per_owner():
    """ several owners with several tasks each."""
    return (
        Task( 'Use an emoji' , 'Raphael' ),
        Task( 'Move to Berlin' , 'Raphael' ),
        Task( 'Create' , 'Michelle' ),
        Task( 'Inspire' , 'Michelle' ),
        Task( 'Encourage' , 'Michelle' ),
        Task( 'Do a handstand' , 'Daniel' ),
        Task( 'Write some books' , 'Daniel' ),
        Task( 'Eat ice cream' , 'Daniel' )
    )


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

''' These fixtuers all include two fixtures each in their paramter list: tasks_db and a test set. 
The data set is used to add tasks to the database. Now tests can use these when you want the test to start 
from a non-empty database, like this:

'''




# @pytest.fixture(scope='session')
@pytest.fixture(scope='session', params=['tiny', 'mongo'])
def tasks_db_session(tmpdir_factory):
    """ Connect to db before tests, disconnect after. """
    temp_dir = tmpdir_factory.mktemp('temp')
    tasks.start_tasks_db(str(temp_dir), request.param)
    yield
    tasks.stop_tasks_db()

