using System;
using uninavigation_backend.Models;

namespace uninavigation_backend.Logic.Interfaces
{
	public interface IArContentLogic
	{
        Task<IEnumerable<Ar_content>> GetAllContentsAsync();
        Task<Ar_content> GetContentByIdAsync(int arContentId);
        Task CreateContentAsync(Ar_content ar_Content);
        Task UpdateContentAsync(Ar_content ar_Content);
        Task DeleteContentAsync(int arContentId);
    }
}

