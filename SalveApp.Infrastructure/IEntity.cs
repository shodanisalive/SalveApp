using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalveApp.Infrastructure
{
    public interface IEntity<T> : IAggregateRoot where T : IEquatable<T>
    {
    }
}
