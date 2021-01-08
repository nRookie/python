class Resistor(object):
    def __init__(self, ohms):
        self._ohms = ohms
        self.voltage = 0
        self.current = 0



class MysteriousResisotr(Resistor):
    @property
    def ohms(self):
        self.voltage = self._ohms * self.current
        return self._ohms 



r7 = MysteriousResisotr(10)

r7.current = 0.01

print('Before: %5r' % r7.voltage)
r7.ohms
print('After: %5r' % r7.voltage)