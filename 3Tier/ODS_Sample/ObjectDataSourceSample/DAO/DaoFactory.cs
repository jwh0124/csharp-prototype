using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;

namespace DAO
{
    public class DaoFactory
    {
        private static object syncLock = new object();
        private static ISqlMapper mapper = null;

        public static ISqlMapper Instance
        {
            get
            {
                try
                {
                    if (mapper != null) return mapper;

                    lock (syncLock)
                    {
                        DomSqlMapBuilder dom = new DomSqlMapBuilder();

                        XmlDocument sqlMapConfig = Resources.GetEmbeddedResourceAsXmlDocument("Config.SqlMap.config, DAO");

                        mapper = dom.Configure(sqlMapConfig);
                    }

                    return mapper;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
