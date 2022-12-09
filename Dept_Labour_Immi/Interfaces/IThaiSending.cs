using Dept_Labour_Immi.Models;

namespace Dept_Labour_Immi.Interfaces
{
    public interface IThaiSending
    {
        Task<List<ThaiSending>> GetListThaiSending();
        Task<ThaiSending> GetThaiSendingByID(string id);
        Task<int> createThaiSending(ThaiSending model);
        Task<int> UpdateThaiSending(ThaiSending model);
    }
}
