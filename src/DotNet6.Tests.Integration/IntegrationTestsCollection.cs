namespace DotNet6.Tests.Integration;

[CollectionDefinition(nameof(IntegrationTestsCollection))]
public class IntegrationTestsCollection : ICollectionFixture<TestInitialiser> { }
