using System.Collections.Generic;
using System.IO;

namespace CSVviewer.ressourcen
{
    class TextdateiAdapter
    {
        public IEnumerable<string> Zeilen_lesen(string dateiname)
        {
            return File.ReadAllLines(dateiname);
        } 
    }
}
