using AutoMapper.Sample.Dtos;
using AutoMapper.Sample.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapper.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAutomapperUser()
        {
            var userDto = new UserDto(1, "Frank", "west", "frank.west@mail.com", "Address", "Leipzig", "12345");

            //List all the mapped types configured.
            //foreach (var typeMap in _mapper.ConfigurationProvider.GetAllTypeMaps())
            //{
            //    Console.WriteLine($"{typeMap.SourceType.Name} -> {typeMap.DestinationType.Name}");
            //}

            return Ok(_mapper.Map<UserViewModel>(userDto));
        }
    }
}
