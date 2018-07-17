using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH6_EssentialTools.Models
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);

    }
}