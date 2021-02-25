from django.test import TestCase
from django.urls import resolve
from .views import index

class MainPageTests(TestCase):
    
    def test_root_resolves_to_main_view(self):
        main_page = resolve('/')
        self.assertEqual(main_page.func, index)

# Create your tests here.
