class RightPyramid(Triangle,Square):
    def __init__(self,base,slant_height):
        self.base = base
        self.slant_height = slant_height
        
        
    def what_am_i(self):
        return 'RightPyramid'