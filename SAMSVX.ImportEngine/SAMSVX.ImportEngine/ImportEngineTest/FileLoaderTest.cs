using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SAMSVX.ImportEngine;

namespace ImportEngineTest
{
    [TestClass]
    public class FileLoaderTest
    {
        readonly string CSV_FILE_PATH = @".\Forms\Sample_10Rows.csv";
        readonly string XLS_FILE_PATH = @".\Forms\Sample_10Rows.xls";
        readonly string XLSX_FILE_PATH = @".\Forms\Sample_10Rows.xlsx";
        readonly string INVALID_FILE_PATH = @"F:\test\Sample.csv";
        readonly string OTHER_FILE_PATH = @".\Forms\Sample_OtherFormat.doc";

        FileLoader fileLoader;

        [TestInitialize]
        public void TestInitialize()
        {
            //fileLoader = new FileLoader();
        }

        /// <summary>
        /// 생성자 테스트
        /// </summary>
        [TestMethod]
        public void TestFileLoader()
        {

        }

        /// <summary>
        /// 생성자 테스트 : 파일 경로 파라메타 넘겨주기
        /// </summary>
        [TestMethod]
        public void TestFileLoader_FilePathParameterPassing()
        {
            string filePath = @"C:\test.csv";
            fileLoader = new FileLoader(filePath);

            Assert.AreEqual(filePath, fileLoader.FilePath);
        }

        /// <summary>
        /// 파일 로드 테스트 : CSV 파일 읽어오기
        /// </summary>
        [TestMethod]
        public void TestLoad_CSV()
        {
            fileLoader = new FileLoader(CSV_FILE_PATH);

            DataTable dataList = new DataTable();
            fileLoader.Load(dataList);

            AssertFileLoad(dataList);
        }

        /// <summary>
        /// 파일 로드 테스트 : XLS 파일 읽어오기
        /// </summary>
        [TestMethod]
        public void TestLoad_XLS()
        {
            fileLoader = new FileLoader(XLS_FILE_PATH);

            DataTable dataList = new DataTable();
            fileLoader.Load(dataList);

            AssertFileLoad(dataList);
        }

        /// <summary>
        /// 파일 로드 테스트 : XLSX 파일 읽어오기
        /// </summary>
        [TestMethod]
        public void TestLoad_XLSX()
        {
            fileLoader = new FileLoader(XLSX_FILE_PATH);

            DataTable dataList = new DataTable();
            fileLoader.Load(dataList);

            AssertFileLoad(dataList);
        }

        /// <summary>
        /// 파일 로드 테스트 : 잘못된 경로 입력
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void TestLoad_InvaildPath()
        {
            fileLoader = new FileLoader(INVALID_FILE_PATH);

            DataTable dataList = new DataTable();
            fileLoader.Load(dataList);
        }

        /// <summary>
        /// 파일 로드 테스트 : 다른 형식의 파일
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(OtherFormatException))]
        public void TestLoad_OtherFormat()
        {
            fileLoader = new FileLoader(OTHER_FILE_PATH);

            DataTable dataList = new DataTable();
            fileLoader.Load(dataList);
        }

        private void AssertFileLoad(DataTable dataList)
        {
            Assert.AreEqual(10, dataList.Rows.Count);
            Assert.AreEqual("Code1", dataList.Rows[0][0].ToString());
            Assert.AreEqual("Name1", dataList.Rows[0][1].ToString());
            Assert.AreEqual("SiteCode1", dataList.Rows[0][2].ToString());
        }
    }
}
