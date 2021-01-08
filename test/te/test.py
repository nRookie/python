from unittest import TestCase
from unittest.mock import patch, Mock
from main import Blog
class TestBlog(TestCase):
    @patch('main.Blog')
    def test_blog_posts(self, MockBlog):
        blog = MockBlog()

        blog.posts.return_value = [
            {
                'userId': 1,
                'id' : 1,
                'title': 'Test Title',
                'body': 'Far out in the uncharted backwaters of the unfashionable end of the western spiral arm of the Galaxy\ lies a small unregarded yellow sun.'

            }
        ]

        response = blog.posts()
        self.assertIsNotNone(response)
        self.assertIsInstance(response[0],dict)


        # Additional assertions

        #assert MockBlog is Blog.blog # The Mock is equivalent to the original
        
        assert MockBlog.called # The mock wasP called

        blog.posts.assert_called_with() # We called the posts method with no arguments

        blog.posts.assert_called_once_with() # We called the posts method once with no  arguments

        blog.reset_mock() # Reset the mock object

        blog.posts.assert_not_called() # After resetting, posts has not been called.