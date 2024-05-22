using Middleware.Pagination;
using User.Model;

namespace User.Interface
{
    public interface IUserService
    {
        Task<UserProfileModel> FindUserByIDAsync(int id);
        Task RegisterAsync(UserProfileModel userRegisterParam);
        PagingResponse<UserProfileModel> GetPagingData(PagingRequest pageRequest);

    }
}
