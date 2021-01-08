class Mixin1(object):
    def test(self):
        print("mixin1")

class Mixin2(object):
    def test(self):
        print("mixin2")


class MyClass(Mixin1, Mixin2):
    pass


