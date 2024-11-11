namespace DotNet8.Tests.Integration;

[CollectionDefinition(nameof(IntegrationTestsCollection))]
public class IntegrationTestsCollection : ICollectionFixture<TestInitialiser> { }
