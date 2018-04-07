using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using SAMSVX.ImportEngine;

namespace ImportEngineTest
{
    public class DataImportNotConfiguredDataReferenceException : DataImporter
    {
        public DataImportNotConfiguredDataReferenceException()
            : base() { }

        public DataImportNotConfiguredDataReferenceException(string filePath)
            : base(filePath) { }

        protected override void Operation(DataTable dt)
        {
            throw new NotConfiguredDataReferenceException(1, 1);
        }
    }
}
