﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Umbraco.Cms.Core.Models.Security
{
    public class LoginModel : PostRedirectModel
    {
        [Required]
        [DataMember(Name = "username", IsRequired = true)]
        public string Username { get; set; }

        [Required]
        [DataMember(Name = "password", IsRequired = true)]
        [StringLength(maximumLength: 256)]
        public string Password { get; set; }

    }
}
