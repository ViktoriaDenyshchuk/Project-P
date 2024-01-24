
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SweetCreativity1.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity1.Core.Entities
{
    public class User : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public string UserName { get; set; }
        public string? Email { get; set; }
        //public string Password { get; set; } 
        public string? FullName { get; set; }
        public int? PhoneNumber { get; set; }
        public string? UrlSocialnetwork { get; set; }
        public string? CoverPath { get; set; } = "\\img\\user\\no_cover.jpg";
        [NotMapped]
        public IFormFile? CoverFile { get; set; }
        //
        public int TotalListings { get; set; }
        public int TotalSales { get; set; }
        public int MostSoldProductId { get; set; }
        public int LeastSoldProductId { get; set; }
        public decimal SalePrice { get; set; }
        //
        public virtual ICollection<Listing>? Listings { get; set; } 
        public virtual ICollection<Rating>? Ratings { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Response>? Responses { get; set; }
        public virtual ICollection<Construction>? Constructions { get; set; }
        public virtual List<Favorite>? Favorites { get; set; } = new List<Favorite>();
    
}
}