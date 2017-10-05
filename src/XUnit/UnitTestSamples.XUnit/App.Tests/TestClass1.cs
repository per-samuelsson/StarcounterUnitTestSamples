
using System;
using Xunit;
using Xunit.Abstractions;

namespace App.Tests {

    public class TestClass1 : ContextualTest {

        public TestClass1(TestContext context, ITestOutputHelper outputHelper) {
            outputHelper.WriteLine($"I'm a test class that write output and reference the context: {context.DatabaseName}");
        }
        
        [Fact]
        public void Test1() {
            
        }
    }
}
