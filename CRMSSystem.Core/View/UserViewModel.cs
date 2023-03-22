﻿using CRMSSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class UserViewModel : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public Guid? Id { get; set; }


        [Required]
        public Guid RoleId { get; set; }

        [DisplayName("Role Name")]
        public string RoleName { get; set; }
        public List<DropDown> RoleDropDown { get; set; }

    }
    public class DropDown
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

