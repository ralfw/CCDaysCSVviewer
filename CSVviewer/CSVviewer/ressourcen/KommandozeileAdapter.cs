using System;

namespace CSVviewer.ressourcen
{
    class KommandozeileAdapter
    {
        public string Dateiname_lesen()
        {
            return Environment.GetCommandLineArgs()[1];
        }
    }
}
