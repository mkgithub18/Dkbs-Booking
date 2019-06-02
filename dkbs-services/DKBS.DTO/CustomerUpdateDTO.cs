using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.DTO
{
    public class CustomerUpdateDTO
    {
        [Required(ErrorMessage = "Company Name is required.")]
        public string CompanyName { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public string PostNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public bool StateAgreement { get; set; }
        [Required]
        public string IndustryCode { get; set; }
        [JsonIgnore]
        public int SharePointId { get; set; }

    }
}
