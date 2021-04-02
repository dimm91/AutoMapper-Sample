using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapper.Sample.Dtos
{
    public class UserDto
    {
        public UserDto(int id, string name, string lastname, string email, string address, string city, string postalCode)
        {
            this.Id = id;
            this.Name = name;
            this.Lastname = lastname;
            this.Email = email;
            this.Address = address;
            this.City = city;
            this.PostalCode = postalCode;
            this.PropertyTobeIgnored = "This value should not appear in the mapped property";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PropertyTobeIgnored { get; set; }
        public string Nullable { get; set; }
    }
}
