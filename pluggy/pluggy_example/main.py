import pluggy

hookspec = pluggy.HookspecMarker("myproject")
hookimpl = pluggy.HookimplMarker("myproject")


class MySpec:
    """A hook specification namespace. """


    @hookspec
    def myhook(self, arg1, arg2):
        """My special little hook that you can customize. """


class Plugin_1:
    """ A hook implementation namespace. """
    
    
    @hookimpl
    def myhook(self, arg1, arg2):
        print("inside Plugin_1.myhook()")
        return arg1 + arg2
    
class Plugin_2:
    """A 2nd hook implementation namespace. """
    @hookimpl
    def myhook(self, arg1, arg2):
        print("inside Plugin_2.myhook()")
        return arg1 - arg2


# create a manager and add the spec
pm = pluggy.PluginManager("myproject") 
""" PluginManager: Core PluginManager class which manages registration of plugin objects and 
1:N hook calling.

You can register new hooks by calling add_hookspecs(module_or_class). You can register plugin objects(which contain hooks)
by calling register(plugin). The PluginManager is initialized with a prefix that is searched for in the names of the dict of registered
plugin objects.

"""
pm.add_hookspecs(MySpec)
""" add new hook specifications defined in the given module_or_class. Functions are recognized if they have been decorated accordingly.
"""

# register plugins
pm.register(Plugin_1())
""" register a plugin and return its canonical name or None if the name is blocked from registering.
Raise a ValueError if the plugin is already registered.
"""
pm.register(Plugin_2())
# call our 'myhook' hook
results = pm.hook.myhook(arg1=1, arg2=2)
print(results)
