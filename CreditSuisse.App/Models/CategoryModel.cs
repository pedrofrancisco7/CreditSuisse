using System;

namespace CreditSuisse.App.Models
{
    public class CategoryModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public string Sector { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
