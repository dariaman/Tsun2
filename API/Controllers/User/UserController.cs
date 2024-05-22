using Microsoft.AspNetCore.Mvc;
using Middleware.BaseClass;
using Middleware.Pagination;
using User.Interface;
using User.Mapper;
using User.Model;
using User.ParamRequest;


namespace API.Controllers.User
{
    public class UserController(IUserService userService) : MainController
    {
        public readonly IUserService _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest userRegisterParamReq)
        {
            var userProfile = userRegisterParamReq.MapToUserProfile();
            await _userService.RegisterAsync(userProfile);
            return Ok();
        }

        [HttpGet("page")]
        public IActionResult Paging(PagingRequest? pagingRequest)
        {
            BaseResponse response = new();
            pagingRequest ??= new PagingRequest();

            var (isValidRequest, errorList) = pagingRequest.ValidateModel<UserProfileModel>();

            if (isValidRequest)
            {
                response.page = _userService.GetPagingData(pagingRequest);
            }
            else
            {
                response.errorProperty = errorList;
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
