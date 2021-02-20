from django.shortcuts import render

# Create your views here.


from django.http import HttpResponse
from datetime import datetime
from django.template import Context, loader


def index(request):
    return HttpResponse('<html><body>Hello, World!</body></html>')

def about(request):
    return HttpResponse("Here is the About Page. Want to return home? <a href='/'>Back Home </a>")


def better(request):
    t = loader.get_template('betterhello.html')
    # c = Context({'current_time': datetime.now(), }) does not use Context in django 3
    c = {'current_time' : datetime.now()}
    return HttpResponse(t.render(c))