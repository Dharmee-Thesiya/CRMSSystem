using CRMSSystem.Core.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class FormsViewModel : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string NavigateURL { get; set; }
        public Guid? ParentFormID { get; set; }
        [Required]
        public string FormAccessCode { get; set; }
        [Required]
        public int DisplayIndex { get; set; }
        [Required]
        public string ParentFormName { get; set; }
       
        public List<DropDownParentId> ParentIdDropDown { get; set; }
        
       
        
    }
    public class DropDownParentId
    {
        public Guid ParentFormID { get; set; }
        public string ParentFormName { get; set; }
    }
}
