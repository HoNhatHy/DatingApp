using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Domain.Common
{
    public abstract class BaseAuditableEntity
    {
        public int Id {get;set;}
    }
}