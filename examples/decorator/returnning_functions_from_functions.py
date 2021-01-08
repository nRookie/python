def parent(num):
    def first_child():
        return "Hi, I am Emma"

    def second_child():
        return "Call me Liam"

    # returning a reference to the function first_child
    if num ==1:
        return first_child
    
    else:
        return second_child
    