using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface IFormRepository
    {
        IQueryable<Forms> Collection();
        void Insert(Forms forms);
        void Commit();
        Forms Find(Guid Id);
        void Update(Forms user);
        void Delete(Guid Id);
        List<FormsViewModel> GetForm();
        FormsViewModel GetFormsById(Guid Id);
    }
}
