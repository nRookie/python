import argparse
import STFNBLibrary

stf_parser = argparse.ArgumentParser()

stf_parser.version='1.0'

stf_parser.add_argument('--version',action='store_true',
help='get the version of robotframework-STFNBLibrary')

stf_parser.add_argument('--install',action='store_true',
help='install ')

stf_parser.add_argument('-dir',action ='store',type=str,
help='')


args = stf_parser.parse_args()

print(vars(args))