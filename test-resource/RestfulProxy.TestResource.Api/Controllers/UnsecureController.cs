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
        public async Task<IActionResult> Delete()
        {
            var content = new TestResponseDto { Value = "Hello" };
            return await Task.FromResult(Ok(content));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var content = new TestResponseDto { Value = "Hello" };
            return await Task.FromResult(Ok(content));
        }

        [HttpHead]
        public async Task<IActionResult> Head()
        {
            return await Task.FromResult(Ok());
        }

        [HttpOptions]
        public async Task<IActionResult> Options()
        {
            var content = new TestResponseDto { Value = "Hello" };
            return await Task.FromResult(Ok(content));
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] TestRequestDto requestDto)
        {
            var content = new TestResponseDto { Value = requestDto.Value };
            return await Task.FromResult(Ok(content));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TestRequestDto requestDto)
        {
            var content = new TestResponseDto { Value = requestDto.Value };
            return await Task.FromResult(Ok(content));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TestRequestDto requestDto)
        {
            var content = new TestResponseDto { Value = requestDto.Value };
            return await Task.FromResult(Ok(content));
        }

        #endregion Public Methods
    }
}
