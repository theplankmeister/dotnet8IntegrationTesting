# .Net8-Isolated Integration Testing
Simple example that demonstrates that integration tests in .net6 in-proc work as expected, while the same integration tests in .net8 isolated do not work as expected.

While attempting to run the tests in .net8, it fails with the message

```
System.InvalidOperationException : The gRPC channel URI 'http://:50084' could not be parsed.
```

By adding the `host` variable to the `test.settings.json` file and setting it to `127.0.0.1` the test runs further, but runs into more issues with gRPC, that cannot be resolved with a config setting.
