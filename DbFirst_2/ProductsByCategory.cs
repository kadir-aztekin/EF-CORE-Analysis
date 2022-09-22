using System;
using System.Collections.Generic;

namespace DbFirst_2
{
    public partial class ProductsByCategory
    {
        public string CategoryName { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? QuantityPerUnit { get; set; }
        public short? UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }
}
