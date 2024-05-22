using Master.Interface;
using Master.ParamRequest;
using Master.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Master
{
    public class BankController(IBankService bankService) : MainController
    {
        public readonly IBankService _bankService = bankService;

        [HttpPost("create")]
        public async Task<IActionResult> Create(BankCreateReq bankCreateReq)
        {
            _ = await _bankService.CreateAsync(bankCreateReq);

            return Ok(__response);
        }

        [HttpGet("ddl")]
        public async Task<IActionResult> DropdownList()
        {
            __response.data = await _bankService.DropdownListAsync();

            return Ok(__response);
        }

    }
}
