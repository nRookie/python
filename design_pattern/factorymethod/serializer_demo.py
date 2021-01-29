# In serializer_demo.py


import json

import xml.etree.ElementTree as et


class Song:
    def __init__(self, song_id, title, artist):
        self.song_id = song_id
        self.title = title
        self.artist = artist


# class SongSerializer:
#     def serialize(self, song, format):
#         if format == 'JSON':
#             song_info = {
#                 'id' : song.song_id,
#                 'title' : song.title,
#                 'artist' : song.artist
#             }
#             return json.dumps(song_info)
#         elif format == 'XML':
#             song_info = et.Element('song', attrib={'id' : song.song_id})
#             title = et.SubElement(song_info, 'title')
#             title.text = song.title
#             artist = et.SubElement(song_info, 'artist')
#             artist.text = song.artist
#             return et.tostring(song_info, encoding='unicode')
#         else:
#             raise ValueError(format)


""" The Problem with Complex Conditional Code

The example above exhibits all the problems you'll find in complex logical
code. Complex logical code uses if/elif/else structures
to change the behavior of an application. Uisng if/elif/else conditional
structures makes the code harder to read, harder to understand. and harder to maintain.


The code above might not seem hard to read or understand, but wait till you see the final code in this section!

The single responsibility principle 
states thta a module, a class, or even a method should have a single, well-defined 
responsibility. It should do just one thing and have only one reason to change.

The .serialize() method in SongSerializer will require changes for many different reasons.
This increases the risk of introducing new defects or breaking existing functionality when changes 
are made. Let's take a look at all the situation that will require modifications to the implementation.


- when a new format is introduced: The method will have to change to implement the serialization
to that format.


- when the Song object changes: Adding or removing properties to the Song class will require
the implmentation to change in order to accommodate the new structure.

- when the string representation for a format changes (plain JSON vs JSON API):

The .serialize() method will have to change if the desired string representation for a format
chagnes because the represenation is hard-coded in the .serialize() method implemenation.


The ideal situation would be if any of those changes in requirements could be implemented without 
changing the .serialize() method. Let's see how you can do that in the following sections.

"""


""" Looking for a common interface

The first step when you see complex conditional code in an application is to identify
the common goal of each of the execution paths (or logical paths).

Code that uses if/elif/else usually has a common goal that is implemented in different ways 
in each logical path. The code above converts a song object to its string representation using a different
format in each logical path.

Based on the goal, you look for a common interface that can be used to replace each of the paths.

The example above requires an interface that takes a song object and returns a string.

Once you have a common interface, you provide separate implementations for each logical
path. In the example above, you will provide an implementation to serialize to JSON and 
another for XML.

Then, you provide a separate component that decides the concrete implementation to use 
based on the specified format. This component evaluates the value of format and returns the concrete
implementation identified by its value.

In the following sections, you will learn how to make changes to existing code without changing
the behavior. This is referred to as refactoring the code.

Martin Fowler in his book Refactoring: Improving the Design of Existing code defines
refactoring as " the process of changing a software system in such a way that does not 
alter the external behavior of the code yet improves its internal structure."

Let's begin refactoring the code to achieve the desired structure that uses the factory
Method design pattern.

"""


### Refactoring code Into the desired Interface.

"""
The desired interface is an object or a function that takes a song object and returns a string
representation.

The first step is to refactor one of the logical paths into this interface. You do this by adding a new method
._serialize_to_json() and moving the JSON serialization code to it. Then, you change the client to call
it instead of having the implementation in the body of the if statemetn:
"""



# class SongSerializer:
#     def serialize(self, song, format):
#         if format == 'JSON':
#             return self._serialize_to_json(song)
#         elif format == 'XML':
#             return self._serialize_to_xml(song)
#         else:
#             raise ValueError(format)
        
#     def _serialize_to_json(self, song):
#         payload = {
#             'id' : song.song_id,
#             'title' : song.title,
#             'artist' : song.artist
#         }
#         return json.dumps(payload)

#     def _serialize_to_xml(self, song):
#         song_element = et.Element('song', attrib={'id': song.song_id})
#         title = et.SubElement(song_element, 'title')
#         title.text = song.title
#         artist = et.SubElement(song_element, 'artist')
#         artist.text = song.artist
#         return et.tostring(song_element, encoding='unicode')


""" basic implementation of factory method

The central idea in Factory method is to provide a separate component
with the responsibility to decide which concrete implementation should be used based on some
specified parameter. That parameter in our example is the format.

To complete the implementation of Factory method. you add a new method ._get_serializer()
that takes the desired format. This method evaluates the value of format and returns the 
matching serialization function:


"""


