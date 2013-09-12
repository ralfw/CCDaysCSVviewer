using System;
using System.Collections.Generic;
using System.Linq;

namespace CSVviewer.dialoge
{
    class UI
    {
        public void Anzeigen(IEnumerable<string> zeilen)
        {
            Seite_ausgeben(zeilen);
            Event_loop();
        }


        private static void Seite_ausgeben(IEnumerable<string> zeilen)
        {
            Console.WriteLine();
            Console.WriteLine();
            zeilen.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
            Console.Write("F(irst, N(ext, P(rev, L(ast, eX(it: ");
        }


        // Die Event-Loop ist eine Krücke und ist nur nötig in einer Konsolenanwendung,
        // bei der das UI einerseits immer wieder anzeigt und andererseits immer wieder Befehle entgegennimmt.
        // "Event-Loop" heißt es, um anzuzeigen, dass es darum geht, wie bei einem GUI Events der Umwelt zu fangen und
        // weiterzuleiten.
        private bool _event_loop_gestartet;
        
        void Event_loop()
        {
            if (_event_loop_gestartet) return;
            _event_loop_gestartet = true;
            
            while (true)
            {
                var cmd = char.ToLower(Console.ReadKey().KeyChar);

                switch (cmd)
                {
                    case 'x':
                        return;
                        break;
                    case 'f':
                        Erste_Seite();
                        break;
                    case 'l':
                        Letzte_Seite();
                        break;
                    case 'n':
                        Nächste_Seite();
                        break;
                    case 'p':
                        Vorherige_Seite();
                        break;
                }
            }
        }


        public event Action Erste_Seite;
        public event Action Letzte_Seite;
        public event Action Nächste_Seite;
        public event Action Vorherige_Seite;
    }
}
