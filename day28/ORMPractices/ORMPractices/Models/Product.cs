using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMPractices.Models
{
 
        public class Product
        {
            public int Id { get; set; }//by default primary key, Also Identity with starting number 1 and increment 1
            public string Name { get; set; } = string.Empty;
            public float Price { get; set; }
            public int Quantity { get; set; }
            public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }//Navigation property will be included in the database

    }


}
