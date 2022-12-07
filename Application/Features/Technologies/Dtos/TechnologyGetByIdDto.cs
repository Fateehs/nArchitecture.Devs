using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechnologies.Dtos
{
    public class TechnologyGetByIdDto
    {
        public int Id { get; set; }
        public string ProgrammingLanguageName { get; set; }
        public string Name { get; set; }
    }
}
