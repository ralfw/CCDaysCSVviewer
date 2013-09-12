using System;
using System.Linq;
using System.Collections.Generic;

namespace CSVviewer.domäne
{
    class Blättern
    {
        private const int SEITENLÄNGE = 4;

        private int _zeilenindex_letzte_seite = 1;


        public void Auf_erste_Seite(IEnumerable<string> alle_Zeilen)
        {
            var seitenzeilen = alle_Zeilen.Take(1 + SEITENLÄNGE);

            _zeilenindex_letzte_seite = 1;

            Seite(seitenzeilen);
        }


        public void Auf_letzte_Seite(IEnumerable<string> alle_Zeilen)
        {
            var buffer = alle_Zeilen.ToList();
            var überschrift = buffer[0];

            var nDatensätze = buffer.Count - 1;
            var nSeiten = nDatensätze / SEITENLÄNGE;
            _zeilenindex_letzte_seite = nSeiten*SEITENLÄNGE + 1;

            var seitenlänge_letzte_seite = buffer.Count - _zeilenindex_letzte_seite;
            var seitenzeilen = buffer.GetRange(_zeilenindex_letzte_seite, seitenlänge_letzte_seite);

            Seite(new[]{überschrift}.Union(seitenzeilen));
        }


        public void Auf_nächste_Seite(IEnumerable<string> alle_Zeilen)
        {
            var buffer = alle_Zeilen.ToList();
            var überschrift = buffer[0];

            _zeilenindex_letzte_seite += SEITENLÄNGE;
            if (_zeilenindex_letzte_seite + SEITENLÄNGE -1 < buffer.Count)
            {
                var seitenzeilen = buffer.GetRange(_zeilenindex_letzte_seite, SEITENLÄNGE);
                Seite(new[] { überschrift }.Union(seitenzeilen));
            }
            else
                Auf_letzte_Seite(alle_Zeilen);
        }


        public void Auf_vorherige_Seite(IEnumerable<string> alle_Zeilen)
        {
            var buffer = alle_Zeilen.ToList();
            var überschrift = buffer[0];

            _zeilenindex_letzte_seite -= SEITENLÄNGE;
            if (_zeilenindex_letzte_seite >= 1)
            {
                var seitenzeilen = buffer.GetRange(_zeilenindex_letzte_seite, SEITENLÄNGE);
                Seite(new[] { überschrift }.Union(seitenzeilen));
            }
            else
                Auf_erste_Seite(alle_Zeilen);  
        }


        public event Action<IEnumerable<string>> Seite;
    }
}
