using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolforbTestTask.Data.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Item
    {
        public string ReceiptGuid { get; set; }
        public string ResourceName { get; set; }
        public string MeasureUnitName { get; set; }
        public object Quantity { get; set; }
    }

    public class Receipt
    {
        public string Guid { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
    }

    public class Root
    {
        public List<Receipt> Receipts { get; set; }
        public List<Item> Items { get; set; }
    }


}
