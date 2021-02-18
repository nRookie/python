import plugins

print(__package__)
greetings = plugins.names_factory(__package__)
print(greetings)
""" 
The major proposed change is the introduction of a new module level attribute,
__package__. When it is present, relative imports will be based on this attribute rather than the module 
__name__ attribute
"""


"""
The module's __package__ attribute should be set, its value must be a string,
but it can be the same value as its __name__ . If the attribute is set to None or is missing,
the import system will fit it in with a more appropriate value. when the module is a packge.
its __package__ value should be set to its __name__. when the module is not a package.
__package__ should be set to empty string for top-level modules, or for submodules, to the parent package's 
name. See PEP 366 for further details.
"""

""" So, for a module located in foo/bar/baz.py, __name__ is set to foo.bar.baz,
and __package__ is set to foo.bar , while foo/bar/__init__.py will have foo.bar for both the 
__name__ and __package__ attributes.

"""


greet = plugins.call_factory(__package__)