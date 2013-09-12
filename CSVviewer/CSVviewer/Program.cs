using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVviewer.dialoge;
using CSVviewer.domäne;
using CSVviewer.ressourcen;

namespace CSVviewer
{
    class Program
    {
        static void Main(string[] args)
        {
            // build
            var kmdz = new KommandozeileAdapter();
            var textd = new TextdateiAdapter();
            var blt = new Blättern();
            var tab = new Tabellensatz();
            var ui = new UI();

            var app = new Applikation(kmdz, textd, blt, tab, ui);

            // run
            app.Start();
        }
    }
}
