using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMSVX.Utils.Scheduler
{
    public interface IJob
    {
        void Execute();
    }
}
