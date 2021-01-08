Sending some values through a function and checking the output ot make sure it's correct is a common pattern in software testing. However, calling a function once with one set of values and one check for correctness isn't enough to fully test most functions. Parametrized testing is a way to send multiple sets of data through the same test and have pytest report if any of the sets failed.

To help understand the problem parameterized testing is trying to solve, let's take a simple test for add():


``` python
@pytest.mark.parametrize('task',
                         [Task('sleep', done=True),
                          Task('wake', 'brian'),
                          Task('breathe', 'BRIAN', True),
                          Task('exercise', 'BrIaN', False)])
def test_add_2(task):
    """Demonstrate parametrize with one parameter."""
    task_id = tasks.add(task)
    t_from_db = tasks.get(task_id)
    assert equivalent(t_from_db, task)
```



The first argument to parametrize() is a string with a comma-separated list of names—’task’, in
our case. The second argument is a list of values, which in our case is a list of Task objects.
pytest will run this test once for each task and report each as a separate test: