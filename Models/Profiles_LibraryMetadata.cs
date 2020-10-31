using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ktr_msc_ls1_BCM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class ProfileMetaData

    {
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string Firstname { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string Lastname { get; set; }
        public string Company { get; set; }

       
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public Nullable<int> Phonenumber { get; set; }
        public string Status { get; set; }
   
    }
}