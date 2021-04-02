using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Domain;
using DAO;

namespace BLL
{
    public class HrinfoImpl : IHrinfo
    {
        public List<Domain.CHrinfo> getHrinfoList(Int32 startRecord, Int32 maxRecords, String sortColumns)
        {
            IHrinfoDao hrinfoDao = new HrinfoDao();
            List<CHrinfo> result = hrinfoDao.getHrinfoList(startRecord, maxRecords, sortColumns);
            return result;
        }

        public Int32 GetListCount()
        {
            IHrinfoDao hrinfoDao = new HrinfoDao();
            Int32 result = hrinfoDao.GetListCount();
            return result;   
        }

        public void SetHrinfoList(CHrinfo hrinfo)
        {
            IHrinfoDao hrinfoDao = new HrinfoDao();
            hrinfoDao.SetHrinfoList(hrinfo);            
        }

        public void DelHrinfoList(CHrinfo hrinfo){
            IHrinfoDao hrinfoDao = new HrinfoDao();
            hrinfoDao.DelHrinfoList(hrinfo);
        }

        public void UpHrinfoList(CHrinfo hrinfo)
        {
            IHrinfoDao hrinfoDao = new HrinfoDao();
            hrinfoDao.UpHrinfoList(hrinfo);
        }
    }
}
