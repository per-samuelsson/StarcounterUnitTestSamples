
using Starcounter;
using Starcounter.Hosting;
using System;
using System.Linq;

namespace App.Tests {

    public class TestContext : IDisposable {
        readonly ICodeHost host;

        public string DatabaseName { get; } = typeof(TestContext).Assembly.GetName().Name.Replace(".", "");

        public TestContext() {
            new TestPrerequisites(DatabaseName)
                .StartServer()
                .StopHost()
                .RecreateDatabase();

            var h = new AppHostBuilder()
                .UseDatabase(DatabaseName)
                .UseApplication(typeof(App.Program).Assembly)
                .Build();
            h.Start();
            host = h;
        }

        void IDisposable.Dispose() {
            host.Dispose();
        }
    }
}