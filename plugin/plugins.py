# plugins.py


import functools
import importlib
from collections import namedtuple
from importlib import resources

# Basic structure for storing information about one plugin

Plugin = namedtuple("Plugin", ("name", "func"))

# Dictionary with information about all registered plugins

_PLUGINS = {}



def register(func):
    """Decorator for registering a new plugin"""
    package, _, plugin = func.__module__.rpartition('.')
    ## where the function is defined.
    pkg_info = _PLUGINS.setdefault(package, {})
    pkg_info[plugin] = Plugin(name=plugin, func=func)
    return func

def names(package):
    """List all plugins in one package"""
    _import_all(package)
    return sorted(_PLUGINS[package])

def get(package, plugin):
    """Get a given plugin"""
    _import(package, plugin)
    return _PLUGINS[package][plugin].func

def call(package, plugin, *args, **kwargs):
    """Call the given plugin"""
    plugin_func = get(package, plugin)
    return plugin_func(*args, **kwargs)

def _import(package, plugin):
    """Import the given plugin file from a package"""
    importlib.import_module(f"{package}.{plugin}")
    
    
    """
    _import() looks deceptively straightforward. It uses importlib
    to import a module. But there are a couple of things also 
    happening in the background:
        1. Python's import system ensures that each plugin is imported only once.
        2. @register decorators defined inside each plugin module register each imported plugin.
        3. In a full implementation, there would be also be some error handling to deal with missing
        plugins.
    """
    
    """ Import a module, The name argument specifies what module to import
    in absolute or relative terms (e.g. either pkg.mod or ..mod). If the name
    is specified in relative terms , then the package argument must be set to the name
    of the package which is to act as the anchor for resolving the package name (e.g.
    import_module('..mod', 'pkg.subpkg) will import pkg.mod)
    
    The import_module() function acts as a simplifying wrapper around importlib.__import__()
    . This means all semantics of the function are derived from importlib.__import__(). The most
    important difference between these two functions is that import_module() returns the specified
    package or module (e.g. pkg.mod), while __import__() returns the top-level package or 
    module (e.g. pkg).
    
    If you are dynamically importing a module that was created since the interpreter began execution
    (e.g. , created a Python source file), you may need to call invalidate_caches() in order for the new
    module to be noticed by the import system.
    """

def _import_all(package):
    """Import all plugins in a package"""
    files = resources.contents(package)
    # Return an iterable over the named items within the package,
    # The iterable returns str resources (e.g. files) and non-resources(e.g. directories)
    # The iterable does not recurse into subdirectories
    
    # package is either a name or a module object which conforms to the Package requirements.
    print(f[:-3] for f in files)
    plugins = [f[:-3] for f in files if f.endswith(".py") and f[0] != "_"]
    for plugin in plugins:
        _import(package, plugin)
        
    """ _import_all() discovers all the plugins within a package.
    Here's how it works:
        1. contents() from importlib.resources lists all the files inside a package.
        2. The results are filtered to find potential plugins.
        3. Each python file not starting with an underscore is imported.
        4. Plugins in any of the files are discovered and registered.
    """
def names_factory(package):
    """Create a names() function for one package"""
    return functools.partial(names, package)
    """ return a new partial object which when called will behave 
    like func called with the positional arguments args and keyword arguments 
    keywords. If more arguments are supplied to the call, they are appended  to args.
    If additional keyword arguments are supplied, they extend and override keywords.
    Roughly equivalent to .
    
    The partial() is used for partial function application which "freezes" some portion
    of a function's arguments and/or keywords resulting in a new object with a simplified signature.
    for example , partial() can be used to create a callable that behaves like the int() function
    where the baes argument defaults to two:
    """
def get_factory(package):
    """Create a get() function for one package"""
    return functools.partial(get, package)

def call_factory(package):
    """Create a call() function for one package"""
    return functools.partial(call, package)