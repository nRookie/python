def cheeseshop(kind,**keywords):
    print("-- Do you have any", kind, "?")
    print("-- I'm sorry, we're all out of", kind)
#    for arg in arguments:
#        print(arg)
    print("-" * 40)
    for kw in keywords:
        print(kw)# ":", keywords[kw])


cheeseshop("Limburger",dog="ok",dog1="good",dog2="bad")