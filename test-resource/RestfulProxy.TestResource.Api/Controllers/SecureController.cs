using Microsoft.AspNetCore.Mvc;
using OwnApt.Authentication.Api.Filter;
using RestfulProxy.TestResource.Objects;
using System.Threading.Tasks;

namespace RestfulProxy.TestResource.Api.Controllers
{
    [Route("api/[controller]")]
    public class SecureController : Controller
    {
        #region Public Methods

        [HttpDelete]
        [HmacAuthenticationFilter]
        public async Task<IActionResult> Delete()
        {
            var content = new TestResponseDto { Value = "Hello" };
            return await Task.FromResult(Ok(content));
        }

        [HttpGet]
        [HmacAuthenticationFilter]
        public async Task<IActionResult> Get()
        {
            var content = new TestResponseDto { Value = "Hello" };
            return await Task.FromResult(Ok(content));
        }

        [HttpHead]
        [HmacAuthenticationFilter]
        public async Task<IActionResult> Head()
        {
            return await Task.FromResult(Ok());
        }

        [HttpOptions]
        [HmacAuthenticationFilter]
        public async Task<IActionResult> Options()
        {
            var content = new TestResponseDto { Value = "Hello" };
            return await Task.FromResult(Ok(content));
        }

        [HttpPatch]
        [HmacAuthenticationFilter]
        public async Task<IActionResult> Patch([FromBody] TestRequestDto requestDto)
        {
            var content = new TestResponseDto { Value = requestDto.Value };
            return await Task.FromResult(Ok(content));
        }

        [HttpPost]
        [HmacAuthenticationFilter]
        public async Task<IActionResult> Post([FromBody] TestRequestDto requestDto)
        {
            var content = new TestResponseDto { Value = requestDto.Value };
            return await Task.FromResult(Ok(content));
        }

        [HttpPut]
        [HmacAuthenticationFilter]
        public async Task<IActionResult> Put([FromBody] TestRequestDto requestDto)
        {
            var content = new TestResponseDto { Value = requestDto.Value };
            return await Task.FromResult(Ok(content));
        }

        #endregion Public Methods
    }
}
