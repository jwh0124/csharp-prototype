using AutoMapper;
using iSecureGateway_Suprema.Commons.Http.Response;
using iSecureGateway_Suprema.DTO;
using iSecureGateway_Suprema.Interfaces;
using iSecureGateway_Suprema.Models;
using iSecureGateway_Suprema.Services;
using Microsoft.AspNetCore.Mvc;

namespace iSecureGateway_Suprema.Controllers
{
    [ApiController]
    [Route("api/posts")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> logger;
        private readonly IPostService postService;

        private readonly IAuthorService authorService;
        private readonly IMapper mapper;

        public PostController(ILogger<PostController> logger, IPostService postService, IAuthorService authorService, IMapper mapper)
        {
            this.logger = logger;
            this.postService = postService;
            this.authorService = authorService;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetPostList")]
        public async Task<IActionResult> GetPostList()
        {
            logger.LogDebug("PostController >>> GetPostList");

            var postList = mapper.Map<ICollection<PostDto>>(await postService.RetrievePostList());

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, postList));
        }

        [HttpGet("{code}", Name = "GetPost")]
        public async Task<IActionResult> GetPost(string code)
        {
            logger.LogInformation("PostController >>> GetPost");

            var post = mapper.Map<PostDto>(await postService.RetrievePost(code));

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, post));
        }

        [HttpPost(Name = "AddPost")]
        public async Task<IActionResult> AddPost([FromBody] PostDto postDto)
        {
            logger.LogInformation("PostController >>> PostPost");

            var post = mapper.Map<Post>(postDto);

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, mapper.Map<PostDto>(await postService.RegistPost(post))));
        }

        [HttpPut("{code}", Name = "PutPost")]
        public async Task<IActionResult> PutPost(string code, [FromBody] PostDto postDto)
        {
            logger.LogDebug("PostController >>> PutPost");

            var findPost = await postService.RetrievePost(code);

            if (findPost == null)
            {
                return NotFound(new ApiResponseBody<object>(ApiResponse.NOT_FOUND));
            }
            else
            {
                
                findPost.Name = postDto.Name;
                findPost.Authors = mapper.Map<ICollection<Author>>(postDto.Authors);
            }
            await postService.UpdatePost(findPost);

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS));
        }


        [HttpDelete("{code}", Name = "DeletePost")]
        public async Task<IActionResult> DeletePost(string code)
        {
            logger.LogInformation("PostController >>> DeletePost");

            var findPost = await postService.RetrievePost(code);

            if (findPost == null)
            {
                return NotFound(new ApiResponseBody<object>(ApiResponse.NOT_FOUND));
            }

            await postService.DeletePost(findPost);


            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS));
        }
    }
}
