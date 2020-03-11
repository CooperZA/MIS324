using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cooperz_assign01.Models
{
    public class MusicModels
    {
    }

    // Description Model/Class
    public class MusicItemModel
    {
        // asin id
        [Key]
        public string ASIN { get; set; }

        // Title
        public string Title { get; set; }

        // Artist
        public string Artists { get; set; }

        // Release date
        public string ReleaseDate { get; set; }

        // Release date DT
        public DateTime ReleaseDateTime { get; set; }

        // List Price
        public double ListPrice { get; set; }

        // Label
        public string Label { get; set; }

        // Editorial review
        public string EditorialReviews { get; set; }

        // number of discs
        public string NumDiscs { get; set; }

        // Number of tracks
        public string NumTracks { get; set; }

        // Detail page url
        public string DetailUrl { get; set; }

        // Availability
        public string Availability { get; set; }

    }

    // Style Model/Class
    public class MusicStyleModel
    {
        // Style ID
        public int styleId { get; set; }

        // Style name
        public string styleName { get; set; }
    }

    // music cart model
    public class MusicCartModel
    {
        public string SessionId { get; set; }
        public string ASIN { get; set; }
        public string Title { get; set; }
        public string Artists { get; set; }
        public double ListPrice { get; set; }
        public int Qty { get; set; }
        public DateTime DateAdded { get; set; }
    }

    // Sign in model
    public class SignInModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }

    // Customer Model
    public class CustomerModel
    {
        [Key]
        public int CustID { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zipcode { get; set; }
    }

    // checkout model
    public class MusicCheckoutModel
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public CustomerModel CustModel { get; set; }
        public List<MusicCartModel> OrderModel { get; set; }
    }
}