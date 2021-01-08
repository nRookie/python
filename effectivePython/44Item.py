''' The pickle built-in module can serialize Python objects into
a stream of bytes and deserialize bytes back into objects. Pickled
byte streams shouldn't be used to communicate between untrusted parties.
The purpose of pickle is to let you pass Python objects between
programs that you control over binary channels.

'''
import pickle 

class GameState(object):
    def __init__(self):
        self.level = 0
        self.lives = 4
        self.points = 0

'''
The program modifies this object as the game runs.

'''
state_path = 'game_state.bin'
 
with open(state_path, 'rb') as f:
    state_after = pickle.load(f)
print(state_after.__dict__)

assert isinstance(state_after, GameState)