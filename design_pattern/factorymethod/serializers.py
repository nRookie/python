

""" An object serialization example

The basic requirements for the example above are that you want to serialize Song objects into their 
string represenation. It seems the application provides features related to music, so it is plausible that 
the application will need to serialize other type of objects like Playlist or Album.

Ideally the design should support adding serialization for new objects by implemeting new classes
without requiring changes to the existing implementation. The application requires
objects to be serialized to multiple formats like JSON and XML, so it seems natural 
to define an interface serializer that can have multiple implementations, one per format.

The interface implementaion might look something like this:



"""

import json
import xml.etree.ElementTree as et

class JsonSerializer:
    def __init__(self):
        self._current_object = None

    def start_object(self, object_name, object_id):
        self._current_object = {
            'id' : object_id
        }
    
    def add_property(self, name, value):
        self._current_object[name] = value

    def to_str(self):
        return json.dumps(self._current_object)

class XmlSerializer:
    def __init__(self):
        self._element = None
    
    def start_object(self, object_name, object_id):
        self._element = et.Element(object_name, attrib={'id' : object_id})
    
    def add_property(self, name, value):
        prop = et.SubElement(self._element, name)
        prop.text = value


    def to_str(self):
        return et.tostring(self._element, encoding='unicode')



""" The serializer interface is an abstract concept due to the dynamic nature of
the Python language. Static languages like Java or C# require that interface be explicitly defined.
In Python, any object that provides the desired methods or functions is said to implement the 
interface. The example defines the Serializer interface to be an object that implements the following 
methods or functions.


- .start_object(object_name, object_id)
- .add_property(name, value)
- .to_str()


This interface is implemented by the concrete class JsonSerializer and XmlSerializer.

The original example used a SongSerializer class. For the new application, you will implement 
something more generic, like ObjectSerializer:.

"""



# class ObjectSerializer:
#     def serialize(self, serializable, format):
#         serializer = factory.get_serializer(format)
#         serializable.serialzie(serializer)
#         return serializer.to_str()
    
""" The implementation of ObjectSerializer is completely generic, and it only mentions
a serializable and a format as parameteres.

The format is used to identify the concrete implementation of the Serializer and is resolved by the facotry 
object. The serializable parameter refers to another abstract interface that should be implemented
on any object type you want to serialize.

Let's take a look at a concrete implementation of the serializable interface in the Song
class:

"""




""" Factory Method as an Object factory


In the original example, you implemented the creator as a function. Functions are fine for 
very simple example, but they don't provide too much flexibility when requirements
change.

Classes can provide additional interfaces to add functionality. and they can be derived to customize
behavior. Unless you have a very basic creator that will never change in the future, you want to 
implement it as a class and not a function. these type of clases are called object factories.

"""

# class SerializerFactory:
#     def get_serializer(self, format):
#         if format == 'JSON':
#             return JsonSerializer()
#         elif format == 'XML':
#             return XmlSerializer()
#         else:
#             raise ValueError(format)

# factory = SerializerFactory()

# class ObjectSerializer:
#     def serialize(self, serializable, format):
#         serializer = factory.get_serializer(format)
#         serializable.serialize(serializer)
#         return serializer.to_str()


"""
The current implementation of .get_serializer() is the same you used in the original 
example. The method evaluates the value of format and decides the concrete 
implementation to create and return. It is a relatively simple solution that allows us to verify 
the functionality of all the Factory Method components.

Let's go to the Python interactive interpreter and see how it works.



The new design of Factory Method allows the application to introduce new features by adding new classes,
,as opposed to changing existing ones. YOu can serialize other objects by implementing the serializable interface on them.
You can support new formats by implementing the Serializer interface in another class.

The missing piece is that SerializerFactory has to change to include the support for new formats.
This problem is easily solved with the new design because serializerFactory is a class.

"""




""" Supporting Additional Formats

The current implementation of Serializer Factory needes to be changed when a new format
is introduced. Your application might never need to support any additional formats.
but you never know.

You want your designs to be flexible, and as you will see, supporting additional formats without 
changing SerializerFactory is relatively easy.

The idea is to provide a method in SerializerFactory that registers a new Serializer implementation
for the format we want to support.

"""

class SerializerFactory:
    def __init__(self):
        self._creators = {}
    
    def register_format(self, format, creator):
        self._creators[format] = creator
    
    def get_serializer(self, format):
        creator = self._creators.get(format)
        if not creator:
            raise ValueError(format)
        return creator()


factory = SerializerFactory()
factory.register_format('JSON', JsonSerializer)
factory.register_format('XML', XmlSerializer)

class ObjectSerializer:
    def serialize(self, serializable, format):
        serializer = factory.get_serializer(format)
        serializable.serialize(serializer)
        return serializer.to_str()


""" The .register_format(format, creator) method allows registering new formats
by specifying a format value used to identify the format and a creator object.
The creator object happens to be the class name of the concrete Serializer. This is possible
because all the Serializer classes provide a default.__init__() to initialize the instance.


The registration information is stored in the _creators dictionary. The .get_serializer()
method retrieves the registered creator and creates the desired object. If the requested
format has not been registered , the ValueError is raised.

You can now verify the flexibility of the design by implementing a YamlSerializer and get rid of the annoying
ValueError you saw earlier:


"""