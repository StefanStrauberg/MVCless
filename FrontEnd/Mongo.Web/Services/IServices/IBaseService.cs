using Mongo.Web.Models;
using Mongo.Web.Models.DTOs;

namespace Mongo.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
