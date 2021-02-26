from django.test import TestCase
from django.urls import resolve
from .views import index
from django.template.loader import render_to_string
from django.test import RequestFactory

class MainPageTests(TestCase):
    
    def test_root_resolves_to_main_view(self):
        main_page = resolve('/')
        self.assertEqual(main_page.func, index)

    def test_returns_appropriate_html(self):
        index = self.client.get('/')
        self.assertEquals(index.status_code, 200)

    def test_uses_index_html_template(self):
        index = self.client.get('/')
        self.assertTemplateUsed(index, "index.html")

 
    # def test_returns_exact_html(self):
    #     index = self.client.get("/")
    #     self.assertEquals(
    #         index.content,
    #         render_to_string('index.html')
    #     )
    
    def test_index_handles_logged_in_user(self):
        # create the user needed for user lookup from index page
        from payments.models import User
        user = User(
            name='jj',
            email='j@j.com'
        )
        user.save()
        
        # create a Mock request object
        request_factory = RequestFactory()
        request = request_factory.get('/')
        request.session = {"user": "1"} # make sure it has an associated session
        
        #request the index page
        resp = index(request)
        
        # verify it returns the page for the logged in user.
        
        self.assertEquals (
            resp.content.decode().replace(' ', ''),
            render_to_string('user.html', {'user': user}).replace(' ', '')
        )
        # self.assertTemplateUsed(resp, 'user.html')