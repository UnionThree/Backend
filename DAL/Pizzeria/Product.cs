﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Pizzeria;

[PrimaryKey("ProductId", "Name")]
[Table("products")]
[Index("Name", Name = "products_name_key", IsUnique = true)]
[Index("ProductId", Name = "products_productid_key", IsUnique = true)]
public class Product
{
	[Key]
	[Column("productid")]
	public Guid ProductId { get; set; }

	[Key]
	[Column("name")]
	public string Name { get; set; } = null!;

	[Column("description")]
	public string? Description { get; set; }

	[Column("picture")]
	public string? Picture { get; set; }

	[Column("price", TypeName = "money")]
	public decimal? Price { get; set; }

	[Column("category")]
	public string? Category { get; set; }

	[Column("weight")]
	public double? Weight { get; set; }

	[Column("calories")]
	public double? Calories { get; set; }
	
	[Column("preparationTime")]
	public TimeOnly PreparationTime { get; set; }
	public ICollection<Order> Orders { get; set; } = new List<Order>();
	
	public ICollection<OrdersProducts> OrdersProducts { get; set; } = new List<OrdersProducts>();

	public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
	
	public ICollection<IngredientsProducts> IngredientsProducts { get; set; } = new List<IngredientsProducts>();

	// [InverseProperty("Product")]
	// public virtual ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();
}