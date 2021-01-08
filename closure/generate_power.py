def generate_power(number):
    """
    Examples of use:

    >>> raise_two = generate_power(2)
    >>> raise_three = generate_power(3)
    >>> print(raise_two(7))
    128
    >>> print(raise_three(5))
    243
    """

    # Define the inner function ...
    def nth_power(power):
        return number ** power
    # ... that is returned by the factory function.

    return nth_power