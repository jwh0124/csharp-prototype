using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMSVX.ImportEngine
{
    public abstract class DataImporter
    {
        FileLoader fileLoader;
        string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public DataImporter()
        {
            fileLoader = new FileLoader();
        }

        public DataImporter(string filePath)
        {
            fileLoader = new FileLoader();
            this.filePath = filePath;
        }

        public void Import()
        {
            DataTable dt = new DataTable();            
            FileLoad(fileLoader, dt);

            Operation(dt);
        }

        private void FileLoad(FileLoader fileLoader, DataTable dt)
        {
            fileLoader.FilePath = filePath;
            fileLoader.Load(dt);
        }

        protected abstract void Operation(DataTable dt);
    }
}
