using System;
using System.Collections.Generic;
using System.Text;

namespace emlParshing
{
    public static class Global
    {
        public static string configFileName = "config.txt";

        public struct ConfigOptionText
        {
            public string TagetDirectory;
            public string[] CutLineDelimiters;
            public string ExportFileName;
            public string[] NotWriteStrings;
        }
    }
}
