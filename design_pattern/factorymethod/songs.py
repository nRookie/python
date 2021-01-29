class Song:
    def __init__(self, song_id, title, artist):
        self.song_id = song_id
        self.title = title
        self.artist = artist
    def serialize(self, serializer):
        serializer.start_object('song', self.song_id)
        serializer.add_property('title', self.title)
        serializer.add_property('artist', self.artist)


""" The song class implements 
the Serializable interface by providing a .serialize(serializer) method.
In the method, the song class uses the serializer object to write its own
information without any knowledge of the format.


As a matter of fact, the Song class doesn't even know the goal is to convert the data
to a string. This is important because you could use this interface to provide a different kind of
serializre that converts the Song information to a completely different representation if needed.
For example, your application might require in the future to convert the Song object to a binary
format.

So far, we've seen the implementation of the client(ObjectSerializer) and the product 
(serializer)/ It is time to complete the implementaiton of Factory Method and provide the creator.
The creator in the example is the variable facotry in OjbectSerializer.serialize().

"""

