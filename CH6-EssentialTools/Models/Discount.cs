using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH6_EssentialTools.Models
{
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }

    public class DefaultDiscountHelper : IDiscountHelper
    {
        public decimal discountSize;
        //public decimal DiscountSize { get; set; }
        public DefaultDiscountHelper( decimal paramDiscount)
        {
            discountSize = paramDiscount;
        }

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (discountSize / 100m * totalParam));
        }
    }

}