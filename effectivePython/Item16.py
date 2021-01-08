def index_words(text):
    result = []
    if text:
        result.append(0)
    for index, letter in enumerate(text):
        if letter == ' ':
            result.append(index + 1)
    return result

address = 'Four score and seven years ago...'
result = index_words(address)
print(result[:])

def index_words_iter(text):
    if text:
        yield 0
    for index, letter in enumerate(text):
        if letter == ' ':
            yield letter
result = list(index_words_iter(address))

print(result[:])



''' 
- Using generators can be clearer than the alternative of returning
list of accumulated results.

- The iterator returned by a generator produces the set of values 
passed to yield expressions with the generator function's body.

- Generators can produce a sequence of outputs for arbirarily large
inputs because their working memory doesn't include all inputs and outputs.

'''

