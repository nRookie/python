class MyBaseClass(object):
    def __init__(self,value):
        self.value = value
        print("base",value)

class MyChildClass(MyBaseClass):
    def __init__(self):
        MyBaseClass.__init__(self,5)


class TimesTwo(object):
    def __init__(self):
        self.value *= 2
        print("times two",self.value)

class PlusFive(object):
    def __init__(self):
        self.value += 5

class OneWay(MyBaseClass , TimesTwo, PlusFive):
    def __init__(self,value):
        MyBaseClass.__init__(self, value)
        TimesTwo.__init__(self)
        PlusFive.__init__(self)

foo = OneWay(5)

print('First ordering is (5*2) +5 =',foo.value)


class AnotherWay(MyBaseClass,PlusFive,TimesTwo):
    def __init__(self,value):
        MyBaseClass.__init__(self,value)
        TimesTwo.__init__(self)
        PlusFive.__init__(self)

bar = AnotherWay(5)
print('Second ordering still is',bar.value)

'''
Diamond inheritance happens when a subclass inherits from two separate
classes that hvae the same superclass somewhere in the hierarchy.
Diamond inheritance causes the common superclass's __init__ method
to run multiple times, causing unexpected behavior.For example, here
I define two child classes that inherit from MyBaseClass.
'''
class TimesFive(MyBaseClass):
    def __init__(self,value):
        super().__init__(value)
        self.value *= 5
        print("Times",self.value)

class PlusTwo(MyBaseClass):
    def __init__(self,value):
        super().__init__(value)
        self.value +=2
        print("plus",self.value)

class PlusThree(MyBaseClass):
    def __init__(self,value):
        super().__init__(value)
        self.value +=3
        print("plus 3",self.value)


class ThisWay(PlusTwo,TimesFive,PlusOne):
    def __init__(self,value):
        super().__init__(value)
        print("This",self.value)



print('\r\n\r\n\r\n')
foo = ThisWay(5)
print ('Should be (5*5) + 2 = 27 but is ', foo.value)

'''
class Explicit(MyBaseClass):
    def __init__(self,value):
        super(__class__,self).__init__(value*2)

class Implicit(MyBaseClass):
    def __init__(self,value):
        super().__init__(value*2)

assert Explicit(10).value == Implicit(10).value
'''