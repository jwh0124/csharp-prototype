using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo.DB;
using System.Configuration;

namespace Test0509.Xpo
{
    public static class XpoHelper
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static UnitOfWork GetNewUnitOfWorkINTF()
        {
            return new UnitOfWork(DataLayerINTF);
        }

        public static Session GetNewSessionINTF()
        {
            return new Session(DataLayerINTF);
        }
        private readonly static object lockObject = new object();
        static IDataLayer fDataLayerINTF;
        static IDataLayer DataLayerINTF
        {
            get
            {
                if (fDataLayerINTF == null)
                {
                    lock (lockObject)
                    {
                        fDataLayerINTF = GetDataLayerINTF();
                    }
                }
                return fDataLayerINTF;
            }
        }

        private static IDataLayer GetDataLayerINTF()
        {
            // set XpoDefault.Session to null to prevent accidental use of XPO default session
            XpoDefault.Session = null;
            XpoDefault.UseFastAccessors = false;
            XpoDefault.IdentityMapBehavior = IdentityMapBehavior.Strong;

            XPDictionary dict = new ReflectionDictionary();
            IDataStore store = XpoDefault.GetConnectionProvider(GetConnectionString(ConnectionString), AutoCreateOption.SchemaAlreadyExists);
            dict.GetDataStoreSchema(typeof(CardApprovalEntity).Assembly);
            IDataLayer dl = new ThreadSafeDataLayer(dict, store);

            return dl;
        }


        static string GetConnectionString(string Conn)
        {
            string result = Conn;
            result += ";XpoProvider=MSSqlServer";

            return result;
        }
    }
}

