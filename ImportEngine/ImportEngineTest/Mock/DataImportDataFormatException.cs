using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAMSVX.ImportEngine;

namespace ImportEngineTest
{
    public class DataImportDataFormatException : DataImporter
    {
        public DataImportDataFormatException()
            : base() { }

        public DataImportDataFormatException(string filePath)
            : base(filePath) { }

        protected override void Operation(System.Data.DataTable dt)
        {
            throw new DataFormatException(5, 3);
        }
    }
}
