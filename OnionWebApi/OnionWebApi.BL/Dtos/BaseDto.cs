using System;
using System.Collections.Generic;
using System.Text;

namespace OnionWebApi.Services.Dtos
{
    public interface IBaseDto
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
    public class BaseDto
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
