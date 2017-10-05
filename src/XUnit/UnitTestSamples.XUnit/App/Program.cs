using AppLibrary;
using Starcounter;
using System;

namespace App {

    [Database] public class Started {
        public DateTime Time { get; set; }
    }

    public class Program {
        static void Main(string[] args) {
            Db.Transact(() => {
                new Person() {
                    FirstName = "Per",
                    LastName = "Samuelsson"
                };
                new Started() { Time = DateTime.UtcNow };
            });
        }
    }
}
