using OpayoPaymentsNet.Infrastructure.Models;

namespace OpayoPaymentsNet.Interfaces
{
    public interface IOpayoRestApiClientService
    {
        Task<OpayoResponse> SendAsync(IOpayoRequest request);
        Task<OpayoResponse<T>> SendAsync<T>(IOpayoRequest request) where T : class;
    }
}