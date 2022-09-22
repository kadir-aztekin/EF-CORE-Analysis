using System;
using System.Collections.Generic;

namespace Ef_Core_Analysis
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
