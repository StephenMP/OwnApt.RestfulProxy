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
        public async Task<IActionResult> DeleteAsync()
        {
            var content = new TestResponseDto { Value = "Hello" };
            return await Task.FromResult(Ok(content));
        }

        [HttpGet]
        [HmacAuthenticationFilter]
        public async Task<IActionResult> GetAsync()
        {
            var content = new TestResponseDto { Value = "Hello" };
            return await Task.FromResult(Ok(content));
        }

        [HttpHead]
        [HmacAuthenticationFilter]
        public async Task<IActionResult> HeadAsync()
        {
            return await Task.FromResult(Ok());
        }

        [HttpOptions]
        [HmacAuthenticationFilter]
        public async Task<IActionResult> OptionsAsync()
        {
            var content = new TestResponseDto { Value = "Hello" };
            return await Task.FromResult(Ok(content));
        }

        [HttpPatch]
        [HmacAuthenticationFilter]
        public async Task<IActionResult> PatchAsync([FromBody] TestRequestDto requestDto)
        {
            var content = new TestResponseDto { Value = requestDto.Value };
            return await Task.FromResult(Ok(content));
        }

        [HttpPost]
        [HmacAuthenticationFilter]
        public async Task<IActionResult> PostAsync([FromBody] TestRequestDto requestDto)
        {
            var content = new TestResponseDto { Value = requestDto.Value };
            return await Task.FromResult(Ok(content));
        }

        [HttpPut]
        [HmacAuthenticationFilter]
        public async Task<IActionResult> PutAsync([FromBody] TestRequestDto requestDto)
        {
            var content = new TestResponseDto { Value = requestDto.Value };
            return await Task.FromResult(Ok(content));
        }

        #endregion Public Methods
    }
}
