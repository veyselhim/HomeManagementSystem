using Core.Entities;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework
{
    public class ApsisContext : DbContext
    {
        public ApsisContext(DbContextOptions options) : base(options)
        {

        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillPayment> BillPayments { get; set; }
        public virtual DbSet<Dues> Dueses { get; set; }
        public virtual DbSet<DuesPayment> DuesPayments { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<OperationClaim> OperationClaims { get; set; }
        public virtual DbSet<UserOperationClaim> UserOperationClaims { get; set; }



    }
}
