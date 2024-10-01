using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Propertycheck.Models.Domain;

namespace PropertySales.Models.Domain
{
    public class Broker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrokerId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Username { get;set; }  

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Number { get; set; }
        
        [Required]
        public string Pincode  { get; set; }
        
        [Required]
        public long AadharCard { get; set; }

        // Navigation property to Transactions
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>(); // Initialize

        // Navigation property to BrokerSales
        public virtual ICollection<BrokerSales> BrokerSales { get; set; } = new List<BrokerSales>(); // Initialize

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}

