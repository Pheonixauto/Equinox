using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.ViewModels
{
    public class LearningViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Universe is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string University { get; set; }
    }
}
