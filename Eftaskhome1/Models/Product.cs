using Eftaskhome1.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eftaskhome1.Models;

    public class Product : BaseEntity
    {
        public string PName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }
    }
