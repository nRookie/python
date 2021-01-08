class Rectangle:
    def __init__(self, length, width, **kwargs):
        self.length = length
        self.width = width
        super().__init__(**kwargs)

    def area(self):
        return self.length * self.width

    def perimeter(self):
        return 2 * self.length + 2 * self.width

class Square(Rectangle):
    def __init__(self, length, **kwargs):
        super().__init__(length=length, width=length, **kwargs)

class Triangle:
    def __init__(self, base, height, **kwargs):
        self.base = base
        self.height = height
        super().__init__(**kwargs)

    def tri_area(self):
        return 0.5 * self.base * self.height
    
class SurfaceAreaMixin:
    def surface_area(self):
        surface_area = 0 
        for surface in self.surface:
            surface_area +=surface.area(self) 
            
        return surface_area
    
    
class Cube(Square, SurfaceAreaMixin):
    def __init__(self,length):
        super().__init__(length)
        self.surfaces = [Square,Square,Square,Square,Square,Square]
        
        
class RightPyramid(Square, Triangle, SurfaceAreaMixin):
    def __init__(self, base, slant_height):
        self.base = base
        self.slant_height = slant_height
        self.height = slant_height
        self.length = base
        self.width = base

        self.surfaces = [Square, Triangle, Triangle, Triangle, Triangle]
        
        
