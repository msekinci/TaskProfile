using System;

namespace MSE.TestProfile.DTO.Concrete.UserDTOs
{
    public class UserCreateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
    }
}