# class SongSerializer:
#     def _get_serializer(self, format):
#         if format == 'JSON':
#             return self._serialize_to_json
#         elif format == 'XML':
#             return self._serialize_to_xml
#         else:
#             raise ValueError(format)

#     def serialize(self, song, format):
#         serializer = self._get_serializer(format)
#         return serializer(song)
        
#     def _serialize_to_json(self, song):
#         payload = {
#             'id' : song.song_id,
#             'title' : song.title,
#             'artist' : song.artist
#         }
#         return json.dumps(payload)

#     def _serialize_to_xml(self, song):
#         song_element = et.Element('song', attrib={'id': song.song_id})
#         title = et.SubElement(song_element, 'title')
#         title.text = song.title
#         artist = et.SubElement(song_element, 'artist')
#         artist.text = song.artist
#         return et.tostring(song_element, encoding='unicode')
    


""" The final implementation shows the different component of Factory method.
The .serialize() method is the application code that depends on an interface to complete its task.

This is referred to as the client component of the pattern. The interface defined is referred to as 
the product component. In our case, the product is a function that takes a Song and returns 
a string representation..

The._serialize_to_json() and._serialize_to_xml() methods are concrete implementations of the product.
Finally, the ._get_serializer() method is the creator component. The creator decides which conrete 
implementation to use.


Because you started with some existing code, all the components of Factory method are members of the same class
SongSerializer.

Usually, this is not the case and, as you can see. none of the added mehtods use the self
parameter. This is good indication that they should not be method of SongSerializer class, and they can 
become external functions:

"""
class SongSerializer:
    def serialize(self, song, format):
        serializer = _get_serializer(format)
        return serializer(song)

def _get_serializer(format):
    if format == 'JSON':
        return _serialize_to_json
    elif format == 'XML':
        return _serialize_to_xml
    else:
        raise ValueError(format)
    
def _serialize_to_json(song):
    payload = {
        'id' : song.song_id,
        'title' : song.title,
        'artist' : song.artist
    }
    return json.dumps(payload)

def _serialize_to_xml(song):
    song_element = et.Element('song', attrib={'id': song.song_id})
    title = et.SubElement(song_element, 'title')
    title.text = song.title
    artist = et.SubElement(song_element, 'artist')
    artist.text = song.artist
    return et.tostring(song_element, encoding='unicode')


""" The mechanics of Factory Method are always the same. A client
(SongSerializer.serialize()) depends on a concrete implementation of an interface.
It requests the implementation from a creator component (get_serializer()) using some sort
of identifier(format).

The creator returns concrete implementation according to the value of the parameter to the client,
and the client uses the provided object to complete its task.

You can execute the same set of instructions in the Python interactive interpreter to verify that the application
behavior has not changed.
"""


"""
Recognizing Opportunities to Use Factory Method

Factory Method should be used in every situation where an application(client) 
depends on an interface(product) to perform a task and there are multiple
concrete implementations of that interface. You need to provide a parameter
that can identify the concrete implementation.

There is a wide range of problems that fit this description, 
so let's take a look at some concrete examples.

Replacing complex logical code: complex logical structure in the format if/elif/else 
are hard to maintain because new logical paths are needed as requirements changes.

Factory Method is good replacement because you can put the body of each logical path into separate functions
or classes with a common interface, and the creator can provide the concrete implementation.

The parameter evaluated in the conditions becomes the parameter to identify the concrete 
implementation. The example above represents this situation.

constructing related objects from external data: Imagine an application that needs to 
retrieve employee information from a database or other external source.

The record represent employees with different roles or types: managers,
office clerks, slaes associates, and so on. The application may store an identifier representing the 
type of employee in the record and then use Factory Method to create each concrete Employee
object from the rest of the information on the record.

Supporting multiple implementations of the same feature: An image processing application 
needs to transform a satellite image from one coordinate system to another, but there are 
multiple algorithms with different levels of accuracy to perform the transformation.

The application can allow the user user to select an option that identifies the concrete algorithm.
Factory method can provide the concrete implementation of the algorithm based on this option.

Combining similar features under a common interface: Following the image processing example,
an application needs to apply a filter to an image. The specific filter to use can be identified 
by some user input, and Factory Method can provide the concrete filter implementation.

Integrating related external services: A music player application wants to integrate with 
multiple external services and allow users to select where their music comes from. The application
can define a common interface for a music service and use Factory Method to create the correct integration
based on a user preference.

All these situations are similar. They all define a client that depends on a common interface 
known as the product. They all provide a means to identify the concrete implementation of the 
product, so they all can use Factory Method in their design.

You can now look at the serialization problem from previous examples and provide a better
design by taking into consideration the Factory Method design pattern.

"""




"""