
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace App.Tests {

    internal class TestPrerequisites {
        readonly string name;

        class KnownExitCodes {
            public const int HostNotRunning = 10024;
            public const int DatabaseDoesNotExist = 10002;
        }

        public TestPrerequisites(string databaseName) {
            name = databaseName;
        }

        public TestPrerequisites StartServer() {
            RunStarAdmin("start server");
            return this;
        }

        public TestPrerequisites StopHost() {
            RunStarAdmin($"-d={name} stop host", 
                KnownExitCodes.HostNotRunning, 
                KnownExitCodes.DatabaseDoesNotExist
            );
            return this;
        }

        public TestPrerequisites DeleteDatabase() {
            RunStarAdmin($"-d={name} delete --force db");
            return this;
        }

        public TestPrerequisites CreateDatabase() {
            RunStarAdmin($"-d={name} new db");
            return this;
        }

        public TestPrerequisites RecreateDatabase() {
            return DeleteDatabase().CreateDatabase();
        }

        int RunStarAdmin(string args, params int[] allowedExits) {
            var exits = new[] { 0 };
            if (allowedExits != null) {
                var l = new List<int>(allowedExits);
                l.Add(0);
                exits = l.ToArray();
            }

            var ps = new ProcessStartInfo() {
                FileName = "staradmin",
                Arguments = args,
                CreateNoWindow = true,
                UseShellExecute = false
            };
            var p = Process.Start(ps);
            p.WaitForExit();

            if (!exits.Contains(p.ExitCode)) {
                throw new Exception($"'staradmin {args}' exited with unexpected code {p.ExitCode}");
            }

            return p.ExitCode;
        }
    }
}