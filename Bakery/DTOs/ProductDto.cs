using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record ProductDto(
        int Id ,
        string CategoryName,
        string ProductName ,
        string ProductDescription ,
        int ? Price ,
        string ImagePath
    );
}
