using Eftaskhome1.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eftaskhome1.Models;


    public class Category : BaseEntity
    {
        public string CName { get; set; } // Kategori adı
        public List<Product> Products { get; set; } // Kategoriye ait ürünler
    }