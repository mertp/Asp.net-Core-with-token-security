using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    //Data transfer objects
    public class UserForLoginDto:IDto
    {
        public String Email { get; set; }
        public String Password { get; set; }

    }
}
