from services import B
#from services import print_sum

import unittest
from unittest.mock import Mock 
from unittest.mock import patch

class Test(unittest.TestCase):
    @patch('services.A.get_sum')
    def test_todos(self,Mock_get):
        b = B()
        Mock_get.return_value = 3
        result = b.print_sum(2,6)
        self.assertEqual(result,3)
    


if __name__ == "__main__":
    unittest.main()