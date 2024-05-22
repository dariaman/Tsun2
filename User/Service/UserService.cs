using Middleware.Pagination;
using User.Interface;
using User.Model;

namespace User.Service
{
    public class UserService() : IUserService
    {

        public Task<UserProfileModel> FindUserByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public PagingResponse<UserProfileModel> GetPagingData(PagingRequest pageRequest)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(UserProfileModel userRegisterParam)
        {
            throw new NotImplementedException();
        }
    }
}
