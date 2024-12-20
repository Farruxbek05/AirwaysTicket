using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models;

public class Airline
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public Guid Code { get; set; }
}
