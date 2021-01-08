''' Concurrency and Parallelism

Concurrency is when a computer does many different things 
seemingly at the same time. For example, on a computer
with one CPU core, the operating system will rapidly change 
which program is running on the single processor. This 
interleaves execution of the programs, providing the illusion
that the programs are running simultaneously.

Parallelism is actually doing many different things at the same time.
Computers with multiple CPU cores can execute multiple programs
simultaneously. Each CPU core runs the instructions of a separate
program, allowing each program to make forward progress during
the same instant.

Within a single program, concurrency is a tool that makes it
easier for programmers to solve certain types of problems.
Concurrent programs enable many distinct paths of execution
to make forward progress in a way that seems to be both simultaneous
and independent.

The key difference between parallelism and concurrency is speedup.
When two distinct paths of execution in a program make forward progress in parallel,
the time it takes to do the total work is cut in half;
the speed of execution is fater by a factor of two. In contrast,
concurrent programs may run thousands of separate paths of execution
seemingly in parallel but provide no speedup for the total work.

Python makes it easy to write concurrent programs. Python can
also be used to do the parallel work through system calls, subprocesses
,and C-extensions. But it can be very difficult to make
concurrent Python code truly run in parallel. It's important to 
understand how to best utilize Python in these subtly different situations.



Item 36: Use subprocess to Manage Child Processes

Python has battle-hardened libraries for running and managing
child processes. This makes Python a great language for
gluing other tools together, such as command-line utilities. When
existing shell scripts get complicated, as they often do over time,
graduating them to  a rewrite in Python is a natural choice for the
sake of readability and maintainability.

Child processes started by Python are able to run in parallel,
enabling you to use Python to consume all of the CPU cores
of your machine and maximize the throughput of your programs.
Although Python itself may be CPU bound (see Item 37: "Use Threads
for Blocking I/O, Avoid for Parallelism),it's easy to use
Python to drive and coordinate CPU-intensive workloads.

Python has had many ways to run subprocesses over the years,
including popen, popen2, and os.exec*. With the Python of today,
the best and simplest choice for managing child processes is to 
use the subprocess built-in module.

Running a child process with subprocess is simple. Here, the Popen 
constructor starts the process. The communicate method reads the
child process's output and waits for termination.

'''
import subprocess
from time import time
import os
proc = subprocess.Popen(
    ['echo', 'Hello from the Child!'],
    stdout = subprocess.PIPE)
out, err = proc.communicate()
print(out.decode('utf-8'))

'''

Child processes will run independently from their parent
process, the Python interpreter. Their status can be polled
periodically while Python does other work.

'''

proc = subprocess.Popen(['sleep','0.3'])
while proc.poll() is None:
    print('Working...')
    #some time-consuming work here
    # ...

print('Exit status', proc.poll())

'''

Decoupling the child process form the parent means that the
parent process is free to run many child processes in parallel.
You can do this by starting all the child processes together
upfront.

'''

def run_sleep(period):
    proc = subprocess.Popen(['sleep',str(period)])
    return proc


start = time()
procs = []

for _ in range(10):
    proc = run_sleep(0.1)
    procs.append(proc)


'''
Later, you can wait for them to finish their I/O terminate
with the communicate method.

'''


for proc in procs:
    proc.communicate()

end = time()
print('Finished in %.3f seconds' % (end - start))



'''

If these Processes ran in sequence, the total delay would be
1 second, not the ~0.1 second I measured.

You can also pipe data from your Python program into a subprocess
and retrieve its output. This allows you to utilize other
programs to do work in parallel. For example, say you want to
use the openssl command-line tool to encrypt some data. Starting
the child process with command-line arguments and I/O pipes is easy.

'''


def run_openssl(data):
    env = os.environ.copy()
    env['password'] = b'\xe24U\n\xd0Ql3S\x11'
    proc = subprocess.Popen(
        ['openssl', 'enc', '-des3', '-pass', 'env:password'],
        env=env,
        stdin= subprocess.PIPE,
        stdout = subprocess.PIPE)
    proc.stdin.write(data)
    proc.stdin.flush()               # Ensure the child gets input
    return proc

'''

Here, I pipe random bytes into the encryption function,
but in practice this would be user input, a file handle,
a network socket, etc.:

'''

procs = []

for _ in range(3):
    data = os.urandom(10)
    proc = run_openssl(data)
    procs.append(proc)





''' Things to Remember

- Use the subprocess module to run child processes 
and manage their input and output streams.

- Child processes run in parallel with the Python interpreter,
enabling you to maximize your CPU usage.

- Use the timeout parameter with communicate to avoid 
deadlocks and hanging child processes.

