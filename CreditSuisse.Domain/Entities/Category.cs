using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditSuisse.Domain.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public string Sector { get; set; }
        public DateTime InsertDate { get; set; }

    }
}
