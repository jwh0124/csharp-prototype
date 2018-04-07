using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAMSVX.ImportEngine;

namespace ImportEngineTest
{
    public class DataImportDummy : DataImporter
    {
        public DataImportDummy()
            : base() { }

        public DataImportDummy(string filePath)
            : base(filePath) { }

        protected override void Operation(DataTable dt)
        {

        }
    }
}
