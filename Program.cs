using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowDebugData
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) return;

            IEnumerable<DebugEvent> allEvents = Enumerable.Empty<DebugEvent>();

            foreach (string path in args)
            {
                allEvents = allEvents.Concat(DebugEvent.GetEvents(File.ReadAllText(path)));
            }

            foreach (DebugEvent debugEvent in allEvents.OrderBy(e => e.Time).ThenBy(e => e.Count))
            {
                Console.WriteLine(debugEvent.ToString());
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
