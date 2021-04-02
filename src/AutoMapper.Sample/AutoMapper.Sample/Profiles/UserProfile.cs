using AutoMapper.Sample.Dtos;
using AutoMapper.Sample.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapper.Sample.Profiles
{
    /// <summary>
    /// If you set the rules with the profile class this will be automatically add it to the maped types of automapper
    /// </summary>
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserViewModel>()
                .ForMember(uvm => uvm.FullAddress, x =>
                {
                    // Apply a condition which indicate if the mapping should happen
                    x.Condition(udto => !string.IsNullOrEmpty(udto.Address) && !string.IsNullOrEmpty(udto.City) && !string.IsNullOrEmpty(udto.PostalCode));
                    //With this you can build a property from Multiple properties
                    x.MapFrom(udto => udto.Address + ", " + udto.City + ", " + udto.PostalCode);
                })
                //Indicate that the property should not be mapped
                .ForMember(u => u.PropertyTobeIgnored, u => u.Ignore())
                //  If the mapped value is null, then the values specified next will take it's palce.
                //  Worth to mention that if the source Property does not match with the destination property, then it will not work
                .ForMember(u => u.Nullable, u => u.NullSubstitute("This is a substitute value when the property is null"))
                .BeforeMap((udto, uvm) =>
                {
                    //Specify a desired logic to apply before the model is mapped
                    Console.WriteLine("[Before Map]");
                })
                .AfterMap((udto, uvm) =>
                {
                    //Specify a desired logic to apply after the model is mapped
                    Console.WriteLine("[After Map]");
                });
        }
    }
}
