using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ch04MultiPageAmbroson.Models
{
    public class Phone
    {
        //EF Core will configure the database to generate this value
        public int PhoneId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a phone number in the format 'xxx-xxx-xxxx'.")]
        public string Number { get; set; }

        public string Notes { get; set; }

        [Required(ErrorMessage = "Please enter a contact type.")]
        public string ContactId { get; set; }
        public Contact Contact { get; set; }

        public string Slug =>
            Name?.Replace(' ', '-').ToLower() + '-' + Number?.ToString();
    }
}
