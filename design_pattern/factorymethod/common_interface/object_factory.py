class ObjectFactory:
    def __init__(self):
        self._builders = {}

    def register_builder(self, key, builder):
        self._builders[key] = builder

    def create(self, key, **kwargs):
        builder = self._builders.get(key)
        if not builder:
            raise ValueError(key)
        return builder(**kwargs)


""" The implementation structure of ObjectFactory is the same 
you saw in SerializerFactory.

The difference is in the interface that exposes to support creating any type of 
object. The builder parameter can be any object that implements the callable
interface. This means a Builder can be a function, a class, or an object
that implements.__call__().

The .create() method requires that additional arguments are specified as keyword 
arguments. This allows the Builder objects to specify the parameters they need and ignore the 
rest in no particular order. For example, you can see that create_local_music_service()
specifies a local_music_location parameter and ignores the rest.

Let's create the factory instance and registers the builders for the service you want to support.

"""

