using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Core.Domain.Catalog
{
    public class Product : BaseEntity
    {
        public string Name
        {
            get; set;
        }

        public string ShortDescription
        {
            get; set;
        }

        public string FullDescription
        {
            get; set;
        }

        public decimal Price
        {
            get; set;
        }

        public decimal OldPrice
        {
            get; set;
        }

        public decimal SpecialPrice
        {
            get; set;
        }
    }
}
