import pymongo


conn = pymongo.MongoClient('mongodb://localhost:27017')


databases = conn.databases_names()

for database in databases:
    print(database)


conn.close()