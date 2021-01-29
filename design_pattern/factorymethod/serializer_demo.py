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



class SongSerializer:
    def serialize(self, song, format):
        if format == 'JSON':
            return self._serialize_to_json(song)
        elif format == 'XML':
            return self._serialize_to_xml(song)
        else:
            raise ValueError(format)
        
    def _serialize_to_json(self, song):
        payload = {
            'id' : song.song_id,
            'title' : song.title,
            'artist' : song.artist
        }
        return json.dumps(payload)

    def _serialize_to_xml(self, song):
        song_element = et.Element('song', attrib={'id': song.song_id})
        title = et.SubElement(song_element, 'title')
        title.text = song.title
        artist = et.SubElement(song_element, 'artist')
        artist.text = song.artist
        return et.tostring(song_element, encoding='unicode')

