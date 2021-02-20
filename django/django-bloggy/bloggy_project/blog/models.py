from django.db import models

# Create your models here.

class Post(models.Model):
    created_at = models.DateTimeField(auto_now_add=True)
    title = models.CharField(max_length=100)
    content = models.TextField()
    tag = models.CharField(max_length=20, blank=True, null=True)
    image = models.ImageField(upload_to="images", blank=True, null=True)
    views = models.IntegerField(default=0)
    '''
    Note: By setting blank=True, we are indicating that the field is not required and can be left blank within the form
    (or whenever data is inputted by the user). Meanwhile , null=True allows blank values to be stored in the database as NULL.
    These options are usually used in tandem.
    '''

    def __str__(self):
        return self.title
