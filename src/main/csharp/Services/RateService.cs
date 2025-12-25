using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentralizedRatesHub.Services
{
    public interface IRateService
    {
        Task<RateDto> CreateRateAsync(RateDto rateDto);
        Task<RateDto> GetRateByIdAsync(int id);
        Task<IEnumerable<RateDto>> GetAllRatesAsync();
    }

    public class RateService : IRateService
    {
        private readonly IRateRepository _rateRepository;

        public RateService(IRateRepository rateRepository)
        {
            _rateRepository = rateRepository;
        }

        public async Task<RateDto> CreateRateAsync(RateDto rateDto)
        {
            // Implementation for creating a rate
            return await _rateRepository.CreateRateAsync(rateDto);
        }

        public async Task<RateDto> GetRateByIdAsync(int id)
        {
            // Implementation for getting a rate by ID
            return await _rateRepository.GetRateByIdAsync(id);
        }

        public async Task<IEnumerable<RateDto>> GetAllRatesAsync()
        {
            // Implementation for getting all rates
            return await _rateRepository.GetAllRatesAsync();
        }
    }
}
