class person:
    totalObjects=0
    def __init__(self):
        person.totalObjects=person.totalObjects+1

    @classmethod
    def showcount(cls):
        print("Total objects: ",cls.totalObjects)