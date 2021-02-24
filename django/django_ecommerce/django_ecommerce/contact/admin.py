from django.contrib import admin

# Register your models here.

from .models import ContactForm

class ContactFormAdmin(admin.ModelAdmin):
    class Meta:
        model = ContactForm


admin.site.register(ContactForm, ContactFormAdmin)
