using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity1.Core.Entities
{
    public class Favorite
    {

        public int Id { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public virtual User? User { get; set; }

        [ForeignKey("Listing")]
        public int? ListingId { get; set; }
        public virtual Listing? Listing { get; set; }

    }
}
