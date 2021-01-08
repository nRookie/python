from tempfile import TemporaryDirectory

class GenericInputData(object):
    def read(self):
        raise NotImplementedError
    @classmethod
    def generate_inputs(cls,config):
        raise NotImplementedError

class PathInputData(GenericInputData):
    # 
    def read(self):
        return open(self.path).read()
    
    @classmethod
    def generate_inputs(cls,config):
        data_dir = config['data_dir']
        for name in os.listdir(data_dir):
            yield cls(os.path.join(data_dir,name))

class GenericWorker(object):
    def map(self):
        raise NotImplementedError

    def reduce(self,other):
        raise NotImplementedError
    
    @classmethod
    def create_workers(cls,input_class,config):
        workers = []
        for input_data in input_class.generate_inputs(config):
            workers.append(cls(input_data))
        return workers

class LineCountWorker(GenericWorker):
    
    def mapreduce(worker_class,input_class,config):
        workers = worker_class.create_workers(input_class,config)
        return execute(workers)

def write_test_files(tmpdir):
    pass
    
with TemporaryDirectory() as tmpdir:
    write_test_files(tmpdir)
    config = {'data_dir':tmpdir}
    result = mapreduce(LineCountWorker,PathInputData,config)
 