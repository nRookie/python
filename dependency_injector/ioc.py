#Framework Code:
class TokenInterface():
    def getUserFromToken(self, token):
        raise NotImplementedError

class FrameworkClass(TokenInterface):
    def do_the_job(self, ...):
        # some stuff
        self.user = super().getUserFromToken(...)

        
#Client Code:
class SQLUserFromToken(TokenInterface):
    def getUserFromToken(self, token):      
        # load the user from the database
        return user

class ClientFrameworkClass(FrameworkClass, SQLUserFromToken):
    pass

framework_instance = ClientFrameworkClass()
framework_instance.do_the_job(...)