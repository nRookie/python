## Using tmpdir and tmpdir_factory

The tmpdir and tmpdir_factory builtin fixtures are used to create a temporary file system directory
before your test runs, and remove the directory when your test is finihsed. In the tasks project, we needed a directory to store the temporary database files used by MongoDB and TinyDB. However because we want to test with temporary databases that don't survive past a test session, we used tmpdir and tmpdir_factory to do the directory creation and cleanup for us.

If you're testing something that reads, writes, or modifies files, you can use tmpdir to create files or directories used by a single test, and you can use tmpdir_factory when you want to set up a directory for many tests.

The tmpdir fixture has function scope, and the tmpdir_factory fixture has session scope. Any individual test that needs a temporary directory or file just for the single test can use tmpdir. This is also true for a fixture that is setting up a directory or file that should be recreated for each test function.

Here's a simple example using tmpdir:

