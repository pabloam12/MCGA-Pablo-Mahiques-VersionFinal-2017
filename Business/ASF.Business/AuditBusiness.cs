using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Business
{
    public class AuditBusiness
    {
        protected DateTime CreatedOn = DateTime.Now;

        protected int CreatedBy = 1;

        protected DateTime ChangedOn = DateTime.Now;

        protected int ChangedBy = 1;

    }
}
