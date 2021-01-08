import abc


class QuackStrategyAbstract(object):
    """ You do not need to know about metaclasses.
    Just know that this is how you define abstract classes in python."""
    __metaclass__ = abc.ABCMeta
    
    
    
    @abc.abstractmethod
    def quack(self):
        """ Required Method"""
        pass
    
class LoudQuackStrategy(QuackStrategyAbstract):
    def quack(self):
        print("QUACK! QUACK!")
        


class GentleQuackStrategy(QuackStrategyAbstract):
    def quack(self):
        print("quack")
        
        
class LightStrategyAbstract(object):
    __metaclass__ = abc.ABCMeta
    
    @abc.abstractmethod
    def lights_on(self):
        """Required Method """
        pass
    
    
class OnForTenSecondsStrategy(LightStrategyAbstract):
    def lights_on(self):
        print("Lights on for 10 seconds")