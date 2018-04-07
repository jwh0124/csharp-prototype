using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SAMSVX.ImportEngine;

namespace ImportEngineTest
{
    [TestClass]
    public class DataImporterTest
    {
        readonly string FILE_PATH = @".\Forms\Sample_10Rows.csv";

        DataImporter dataImporter;

        [TestInitialize]
        public void TestInitialize()
        {
            dataImporter = new DataImportDummy(FILE_PATH);
        }

        /// <summary>
        /// 생성자 테스트
        /// </summary>
        [TestMethod]
        public void TestDataImporter()
        {

        }

        /// <summary>
        /// 데이터 임포트 테스트
        /// </summary>
        [TestMethod]
        public void TestImport_Import()
        {
            dataImporter.Import();
        }

        /// <summary>
        /// 데이터 임포트 테스트 : 필수 데이터를 입력하지 않음 (3번째 행, 2번째 필드)
        /// </summary>
        [TestMethod]
        public void TestImport_DoNotInputTheRequiredFields()
        {
            dataImporter = new DataImporterRequiredFieldException(FILE_PATH);

            int row = 0, column = 0;
            try
            {
                dataImporter.Import();
            }
            catch (RequiredFieldException ex)
            {
                row = ex.Row;
                column = ex.Column;
            }

            Assert.AreEqual(3, row);
            Assert.AreEqual(2, column);
        }

        /// <summary>
        /// 데이터 임포트 테스트 : 데이터 형식이 맞지 않음 (5번째 행, 3번째 필드)
        /// </summary>
        [TestMethod]
        public void TestImport_DoesNotMatchTheDataFormat()
        {
            dataImporter = new DataImportDataFormatException(FILE_PATH);

            int row = 0, column = 0;
            try
            {
                dataImporter.Import();
            }
            catch (DataFormatException ex)
            {
                row = ex.Row;
                column = ex.Column;
            }

            Assert.AreEqual(5, row);
            Assert.AreEqual(3, column);
        }

        /// <summary>
        /// 데이터 임포트 테스트 : 구성되지 않은 데이터 참조 (1번째 행, 1번째 필드)
        /// </summary>
        [TestMethod]
        public void TestImport_ThrowException()
        {
            dataImporter = new DataImportNotConfiguredDataReferenceException(FILE_PATH);

            int row = 0, column = 0;
            try
            {
                dataImporter.Import();
            }
            catch (NotConfiguredDataReferenceException ex)
            {
                row = ex.Row;
                column = ex.Column;
            }

            Assert.AreEqual(1, row);
            Assert.AreEqual(1, column);
        }

        
    }
}
