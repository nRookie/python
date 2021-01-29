import yaml
import serializers


class YamlSerializer(serializers.JsonSerializer):
    def to_str(self):
        return yaml.dump(self._current_object)


serializers.factory.register_format('YAML', YamlSerializer)


""" JSON and YAML are very similar formats, so you can reuse most of the 
implementation of JsonSerializer and overwrite .to_str() to complete the implementation. The format
is then registered with the factory object make it available.


Let's use the Python interactive interpreter to see the results.

"""



""" By implementing  Factory method 
using an Object Factory and providing a registration
interface, you are able to support new formats without changing any of the existing application
code. This minimizes the risk of breaking existing features or introducing subtle bugs.

"""



""" Not all Objects can be created equal

The biggest challenge to implement a general purpose Object factory is that not all 
objects are created in the same way.

Not all situations allow us to use a default.__init__() to create and initialize the objects.
It is important that the creator, in this case the Object factory, returns fully initialized
objects.

This is important because if it doesn't then the client will have to complete the initialization and 
use complex conditional code to fully initialize the provided objects. This defeats the purpose of the factory
method design pattern.

To understand the complexities of a general purpose solution. let's take a look at a different 
problem. Let's say an application wants to integrate with different music services. These 
services can be external to the application or internal in order to support a local music collection.
Each of the service has a different set of requirements.



Imagine that the application wants to integrate with a service provided by Spotify. This service
requires an authorization process where a client key and secret are provided for authorization.

The service returns an access code that should be used on any further communication. This authorization process
is very slow, and it should only be performed once, so the application wants to keep the initialized service
object around and use it every time it needs to communicate with Spotify.

At the same time, other users want to integrate with Pandora. Pandora might use a completly different 
authorization process. It also requires a client key and secret. but it returns a consumer key and secret
that should be used for other communications. As with Spotify, the autorization process is slow,
and it should only be performed once.


This example presents several challenges. Each service is initialzied with a different set of parameters.
Also. Spotify and Pandora require an authorization process before the service instance can be created.

They also want to reuse that instance to avoid authorizing the application multiple times.

The local service is simpler, but it doesn't match the initialization interface of the others.

In the following sections, you will solve this problems by generalizing the creation interface and implementing
a general purpose Object Factory.
"""

