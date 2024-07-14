using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Data.Models;
using SocialMedia.Services.ServiceContracts;

namespace SocialMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLike([FromBody] Like like)
        {
            if (like == null)
            {
                return BadRequest();
            }

            await _likeService.AddLikeAsync(like);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike(int id)
        {
            await _likeService.DeleteLikeAsync(id);
            return Ok();
        }

        [HttpGet("post/{postId}/count")]
        public async Task<IActionResult> GetPostLikeCount(int postId)
        {
            var count = await _likeService.GetPostLikeCount(postId);
            return Ok(count);
        }
    }
}
