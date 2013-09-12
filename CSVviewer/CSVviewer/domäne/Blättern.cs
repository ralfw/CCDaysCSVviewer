using System;
using System.Collections.Generic;

namespace CSVviewer.domäne
{
    class Blättern
    {
        private const int SEITENLÄNGE = 4;


        public void Auf_erste_Seite(IEnumerable<string> alle_Zeilen)
        {
            Seite(alle_Zeilen);
        }

        public void Auf_letzte_Seite(IEnumerable<string> alle_Zeilen)
        {
            Seite(alle_Zeilen);
        }

        public void Auf_nächste_Seite(IEnumerable<string> alle_Zeilen)
        {
            Seite(alle_Zeilen);   
        }

        public void Auf_vorherige_Seite(IEnumerable<string> alle_Zeilen)
        {
            Seite(alle_Zeilen);    
        }

        public event Action<IEnumerable<string>> Seite;
    }
}
