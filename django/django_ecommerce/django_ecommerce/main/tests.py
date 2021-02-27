from django.test import TestCase
from django.urls import resolve
from .views import index
from django.template.loader import render_to_string
from django.test import RequestFactory
import mock
from payments.models import User

class MainPageTests(TestCase):
    
    
    # setup
    
    @classmethod
    def setUpClass(cls):
        super(MainPageTests, cls).setUpClass() 
        request_factory = RequestFactory()
        cls.request = request_factory.get('/')
        cls.request.session = {}

    #######################
    #### Testing routes ###
    #######################

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
    #         index.content.decode().replace(' ', ''),
    #         render_to_string('index.html').replace(' ', '')
    #     )


    def test_index_handles_logged_in_user(self):
        # create the user needed for user lookup from index page
        from payments.models import User
        user = User(
            name='jj',
            email='j@j.com'
        )

        # create a session that appears to have a logged in user
        self.request.session = {"user": "1"}
        
        with mock.patch('main.views.User') as user_mock:
            #Tell the mock what to do when called.
            config = {'get.return_value' : user}
            user_mock.objects.configure_mock(**config)
            
            # Run the test
            resp = index(self.request)

            # Ensure that we return the state of the session back to normal

            self.request.session = {}

            expectedHtml = render_to_string(
                'user.html', {'user': user}).replace(' ', '')

            self.assertEquals(resp.content.decode().replace(' ', ''), expectedHtml)