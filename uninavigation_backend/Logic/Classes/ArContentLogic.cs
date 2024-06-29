using System;
using uninavigation_backend.Logic.Interfaces;
using uninavigation_backend.Models;
using uninavigation_backend.Repositories.Interfaces;

namespace uninavigation_backend.Logic.Classes
{
    public class ArContentLogic : IArContentLogic
	{
        private readonly IArContentRepository _arRepository;

		public ArContentLogic(IArContentRepository arRepository)
		{
            _arRepository = arRepository;
		}

        public async Task<IEnumerable<Ar_content>> GetAllContentsAsync()
        {
            return await _arRepository.GetAllContentAsync();
        }

        public async Task<Ar_content> GetContentByIdAsync(int arContentId)
        {
            return await _arRepository.GetContentByIdAsync(arContentId);
        }

        public async Task CreateContentAsync(Ar_content ar_Content)
        {
            await _arRepository.AddContentAsync(ar_Content);
        }

        public async Task UpdateContentAsync(Ar_content ar_Content)
        {
            await _arRepository.UpdateContentAsync(ar_Content);
        }

        public async Task DeleteContentAsync(int arContentId)
        {
            await _arRepository.DeleteContentAsync(arContentId);
        }
    }
}

