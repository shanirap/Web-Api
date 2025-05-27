using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
        public record RegisterUserDTO(int Id, string FIRSTNAME, string LASTNAME, string PASSWORD, string USERNAME);
    
}
