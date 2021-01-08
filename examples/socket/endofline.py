import os 


def changeEoL(fileending ='.cs'):
    cwd = os.getcwd()
    print(f'enter: {cwd}')
    files = os.listdir()
    for file in files:
        if os.path.isdir(file):
            os.chdir(file)
            changeEoL(fileending)
            os.chdir(cwd)
        elif file.endswith('.cs'):
            newdata = ''
            data = ''
            with open(file,'rb') as f:
                data = f.read()
                newdata = data.replace(b'\r\n',b'\n')
            if(data!=newdata):
                with open(file,'wb') as f:
                    f.write(newdata)
    print(f'out: {os.getcwd()}')
                        

changeEoL()
