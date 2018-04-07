using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace SAMSVX.ImportEngine
{
    public class FileLoader
    {
        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public FileLoader()
        {

        }

        public FileLoader(string filePath)
        {
            this.filePath = filePath;
        }

        public void Load(DataTable dt)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            string provider = GetProvider(fileInfo);

            using (OleDbConnection oleDbConn = new OleDbConnection(provider))
            {
                string query = GetQuery(fileInfo);
                OleDbDataAdapter oleDbAdt = new OleDbDataAdapter(query, oleDbConn);

                try
                {
                    oleDbAdt.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new FileLoadException(ex.Message, ex);
                }
            };
        }

        private string GetQuery(FileInfo fileInfo)
        {
            string query = string.Empty;
            if (IsCsvExtension(fileInfo))
                query = string.Format("SELECT * FROM [{0}]", fileInfo.Name);
            else if (IsXlsExtension(fileInfo) || IsXlsxExtension(fileInfo))
                query = string.Format("SELECT * FROM [Sheet1$]");
            return query;
        }

        private string GetProvider(FileInfo fileInfo)
        {
            string provider = string.Empty;
            if (IsCsvExtension(fileInfo))
                provider = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + fileInfo.DirectoryName + "; Extended Properties='Text;HDR=YES;FMT=Delimited;';";
            else if (IsXlsExtension(fileInfo))
                provider = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + fileInfo.FullName + "; Extended Properties=Excel 8.0";
            else if (IsXlsxExtension(fileInfo))
                provider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + fileInfo.FullName + "; Extended Properties=Excel 12.0";
            else
                throw new OtherFormatException();

            return provider;
        }

        private static bool IsXlsxExtension(FileInfo fileInfo)
        {
            return fileInfo.Extension == ".xlsx";
        }

        private bool IsCsvExtension(FileInfo fileInfo)
        {
            return fileInfo.Extension == ".csv";
        }

        private bool IsXlsExtension(FileInfo fileInfo)
        {
            return fileInfo.Extension == ".xls";
        }
    }
}
