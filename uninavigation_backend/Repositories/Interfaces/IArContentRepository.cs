using System;
using uninavigation_backend.Models;

namespace uninavigation_backend.Repositories.Interfaces
{
	public interface IArContentRepository
	{
        Task<IEnumerable<Ar_content>> GetAllContentAsync();
        Task<Ar_content> GetContentByIdAsync(int arContentId);
        Task AddContentAsync(Ar_content ar_Content);
        Task UpdateContentAsync(Ar_content ar_Content);
        Task DeleteContentAsync(int arContentId);
    }
}

