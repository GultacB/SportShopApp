using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.SportShopModel
{
    public class WareHouse
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public SqlMoney PRICE { get; set; }

        public override string ToString()
        {
            return $"Id:{Id};  ProductName:{ProductName};   Quantity:{Quantity};  Price{PRICE}";
        }

    }
}
