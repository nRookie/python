def myFun(*argv):
    for arg in argv:
        print(arg)
        

myFun('Hello','Welcome','to','Geek')


def myFun1(arg1,*argv):
    print("First argument :",arg1)
    
    for arg in argv:
        print("Next argument through *argv :", arg)
        

myFun1('Hello','Welcome','to','Geek')

'''
The special syntax **kwargs in function definitions in python is used to 
pass a keyworded , variable-length argument list. We use the name kwargs
with the double start. The reason is because the double star allows us to 
pass through keyworded arguments(and any number of them).

- A keyword argument is where you provide a name to the variable as you pass it into
the function.

- One can think of the kwargs as being a dictionary that maps each keyword to the value
that we pass alongside it. That is why when we iterate over the kwargs there doesn't seem to be any order 
in which they were printed out.
 
'''



def myFun2(**kwargs):
    for key,value in kwargs.items():
        print("%s==%s" % (key,value))

myFun2(first='Geeks',mid = 'for',last = 'Geeks')


def myFun3(arg1,arg2,arg3):
    print("arg1:",arg1)
    print("arg2:",arg2)
    print("arg3:",arg3)


args = ("Geeks","for","Geeks")
myFun3(*args)

kwargs = {"arg1":"Geeks","arg2":"for","arg3":"Geeks"}

myFun3(**kwargs)
