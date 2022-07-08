using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //Signature method to limit
    public class Product:IEntity
    {
        //Entity class with properties
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public decimal UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }
        public short ReOrderLevel { get; set; }
        public bool Discontinued { get; set; }

    }
}
