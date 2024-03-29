﻿using CRMSSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class PermissionViewModel : BaseEntity
    {
        [Required]
        public bool View { get; set; }
        [Required]
        public bool Insert { get; set; }
        [Required]
        public bool Update { get; set; }
        [Required]
        public bool Delete { get; set; }
        [Required]
        public Guid RoleId { get; set; }
        [Required]
        public Guid FormId { get; set; }
        public string FormName { get; set; }

        public bool All { get; set; }
        public string NavigateURL { get; set; }
        public Guid? ParentFormId { get; set; }

    }
}
