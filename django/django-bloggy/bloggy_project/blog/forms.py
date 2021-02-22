from django import forms
from blog.models import Post



class PostForm(forms.ModelForm):

    class Meta:
        model = Post
        fields = ['title', 'content', 'tag', 'image']


''' Here,
we created a new ModelForm  that's mapped to our model via the Meta() inner class model = Post. Notice how each of our 
form fields have an associated column in the database. This is required.
'''