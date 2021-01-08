'''

Classes and Inheritance

As an object-oriented programming language,Python supports a full
range of features,such as inheritance,polymorphism,and encapsulation.
Getting things done in Python often requires writing new classes
and defining how they interact through their interfaces and hierarchies.

Python's classes and inheritance make it easy to express your program's
intended behaviors with objects. They allow you to improve and expand
functionality over time. They provide flexibility in an environment of 
changing requirements. Knowing how to use them well enables you to write
maintainable code.


Prefer Helper Classes Over Bookkeeping with Dictionaries and Tuples

Python's built-in dictionary type is wonderful for maintaining dynamic
internal state over the lifetime of an object. By dynamic, I mean
situations in which you need to do bookkeeping for an unexpected
set of identifiers. For example, say you want to record the grades
of a set of students whose names aren't known in advance. You
can define a class to store the names in a dictionary instead of
using a predefined attribute for each student.

'''

class SimpleGradebook(object):
    def __init__(self):
        self._grades = {}

    def add_student(self,name):
        self._grades[name] = []

    def report_grade(self,name,score):
        self._grades[name].append(score)

    def average_grade(self,name):
        grades = self._grades[name]
        return sum(grades) / len(grades)


book = SimpleGradebook()
book.add_student('Isaac Newton')
book.report_grade('Isaac Newton',90)

print(book.average_grade('Isaac Newton'))


'''
Dictionaries are so easy to use that there's a danger of overextending
them to write brittle code. For example, say you want to 
extend the SimpleGradebook class to keep a list of grades by subject,
not just overall. You can do this by changing the _grades
dictionary to map student names ( the keys ) to yet another
dictionary (the values). The innermost dictionary will map 
subjects (the keys ) to grades (the values).
'''
class BySubjectGradebook(object):
    def __init__(self):
        self._grades = {}

    def add_student(self,name):
        self._grades[name] = {}

    def report_grade(self,name,subject,grade):
        by_subject = self._grades[name]
        grade_list = by_subject.setdefault(subject,[])
        grade_list.append(grade)
    
    def average_grade(self,name):
        by_subject = self._grades[name]
        total,count = 0,0
        for grades in by_subject.values():
            total += sum(grades)
            count += len(grades)
        return total / count
'''

This seems straightforward enough. The report_grade and average_grade
methods will gain quite a bit of complexity to deal with the multilevel
dictionary, but it's manageable.

'''


book = BySubjectGradebook()
book.add_student('Albert Einstein')
book.report_grade('Albert Einstein', 'Math' ,75)
book.report_grade('Albert Einstein','Math',75)
book.report_grade('Albert Einstein','Gym',90)
book.report_grade('Albert Einstein','Gym',95)

print(book.average_grade('Albert Einstein'))
'''

Now,imagine your requirements change again. You also want to track
the weight of each score toward the overall grade in the class
so midterms and finals are more important than pop quizzes.
One way to implement this feature is to change the innermost
dictionary;
instead of mapping subjects(the keys) to grades(the values),
I can use the tuple (Score,weight) as values.

'''

class WeightedGradebook(object):

    def report_grade(self,name,subject,score,weight):
        by_subject = self.grades[name]
        grade_list = by_subject.setdefault(subject,[])
        grade_list.append((score,weight))
    def average_grade(self,name):
        by_subject = self._grades[name]
        score_sum,score_count = 0,0
        for subject,scores in by_subject.items():
            subject_avg,total_weight = 0,0
            for score,weight in scores:
                pass
        return score_sum / score_count

''' When you see complexity like this happen,it's time to make
the leap from dictionaries and tuples to a hierarchy of classes.

At first, you didn't know you'd need to support weighted grades,
so the complexity of additional helper classes seemed unwarranted.
Python's built-in dictionary and tuple types made it easy to keep
going,adding  layer after layer to the internal bookkeeping.
But you should avoid doing this for more than one level of 
nesting(i.e.,avoid dictionaries that contain dictionaries.) It makes
your code hard to read by other programmers and sets you up for 
a maintenance nightmare.

As soon as you realize the bookkeeping is geting complicated, break it
all out into classes. This lets you provide well-defined interfaces
that better encapsulate your data. This also enables you to create
a layer of abstraction between your interfaces and 
your concrete implementations.

'''

'''
Although the changes to report_grade seem simple-- just make the
value a tuple- the average_grade method now has a loop within a loop
and is difficult to read.

Refactoring to Classes

You can start moving to classes at the bottom of the dependency
tree: a single grade. A class seems too heavyweight for such
simple information. A tuple,though,seems appropriate because
grades are immutable. Here,I use the tuple (score,weight) to 
track grades in a list:
'''
grades = []
grades.append((95,0.45))

total = sum(score* weight for score,weight in grades)
total_weight = sum (weight for _, weight in grades)
average_grade = total / total_weight

'''
The problem is that plain tuples are positional. When you want 
to associate more information with a grade, like a set of notes
from the teacher, you'll need to rewrite every usage of the
two-tuple to be aware that there are now three items present instead
of two. Here, I use _(underscore variable name, a Python convention
for unused variables) to capture the third entry in the tuple and
just ignore it:


'''

grades = []
grades.append((95,0.45,'Great job'))
# ...
total = sum(score * weight for score,weight, _ in grades)
total_weight = sum(weight for _,weight,_ in grades)
average_grade = total / total_weight


print("\r\n\r\n")

import collections
Grade = collections.namedtuple('Grade',('score','weight'))

class Subject(object):
    def __init__(self):
        self._grades = []
    
    def report_grade(self,score,weight):
        self._grades.append(Grade(score,weight))

    def average_grade(self):
        total,total_weight = 0, 0
        for grade in self._grades:
            total += grade.score * grade.weight
            total_weight += grade.weight
        return total / total_weight

class Student(object):
    def __init__(self):
        self._subjects = {}
    
    def subject(self,name):
        if name not in self._subjects:
            self._subjects[name] = Subject()
        return self._subjects[name]
    
    def average_grade(self):
        total,count = 0,0
        for subject in self._subjects.values():
            total += subject.average_grade()
            count +=1
        return total / count


class Gradebook(object):
    def __init__(self):
        self._students = {}

    def student(self,name):
        if name not in self._students:
            self._students[name] = Student()
        return self._students[name]



book = Gradebook()
albert = book.student('Albert Einstein')
math = albert.subject('Math')
math.report_grade(80,0.10)

print(albert.average_grade())


'''Avoid making dictionaries with values
that are other dictionaries or long tuples.

Use namedtuple for lightweight,immutable data
containers before you need the flexibility of a full class.

Move your bookkeeping code to use multiple helper classes when your

internal state dictionaries get complicated.


'''
