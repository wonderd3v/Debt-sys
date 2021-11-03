using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnionWebApi.Models.Entities
{
    public interface IBaseEntity
    {      
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
