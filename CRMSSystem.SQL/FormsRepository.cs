using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.SQL
{
    public class FormsRepository : IFormRepository
    {
        internal DataContext context;
        internal DbSet<Forms> dbSet;

        public FormsRepository (DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Forms>();
        }
        public IQueryable<Forms> Collection()
        {
            return dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            
            var forms = Find(Id);
            if (context.Entry(forms).State == EntityState.Detached)
            dbSet.Remove(forms);
        }

        public Forms Find(Guid Id)
        {
            return dbSet.Find(Id);
        }
        
        public List<FormsViewModel> GetForm()
         {
            var forms = (from f in context.Form.Where(x => !x.IsDeleted).AsEnumerable()
                         join p in context.Form on f.ParentFormID equals p.Id into fdata
                         from pf in fdata.DefaultIfEmpty()
                         select new FormsViewModel
                         {
                             Id = f.Id,
                             ParentFormID = pf?.ParentFormID,
                             ParentFormName = pf?.Name,
                             FormAccessCode = f.FormAccessCode,
                             DisplayIndex = f.DisplayIndex,
                             Name = f.Name,
                             NavigateURL = f.NavigateURL
                         }).Distinct()
                         .ToList();
            return forms;

        }
      
        public FormsViewModel GetFormsById(Guid Id)
        {
            var forms = (from f in context.Form
                         join p in context.Form on f.ParentFormID equals p.Id
                         into fdata
                         from pf in fdata.DefaultIfEmpty()
                         where !f.IsDeleted && f.Id==Id
                         select new FormsViewModel
                         {
                             Id = f.Id,
                             ParentFormID = f.ParentFormID,
                             ParentFormName = f.Name,
                             FormAccessCode = f.FormAccessCode,
                             DisplayIndex = f.DisplayIndex,
                             Name = f.Name,
                             NavigateURL = f.NavigateURL

                         }).FirstOrDefault();

            return forms;
        }

        public void Insert(Forms forms)
        {
           
            dbSet.Add(forms);
        }

        public void Update(Forms forms)
        {
            dbSet.Attach(forms);
            context.Entry(forms).State = EntityState.Modified;
        }
    }
}
