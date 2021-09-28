using Entity.Abstract;

namespace Entity.DTOs.Aparment
{
    public class ApartmentDetailDto : IDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public string Block { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Mail { get; set; }
    }
}
