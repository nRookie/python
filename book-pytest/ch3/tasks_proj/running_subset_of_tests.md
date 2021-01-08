## Single directory

``` shell
pytest tests/func --tb=no
```

## single file


``` shell
pytest tests/func/test_add.py
```

## single test function

``` shell
pytest -v tests/func/test_add.py::test_add_returns_valid_id
```

## Single Test class

``` shell
pytest -v tests/func/test_api_exceptions.py::TestUpdate
```

## Single test method of a test class

``` shell
pytest -v tests/func/test_api_exceptions.py::TestUpdate::test_bad_id
```

## A Set of Tests Based on Test Name

``` shell
pytest -v -k _raises
```

we can use and and not to get rid of the test_delete_raises() from the session:

``` shell
pytest -v -k "_raise and not delete"
```