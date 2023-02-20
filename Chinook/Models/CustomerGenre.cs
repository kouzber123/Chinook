using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public readonly record struct CustomerGenre(string FirstName, string LastName, string Genre, int GenreTotal)
    {
    }
}
