using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAMSVX.ImportEngine;

namespace ImportEngineTest
{
    public class DataImporterRequiredFieldException : DataImporter
    {
        public DataImporterRequiredFieldException()
            : base() { }

        public DataImporterRequiredFieldException(string filePath)
            : base(filePath) { }

        protected override void Operation(DataTable dt)
        {
            throw new RequiredFieldException(3, 2);
        }
    }
}
