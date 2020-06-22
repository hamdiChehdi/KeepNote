using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPageService
    {
        Task<Page> AddPage(Page Page);
        Task<Page[]> GetPages();
        Task<Page> DeletePage(long id);
        Task<Page> UpdatePage(long id, string PageName);
    }
}