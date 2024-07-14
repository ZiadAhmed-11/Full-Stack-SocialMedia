using Microsoft.AspNetCore.Mvc;
using SocialMedia.Data.Models;
using SocialMedia.Services.ServiceContracts;
using SocialMediaApi.Filters.ActionFilters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] Post post)
        {
            if (post.UserId == Guid.Empty)
            {
                return BadRequest("UserId cannot be empty.");
            }

            await _postService.AddPostAsync(post);
            return CreatedAtAction(nameof(GetPostById), new { postId = post.PostId }, post);
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public async Task<ActionResult<Post>> GetPostById(int postId)
        {
            var post = await _postService.GetPostById(postId);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpGet("user/{userId}")]
        [TypeFilter(typeof(UserPostsListActionFilter))]
        public async Task<ActionResult<List<Post>>> GetAllPostsOfUser(Guid userId)
        {
            var posts = await _postService.GetAllPostsOfUserAsync(userId);
            return Ok(posts);
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            await _postService.DeletePost(postId);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost([FromBody] Post post)
        {
            var updatedPost = await _postService.UpdatePost(post);
            return Ok(updatedPost);
        }
    }
}
