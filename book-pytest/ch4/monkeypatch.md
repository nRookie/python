## Using monkeypatch


A "monkey patch" is a dynamic modification of a class or module during runtime. During testing, "monkey patching" is a convenient way to take over part of the runtime environment of the code under test and replace either input dependencies or output dependencies with objects or functions that are more convenient for testing. The monkeypatch builtin fixture allows you to do this in the context of a single test. And when the test ends, regardless of pass or fail, the original unpatched is restored, undoing everything changed by the patch. It's all very hand-wavy until we jump into some examples. After looking at the API, we'll look at how monkeypatch is used in test code.


The monkeypatch fixture provides the following functions:


- setattr(target, name, value=<notset>, raising=True): Set an attribute
- delattr(target, name = <notset>, raising =True): Delete an attribute
- setitem(dic, name, value): Set a dictionary entry
- delitem(dic, name, raising=True): Delete an attribute
- setenv(name, value, prepend=None): Set an environmental variable
- delenv(name, raising=True): Delete an environmental variable
- syspath_prepend(path): Prepend path to sys.path, which is Python's list of import locations
- 