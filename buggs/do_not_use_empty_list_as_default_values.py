class A:
    def __init__(self, columns=[]):
        self.alist = columns

class B:
	# correct way
	def __init__(self, columns=None):
		if columns == None:
			columns = []
		self.alist = columns

if __name__ == "__main__":
    empty_list = []
    a = A(empty_list)
    b = A(empty_list)


    a.alist.append(10)
    b.alist.append(20)

    for v in a.alist:
        print(v)
    print()

    # two empty lists
    empty_list1 = []
    empty_list2 = []
    c = A(empty_list1)
    d = A(empty_list2)


    c.alist.append(10)
    d.alist.append(20)

    for v in c.alist:
        print(v)

    print()

    # using [] as default value might cause some confusing result.
    f = A()
    g = A()

    f.alist.append(10)
    g.alist.append(20)

    for v in f.alist:
        print(v)
    print()


    h = B()
    i = B()
    j = B()
    h.alist.append(1)
    i.alist.append(2)
    j.alist.append(3)
    for v in h.alist:
        print(v)
