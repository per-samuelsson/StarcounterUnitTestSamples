
using AppLibrary;
using Xunit;
using Xunit.Abstractions;

namespace App.Tests {

    public class TestClass1 : ContextualTest {
        TestContext db;

        public TestClass1(TestContext context, ITestOutputHelper outputHelper) {
            db = context;
            outputHelper.WriteLine($"I'm a test class that write output and reference the context: {context.DatabaseName}");
        }
        
        [Fact]
        public void Test1() {
            db.Transact(() => {
                new Person() {
                    FirstName = "Per",
                    LastName = "Samuelsson"
                };
            });
        }
    }
}
