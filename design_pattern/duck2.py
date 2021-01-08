import abc


class FlyBehavior:
    __metaclass__ = abc.ABCMeta
    
    @abc.abstractmethod
    def fly(self):
        pass

class FlyWithWings(FlyBehavior):
    def fly(self):
        print("I'm flying !!")
class FlyNoWay(FlyBehavior):
    def fly(self):
        print("I can't fly")
class FlyRocketpowered(FlyBehavior):
    def fly(self):
        print("I'm flying with a rocket!")

class QuackBehavior:
    __metaclass__ = abc.ABCMeta
    @abc.abstractmethod
    def quack(self):
        pass 
    

class Quack(QuackBehavior):
    def quack(self):
        print("Quack")

class MuteQuack(QuackBehavior):
    def quack(self):
        print("silence")

class Squeak(QuackBehavior):
    def quack(self):
        print("squeak")


class Duck:
    __metaclass__=abc.ABCMeta
    def __init__(self,quackBehavior):
        self.quackBehavior = None
        self.flyBehavior = None
        
        
    def performFly(self):
        self.flyBehavior.fly()

    def performQuack(self):
        self.quackBehavior.quack()
    
    def setFlyBehavior(self,fb):
        self.flyBehavior = fb
    
    def setQuackBehavior(self,qb):
        self.quackBehavior = qb
    @abc.abstractmethod
    def display(self):
        pass
    
    def swim(self):
        print("All ducks float, even decoys!")
        
        



class MallardDuck(Duck):
    def __init__(self):
        self.quackBehavior = Quack()
        self.flyBehavior = FlyWithWings()

    def display(self):
        print("I'm a real Mallard duck")


class ModelDuck(Duck):
    def __init__(self):
        self.flyBehavior = FlyNoWay()
        self.quackBehavior = Quack()
        
    def display(self):
        print("I'm a model duck")
if __name__ == "__main__":
    mallard = MallardDuck()
    mallard.display()
    mallard.performQuack()
    mallard.performFly()
    
    model = ModelDuck()
    
    model.performFly()
    model.setFlyBehavior(FlyRocketpowered())
    model.performFly()