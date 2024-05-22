using User.Model;
using User.ParamRequest;

namespace User.Mapper

{
    public static class UserMapper
    {
        public static UserProfileModel MapToUserProfile(this UserRegisterRequest userRegisterRequest)
        {
            return new UserProfileModel()
            {
                Fullname = userRegisterRequest.Fullname,
                Email = userRegisterRequest.Email
            };
        }
    }
}
