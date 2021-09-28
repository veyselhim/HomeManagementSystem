using Entity.Abstract;

namespace Entity.DTOs.Aparment
{
    public class ApartmentAddDto : IDto
    {
        public int UserId { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public string Block { get; set; }
        public bool Status { get; set; }
    }
}
