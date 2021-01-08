import sqlite3

conn = sqlite3.connect('people.db')
cur = conn.cursor()
lname = 'Farrell'
cur.execute('SELECT * FROM person WHERE lname = \'{}\''.format(lname))
people = cur.fetchall()
for person in people:
    print(f'{person[1]} {person[0]}')