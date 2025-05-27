using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    //public record ProductDTO(int Id, string CategoryName,string ProductName,  string ProductDescription, int? Price, string ImagePath);
    public record ProductDTO(
int Id = 0,
string CategoryName = null,
string ProductName = null,
string ProductDescription = null,
int? Price = null,
string ImagePath = null
);
}
