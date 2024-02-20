using Api.Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Brand : EntityBase
    {
        public Brand()
        {

        }
        public Brand(string name)
        {
            name = Name;
        }
        public required string Name { get; set; }
    }
}
