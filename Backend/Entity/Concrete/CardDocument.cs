using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete.MongoDb;

namespace Entity.Concrete
{
    public class CardDocument : MongoDbEntity
    {
        public int UserId { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public DateTime ExpDate { get; set; }
    }

   
}
