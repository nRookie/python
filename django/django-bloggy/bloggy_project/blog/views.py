from django.shortcuts import render, get_object_or_404, redirect

# Create your views here.

from django.http import HttpResponse
from django.template import Context, loader
from blog.models import Post

from blog.forms import PostForm

def index(request):
    latest_posts = Post.objects.all().order_by('-created_at')
    popular_posts = Post.objects.order_by('-views')[:5]
    t = loader.get_template('blog/index.html')
    context_dict = {
        'latest_posts': latest_posts,
        'popular_posts': popular_posts,
    }
    for post in latest_posts:
        post.url = encode_url(post.title)

    for popular_post in popular_posts:
        popular_post.url = encode_url(popular_post.title)

    # c = {'latest_posts': latest_posts, }
    return HttpResponse(t.render(context_dict))

def post(request, slug):
    single_post = get_object_or_404(Post, slug=slug)
    single_post.views += 1  # increment the number of views
    single_post.save()  # and save it
    t = loader.get_template('blog/post.html')
    # c = Context({'single_post' : single_post, })
    c = {'single_post' : single_post, }
    return HttpResponse(t.render(c))

def add_post(request):
    if request.method == 'POST':
        form = PostForm(request.POST, request.FILES)
        if form.is_valid(): # is the form valid?
            form.save(commit=True)
            return redirect(index)
        else:
            print(form.errors) # no? display errors to end user.
    else:
        form = PostForm()
    return render(request, 'blog/add_post.html', {'form': form})

''' 
If it's a POST request, we first determine if the supplied data is valid or not.

Essentially, forms have two different types of validation that are triggered when is_valid() is called on
a form - field and form validation:

1. Field validation, which happens at the form level, validates the uesr inputs against the arguments
specified in the ModelForm -i.e., max_length=100, required=false, etc. Be sure to look over the official 
Django Documentation on widgets to see the available  fields and parameters that each can take

Once the fields are validated, the values are converted over to Python objects and
then form validation occurs via the form's clean method. Read more about this
method here.


Validation ensures that Django does not add any data to the database from a submitted
form that could potentially harm your database

After the data is validated, Django either saves the data to the database,
form.save(commit=True) and redirects the user to the index page or outputs the errors to
the end user.
'''
def encode_url(url):
    return url.replace(' ', '_')