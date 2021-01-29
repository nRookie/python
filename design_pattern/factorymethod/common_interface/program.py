


""" Separate Object Creation to Provide Common Interface

The creation of each concrete music service has its own set of requirements. This means
a common initialization interface for each service implementation is not possible or recommended.

The best approach is to define a new type of object that provides a general interface and 
is responsible for the creation of a concrete service. This new type of object will be called
a Builder. The Builder object has all the logic to create and initialize a service instance. You will 
implement a Builder object for each of the supported services.

Let's start by looking at the application configuration. 

"""


config = {
    'spotify_client_key': 'THE_SPOTIFY_CLIENT_KEY',
    'spotify_client_secret': 'THE_SPOTIFY_CLIENT_SECRET',
    'pandora_client_key': 'THE_PANDORA_CLIENT_KEY',
    'pandora_client_secret': 'THE_PANDORA_CLIENT_SECRET',
    'local_music_location': '/usr/data/music'
}


""" The config dictionary contains all the values required to initialize each of the services.
The next step is to define an interface that will use those values to create a concrete implementation
of a music service. That interface will be implemented in a Builder.

Let's look at the implementation of the SpotifyService and SpotifyServiceBuilder:


