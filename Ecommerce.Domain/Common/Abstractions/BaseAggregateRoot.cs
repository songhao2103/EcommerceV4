using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV4.Domain.Common.Abstractions
{
    public abstract class BaseAggregateRoot<TId> : BaseEntity<TId>
    {
    }
}
