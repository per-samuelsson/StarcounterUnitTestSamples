
using Xunit;

namespace App.Tests {

    [CollectionDefinition(nameof(TestContext))]
    public class TestContextCollection : ICollectionFixture<TestContext> { }

    [Collection(nameof(TestContext))]
    public abstract class ContextualTest {
    }
}
