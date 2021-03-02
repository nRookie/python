from django.test import TestCase
from payments.models import User
from django.test import SimpleTestCase

# Create your tests here.


class UserModelTest(TestCase):
    @classmethod
    def setUpClass(cls):
        super(UserModelTest, cls).setUpClass() 
        cls.test_user = User(email="j@j.com", name='test user')
        cls.test_user.save()

    def test_user_to_string_print_email(self):
        self.assertEquals(str(self.test_user), "j@j.com")

    def test_get_by_id(self):
        self.assertEquals(User.get_by_id(1), self.test_user)


class FormTesterMixin():

    def assertFormError(self, form_cls, expected_error_name, expected_error_msg, data):
        from pprint import pformat
        
        test_form = form_cls(data=data)

        # if we get an error then the form should not be valid
        self.assertFalse(test_form.is_valid())

        self.assertEquals(
            test_form.errors[expected_error_name],
            expected_error_msg,
            msg="Expected {} : Actual {} : using data {}".format(
                test_form.errors[expected_error_name],
                expected_error_msg, pformat(data)
            )
        )

from payments.forms import SigninForm
import unittest
from payments.forms import UserForm
from django import forms


class FormTests(unittest.TestCase, FormTesterMixin):

    def test_signin_form_data_validation_for_invalid_data(self):
        invalid_data_list =[
            {'data': {'email' : 'j@j.com'},
             'error' : ('password', [u'This field is required.'])},
            {'data': {'password': '1234'},
             'error' : ('email', [u'This field is required.'])}
        ]
        
        for invalid_data in invalid_data_list:
            self.assertFormError(SigninForm,
                                 invalid_data['error'][0],
                                 invalid_data['error'][1],
                                 invalid_data["data"])

    def test_user_form_passwords_match(self):
        form = UserForm(
            {
                'name': 'jj',
                'email': 'j@j.com',
                'password': '1234',
                'ver_password': '1234',
                'last_4_digits': '3333',
                'stripe_token': '1'}
        )
        
        # Is the data valid ? -- if not print out the errors
        self.assertTrue(form.is_valid(), form.errors)
        
        # this will throw an error if the form doesn't clean correctly
        self.assertIsNotNone(form.clean())

    def test_user_form_passwords_dont_match_throws_error(self):
        form = UserForm(
            {
                'name': 'jj',
                'email': 'j@j.com',
                'password': '234',
                'ver_password': '1234', # bad password
                'last_4_digits' : '3333',
                'stripe_token': '1'
            }
        )
        
        # Is the data valid ?
        self.assertFalse(form.is_valid())

        # self.assertRaisesMessage(forms.ValidationError, "Passwords do not match",
        #                          form.clean)


from .views import sign_in, sign_out

from django.urls import resolve
from django.template.loader import render_to_string
from django.shortcuts import render
from django.test import RequestFactory
class ViewTesterMixin(object):

    @classmethod
    def setupViewTester(cls, url, view_func, expected_html,
                        status_code=200,
                        session={}):
        request_factory = RequestFactory()
        cls.request = request_factory.get(url)
        cls.request.session = session
        cls.status_code = status_code
        cls.url = url
        cls.view_func = staticmethod(view_func)
        cls.expected_html = expected_html

    def test_resolves_to_correct_view(self):
        test_view = resolve(self.url)
        self.assertEquals(test_view.func, self.view_func)

    def test_returns_appropriate_response_code(self):
        resp = self.view_func(self.request)
        self.assertEquals(resp.status_code, self.status_code)

    def test_returns_correct_html(self):
        resp = self.view_func(self.request)
        self.assertEquals(resp.content.decode(), self.expected_html)

class SignInPageTests(TestCase, ViewTesterMixin):
    @classmethod
    def setUpClass(cls):
        super(SignInPageTests, cls).setUpClass() 
        html = render(
            None,
            'sign_in.html', {
                'form': SigninForm(),
                'user': None
            }
        )

        ViewTesterMixin.setupViewTester(
            '/sign_in',
            sign_in,
            html.content
        )



class SignOutPageTests(TestCase, ViewTesterMixin):
    
    @classmethod
    def setUpClass(cls):
        super(SignOutPageTests, cls).setUpClass()
        ViewTesterMixin.setupViewTester(
            '/sign_out',
            sign_out,
            "", # a redirect will return no html
            status_code=302,
            session={"user": "dummy"},
        )

    def setUp(self):
        #sign_out clears the session, so let's reset it overtime
        self.request.session = {"user": "dummy"}
