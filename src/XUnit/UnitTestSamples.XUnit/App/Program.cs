using Starcounter;
using System;

namespace App {

    [Database] public class Started {
        public DateTime Time { get; set; }
    }

    public class Program {
        static void Main(string[] args) {
            Db.Transact(() => {
                new Started() { Time = DateTime.UtcNow };
            });
        }
    }
}
