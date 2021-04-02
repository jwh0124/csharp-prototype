using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Domain;

namespace BLL
{
    public interface IHrinfo
    {
        List<CHrinfo> getHrinfoList(Int32 startRecord, Int32 maxRecords, String sortColumns);
        Int32 GetListCount();
        void SetHrinfoList(CHrinfo hrinfo);
        void DelHrinfoList(CHrinfo hrinfo);
        void UpHrinfoList(CHrinfo hrinfo);
    }

    
}
