"""Test the tasks.add() API function."""

import pytest
import tasks
from tasks import Task


def test_add_returns_valid_id(tasks_db):
    """tasks.add(<valid task>) should return an integer."""
    # GIVEN an initialized tasks db
    # WHEN a new task is added
    # THEN returned task_id is of type int
    new_task = Task('do something')
    task_id = tasks.add(new_task)
    assert isinstance(task_id, int)


@pytest.mark.smoke
def test_added_task_has_id_set():
    """Make sure the task_id field is set by tasks.add()."""
    # GIVEN an initialized tasks db
    #   AND a new task is added
    new_task = Task('sit in chair', owner='me', done=True)
    task_id = tasks.add(new_task)

    # WHEN task is retrieved
    task_from_db = tasks.get(task_id)

    # THEN task_id matches id field
    assert task_from_db.id == task_id


def test_add_increases_count(db_with_3_tasks):
    """ Test tasks.add() affect on tasks.count(). """
    # GVIEN a db with 3 tasks
    # WHEN another task is added
    tasks.add(Task('throw a party'))
    # THEN the count increases by 1
    assert tasks.count() == 4


""" autouse as used in our test indicates that all tests in this file will use the fixture. The code before the yield
runs before each test; the code after the yield runs after the test. The yield can return data to the test if desired.
"""

""" This also demonstrates one of the great reasons to use fixtures: to focus the test on what you're actually testing. not on what 
you had to do to get ready for the test. I like using comments for GIVEN/WHEN/THEN and trying to push as much GIVEN into fixtures
for two reasons. First , it makes the test more readable and, therefore, more maintainable. Second, an assert or exception
in the fixture results in an ERROR, while an assert or exception in a test function results in a FAIL. I don't want test_add_increases_count() to FAIL
if database initialization failed."""