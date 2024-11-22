using BasedProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedProject.DataAccess.IRepositories
{
    public interface ITagRepository
    {
        Tags Find(int TagId);
         void AddTag(Tags Tag);
         void UpdateTag(Tags Tag);
         void DeleteTag(Tags Tag);
         void DeleteTag(int TagId);
         IList<Tags> GetAllTags();
         Tags GetTagByUrlSlug(string urlSlug);
    }
}
