using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteCreate
    {
        [Required]
        [MinLength(2, ErrorMessage ="Please enter at least two letters titele as minimu length!")]
        [MaxLength(100, ErrorMessage = "You have entered more than allowed characters!")]
        public string Title { get; set; }

        [Required]
        [MaxLength(800)]
        public string Content { get; set; }

        public override string ToString() => Title;

    }
}
