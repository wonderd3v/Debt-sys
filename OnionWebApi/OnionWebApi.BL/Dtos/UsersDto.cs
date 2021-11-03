using OnionWebApi.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionWebApi.BL.Dtos
{
    public class UsersDto : BaseDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Dni { get; set; }
    }
}
