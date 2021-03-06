from django.shortcuts import render

# Create your views here.

from django.http import HttpResponse
from django.template import Context, loader

from blongo.models import Post

def index(request):
    latest_posts = Post.objects
    t = loader.get_template('index.html')
    context_dict = {'latest_posts': latest_posts}
    c = context_dict
    return HttpResponse(t.render(c))
