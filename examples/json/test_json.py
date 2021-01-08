import json

class Elf:
    def __init__(self, level, ability_scores = None):
        self.level = level
        self.ability_scores = {
            "str": 11, "dex": 12, "con" : 10,
            "int": 16, "wis": 14, "cha" : 13
        } if ability_scores is None else ability_scores
        self.hp = 10 + self.ability_scores["con"]



def encode_complex(z):
    if isinstance(z, complex):
        return (z.real, z.imag)
    else:
        type_name = z.__class__.__name__
        raise TypeError(f"Object of type '{type_name} is not  JSON serializable")
'''
    Notice that you're expected to raise a TypeError if you don't get the kind of object you were expecting.
    This way, you avoid accidentally serializing any Elves. Now you can try encoding complex objects for yourself!


'''

'''
    The other common approach is to subclass the standard JSONEncoder and override its default() method:

'''


class ComplexEncoder(json.JSONEncoder):
    def default(self, z):
        if isinstance(z, complex):
            return (z.real,z.imag)
        else:
            return super().default(z)

'''
    Instead of raising the TypeError yourself, you can simply let the base class handle it. You can use this either directly
in the dump() method via the cls parameter or by creating an instance of the encoder and calling its encode() method:

'''
json.dumps(2+5j,cls=ComplexEncoder)


