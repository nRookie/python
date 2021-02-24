"""django_ecommerce URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/3.1/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from django.contrib import admin
from main import views as main_views
from django.urls import path, re_path, include
from contact import views as contact_views
admin.autodiscover()
urlpatterns = [
    path('admin/', admin.site.urls),
    re_path(r'^$', main_views.index, name='home'),
    re_path(r'^pages/', include('django.contrib.flatpages.urls')),
    re_path(r'^contact/', contact_views.contact, name='contact')
]


from payments import views as payment_views


# user registration/authentication

url(r'^sign_in$', payment_views.sign_in, name='sign_in'),
url(r'^sign_out$', payment_viws.sign_out, name='sign_out'),
url(r'^register$', payment_views.register, name='register'),
url(r'^edit$', payment_views.edit, name='edit'),
