

class A:
    def get_sum(self,a,b):
        return a+b




class B(A):
    def print_sum(self,a,b):
        result = self.get_sum(a,b)
        return result