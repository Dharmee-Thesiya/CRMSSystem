﻿using CRMSSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class TicketViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Title Is Required")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Assigned Is Required")]
        public Guid AssignId { get; set; }
        [Required(ErrorMessage = "Type Is Required")]
        public Guid TypeId { get; set; }
        [Required(ErrorMessage = "Priority Is Required")]
        public Guid PriorityId { get; set; }
        [Required(ErrorMessage = "Status Is Required")]
        public Guid StatusId { get; set; }
        public string Image { get; set; }
        public List<DropDown> AssignDropDown { get; set; }
        public List<DropDown> PriorityDropDown { get; set; }
        public List<DropDown> StatusDropDown { get; set; }
        public List<DropDown> TypeDropDown { get; set; }
        public string AssignTo { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Attachment { get; set; }
        public string FileName { get; set; }
        public List<TicketAttachment> AttachmentList { get; set; }
        public string CreatedbyName { get; set; }
        public int AttachmentCount { get; set; }
        public Guid TicketId { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
