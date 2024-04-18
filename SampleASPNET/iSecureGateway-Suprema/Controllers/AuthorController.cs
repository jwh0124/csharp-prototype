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
    [Route("api/authors")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> logger;
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;

        public AuthorController(ILogger<AuthorController> logger, IAuthorService authorService, IMapper mapper)
        {
            this.logger = logger;
            this.authorService = authorService;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetAuthorList")]
        public async Task<IActionResult> GetAuthorList()
        {
            logger.LogDebug("AuthorController >>> GetAuthorList");

            var authorList = mapper.Map<ICollection<AuthorDto>>(await authorService.RetrieveAuthorList());

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, authorList));
        }

        [HttpGet("{code}", Name = "GetAuthor")]
        public async Task<IActionResult> GetAuthor(string code)
        {
            logger.LogInformation("AuthorController >>> GetAuthor");

            var author = mapper.Map<AuthorDto>(await authorService.RetrieveAuthor(code));

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, author));
        }

        [HttpPost(Name = "AddAuthor")]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorDto authorDto)
        {
            logger.LogInformation("AuthorController >>> PostAuthor");

            var author = mapper.Map<Author>(authorDto);

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, mapper.Map<AuthorDto>(await authorService.RegistAuthor(author))));
        }

        [HttpPut("{code}", Name = "PutAuthor")]
        public async Task<IActionResult> PutAuthor(string code, [FromBody] AuthorDto authorDto)
        {
            logger.LogDebug("AuthorController >>> PutAuthor");

            var findAuthor = await authorService.RetrieveAuthor(code);

            if (findAuthor == null)
            {
                return NotFound(new ApiResponseBody<object>(ApiResponse.NOT_FOUND));
            }
            else
            {
                findAuthor.Name = authorDto.Name;
            }

            var test = mapper.Map<Author>(authorDto);

            

            await authorService.UpdateAuthor(mapper.Map<Author>(test));

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS));
        }


        [HttpDelete("{code}", Name = "DeleteAuthor")]
        public async Task<IActionResult> DeleteAuthor(string code)
        {
            logger.LogInformation("AuthorController >>> DeleteAuthor");

            var findAuthor = await authorService.RetrieveAuthor(code);

            if (findAuthor == null)
            {
                return NotFound(new ApiResponseBody<object>(ApiResponse.NOT_FOUND));
            }

            await authorService.DeleteAuthor(findAuthor);


            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS));
        }
    }
}
