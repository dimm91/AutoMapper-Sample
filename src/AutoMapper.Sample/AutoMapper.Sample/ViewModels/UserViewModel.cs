using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapper.Sample.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string FullAddress { get; set; }
        public string PropertyTobeIgnored { get; set; }
        public string Nullable { get; set; }
    }
}
