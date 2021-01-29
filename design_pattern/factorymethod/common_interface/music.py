class SpotifyService:
    def __init__(self, access_code):
        self._access_code = access_code
    
    def test_connection(self):
        print(f'Accessing Spotify with {self._access_code}')

class SpotifyServiceBuilder:
    def __init__(self):
        self._instance = None
    
    def __call__(self, spotify_client_key, spotify_client_secret, ** _ignored):
        if not self._instance:
            access_code = self.authorize(
                spotify_client_key, spotify_client_secret)
            self._instance = SpotifyService(access_code)
        return self._instance


    def authorize(self, key, secret):
        return 'SPOTIFY_ACCESS_CODE'


""" The example shows a SpotifyServiceBuilder that implements
.__call__(spotify_client_key, spotify_client_secret, **_ignored).

This method is used to create and initialize the concrete Spotify service. It specifies 
the required paramters and ignores any additional paramters provided through **)ignored.

Once the access_code is retrieved. it creates and returns the Spotify service instance.

Notice that SpotifyServiceBuilder keeps the service instance around and only creates a new 
one the first time the service is required. This avoid going through the authorization process 
multiple times as specified in the requirements.

Let's do the same for Pandora.

"""



class PandoraService:
    def __init__(self, consumer_key, consumer_secret):
        self._key = consumer_key
        self._secret = consumer_secret
    
    def test_connection(self):
        print(f'Accessing Pandora with {self._key} and {self._secret}')

class PandoraServiceBuilder:
    def __init__(self):
        self._instance = None

    def __call__(self, pandora_client_key, pandora_client_secret, **_ignored):
        if not self._instance:
            consumer_key, consumer_secret = self.authorize(
                pandora_client_key, pandora_client_secret)
            self._instance = PandoraService(consumer_key, consumer_secret)
        return self._instance

    def authorize(self, key, secret):
        return 'PANDORA_CONSUMER_KEY', 'PANDORA_CONSUMER_SECRET'

""" 

The pandoraServiceBuilder implements the same interface, but it uses different parameters
and processes to create and initialize the PandoraService. It also keeps the service instance around.
So the authorization only happens once.

Finally, let's take a look at the local service implementation:
"""



class LocalService:
    def __init__(self, location):
        self._location = location
    
    def test_connection(self):
        print(f'Accessing Local music at {self._location}')


def create_local_music_service(local_music_location, **_ignored):
    return LocalService(local_music_location)


""" The LocalService just requires a location
where the collection is stored to initialize the LocalService.

A new instance is created every time the service is requested because there is no
slow authorization process. The requirements are simpler, so you don't need a Builder class.
Instead, a function returning an initialized LocalService is used. This function matches the interface
of the .__call__() methods implemented in the builder classes.

"""





