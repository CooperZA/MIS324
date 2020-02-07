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
        public double ModelPrice { get; set; }
        // surcharges
        public double ExperienceSurchargePercent { get; set; }
        public double ExperienceSurchargeDollars { get; set; }
        // discounts
        public string DiscountsTaken { get; set; }
        public double DiscountsPercent { get; set; }
        public double DiscountDollars { get; set; }
        // totals
        public double Subtotal { get; set; }
        public double TaxPercent { get; set; }
        public double TaxDollars { get; set; }
        public double TotalPrice { get; set; }
    }
}