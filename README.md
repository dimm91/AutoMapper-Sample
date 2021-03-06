# AutoMapper-Sample
Automapper sample project

You will need the [Auto mapper](https://www.nuget.org/packages/AutoMapper/) nuget package.

After you installed te package you can register it with:
```c#
            services.AddAutoMapper(x =>
            {
                // If a profile hasn't been set then you can register it like:
                // Add Simple mapping from TestDTO -> UserViewModel
                //x.CreateMap<UserDto, UserViewModel>();
            }, typeof(Startup));
```

You can start already implementing the automapper in the `startup.cs` class. Or if it's better you can add profiles where you can organize your mapping configurations
```c#
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
```

## Resources

* [Nuget](https://www.nuget.org/packages/AutoMapper/)
* [Website](https://automapper.org/)
* [Documentation](https://docs.automapper.org/en/stable/index.html/)
* [Github](https://github.com/AutoMapper/AutoMapper)