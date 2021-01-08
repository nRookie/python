def A(a,**b):
    if not b:
        B(a)
    else:
        B(None,**b)
    
def B(a,**b):
    for key,value in b.items():
        print(key,value)