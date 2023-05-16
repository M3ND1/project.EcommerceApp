﻿using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; }
        /* 
        kolor
        wymiary produktu
        przedzial wiekowy
        waga produktu
        cecha paterialu
        inforamcje o produkcie (varchar na duza ilosc znakow)
        */
        //Relations
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
        public virtual ICollection<ProductOrder>? ProductOrders { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
