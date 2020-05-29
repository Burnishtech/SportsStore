using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTool.Models
{
    public interface IValueCalculator
    {
        decimal ValueProduct(IEnumerable<Product> produts);
    }
}
