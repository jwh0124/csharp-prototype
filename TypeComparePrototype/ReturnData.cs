using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeComparePrototype
{
    [Serializable]
    public class ReturnData
    {
        private string site = null;

        private string name = null;

        private string status = null;

        private DateTime nowdate = default(DateTime);

        private string commondata1 = null;

        private string commondata2 = null;

        private string commondata3 = null;

        private string commondata4 = null;

        private string commondata5 = null;

        private string rev1 = null;

        private string rev2 = null;

        private string rev3 = null;

        private string rev4 = null;

        private string rev5 = null;

        private string msgID = null;

        private List<int> iid = new List<int>();
    }
}