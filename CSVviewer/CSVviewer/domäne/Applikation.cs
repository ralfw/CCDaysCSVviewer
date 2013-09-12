using System;
using System.Collections.Generic;
using CSVviewer.dialoge;
using CSVviewer.ressourcen;

namespace CSVviewer.domäne
{
    class Applikation
    {
        private readonly KommandozeileAdapter _kmdz;
        private readonly TextdateiAdapter _textd;

        public Applikation(KommandozeileAdapter kmdz, TextdateiAdapter textd, Blättern bltn, UI ui)
        {
            _kmdz = kmdz;
            _textd = textd;

            ui.Erste_Seite += () => Datei_lesen(bltn.Auf_erste_Seite);
            ui.Letzte_Seite += () => Datei_lesen(bltn.Auf_letzte_Seite);
            ui.Nächste_Seite += () => Datei_lesen(bltn.Auf_nächste_Seite);
            ui.Vorherige_Seite += () => Datei_lesen(bltn.Auf_vorherige_Seite);

            bltn.Seite += ui.Anzeigen;

            _start = () => Datei_lesen(bltn.Auf_erste_Seite);
        }


        void Datei_lesen(Action<IEnumerable<string>> alle_Zeilen)
        {
            var dateiname = _kmdz.Dateiname_lesen();
            alle_Zeilen(_textd.Zeilen_lesen(dateiname));
        }


        private readonly Action _start;
        public void Start() { _start(); }
    }
}
