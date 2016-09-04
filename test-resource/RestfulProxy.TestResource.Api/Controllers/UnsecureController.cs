using Microsoft.AspNetCore.Mvc;
using RestfulProxy.TestResource.Objects;
using System.Threading.Tasks;

namespace RestfulProxy.TestResource.Api.Controllers
{
    [Route("api/[controller]")]
    public class UnsecureController : Controller
    {
        #region Public Methods

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync()
        {
            var content = new TestResponseDto { Value = "Hello" };
            return await Task.FromResult(Ok(content));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var content = new TestResponseDto { Value = "Hello" };
            return await Task.FromResult(Ok(content));
        }

        [HttpHead]
        public async Task<IActionResult> HeadAsync()
        {
            return await Task.FromResult(Ok());
        }

        [HttpOptions]
        public async Task<IActionResult> OptionsAsync()
        {
            var content = new TestResponseDto { Value = "Hello" };
            return await Task.FromResult(Ok(content));
        }

        [HttpPatch]
        public async Task<IActionResult> PatchAsync([FromBody] TestRequestDto requestDto)
        {
            var content = new TestResponseDto { Value = requestDto.Value };
            return await Task.FromResult(Ok(content));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TestRequestDto requestDto)
        {
            var content = new TestResponseDto { Value = requestDto.Value };
            return await Task.FromResult(Ok(content));
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] TestRequestDto requestDto)
        {
            var content = new TestResponseDto { Value = requestDto.Value };
            return await Task.FromResult(Ok(content));
        }

        #endregion Public Methods
    }
}
