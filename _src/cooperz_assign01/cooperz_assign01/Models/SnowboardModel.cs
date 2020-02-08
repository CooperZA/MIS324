using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cooperz_assign01.Models
{
    public class SnowboardModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Board Model")]
        public string ModelID { get; set; }

        [Required]
        public string ExperienceLevel { get; set; }

        [Required]
        public string State { get; set; }

        public bool DiscountStudent { get; set; }

        public bool DiscountSenior { get; set; }

        public bool DiscountGoldClub { get; set; }
    }

    public class CustomerOrderModel
    {
        // board model
        public string ModelName { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public double ModelPrice { get; set; }

        // surcharges
        [Display(Name = "Experience Surcharge %")]
        [DisplayFormat(DataFormatString = "{0:P0}")] // percentage w/o decimals
        public double ExperienceSurchargePercent { get; set; }

        [Display(Name = "Experience Surcharge Dollars")]
        [DataType(DataType.Currency)]
        public double ExperienceSurchargeDollars { get; set; }

        // discounts
        [Display(Name ="Discounts Applied")]
        public string DiscountsTaken { get; set; }

        [Display(Name = "Discounts %")]
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public double DiscountsPercent { get; set; }

        [Display(Name = "Discount in Dollars")]
        [DataType(DataType.Currency)]
        public double DiscountDollars { get; set; }
        // totals
        [DataType(DataType.Currency)]
        public double Subtotal { get; set; }

        [Display(Name = "Tax Rate Applied")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double TaxPercent { get; set; }

        [Display(Name = "Tax")]
        [DataType(DataType.Currency)]
        public double TaxDollars { get; set; }

        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public double TotalPrice { get; set; }
    }
}