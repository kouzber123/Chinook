using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public readonly record struct CustomerSpend(int CustomerId, decimal TotalSpend)
    {
    }
}
