class A:
    def __init__(self):
        print('A')
        super().__init__()
        
class B(A):
    def __init__(self):
        super().__init__()
        print('B')
        self.hello()
    def hello(self):
        print('hello')
        
class X:
    def __init__(self):
        print('x')
        super().__init__()
        
class Forward(B,X):
    def __init__(self):
        super().__init__()
        
        
        
class Backward(X,B):
    def __init__(self):
        print('Backward')
        super().__init__()
        
B()