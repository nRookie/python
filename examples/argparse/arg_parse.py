import argparse


# since we are now passing in the greeting
# the logic has been consolidated to a single greet function
def greet(args):
    output = '{0}, {1}!'.format(args.greeting, args.name)
    if args.caps:
        output = output.upper()
    print(output)

parser = argparse.ArgumentParser()
subparsers = parser.add_subparsers()

hello_parser = subparsers.add_parser('hello')
hello_parser.add_argument('name')
# add greeting option w/ default
hello_parser.add_argument('--greeting', default='Hello')
# add a flag (default=False)
hello_parser.add_argument('--caps', action='store_true')
hello_parser.set_defaults(func=greet)

goodbye_parser = subparsers.add_parser('goodbye')
goodbye_parser.add_argument('name')
goodbye_parser.add_argument('--greeting', default='Goodbye')
goodbye_parser.add_argument('--caps', action='store_true')
goodbye_parser.set_defaults(func=greet)

if __name__ == '__main__':
    args = parser.parse_args()
    args.func(args)