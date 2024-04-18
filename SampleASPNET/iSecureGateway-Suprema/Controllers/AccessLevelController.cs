using AutoMapper;
using iSecureGateway_Suprema.Commons.Http.Response;
using iSecureGateway_Suprema.DTO;
using iSecureGateway_Suprema.Interfaces;
using iSecureGateway_Suprema.Models;
using Microsoft.AspNetCore.Mvc;

namespace iSecureGateway_Suprema.Controllers
{
    [ApiController]
    [Route("api/access-levels")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AccessLevelController : ControllerBase
    {
        private readonly ILogger<AccessLevelController> logger;
        private readonly IAccessLevelService accessLevelService;
        private readonly IAccessScheduleService accessScheduleService;
        private readonly IMapper mapper;

        public AccessLevelController(ILogger<AccessLevelController> logger, IAccessLevelService accessLevelService, IAccessScheduleService accessScheduleService, IMapper mapper)
        {
            this.logger = logger;
            this.accessLevelService = accessLevelService;
            this.accessScheduleService = accessScheduleService;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetAccessLevelList")]
        public async Task<IActionResult> GetAccessLevelList()
        {
            logger.LogDebug("AccessLevelController >>> GetAccessLevelList");

            var accessLevelList = mapper.Map<ICollection<AccessLevelDto>>(await accessLevelService.RetrieveAccessLevelList());

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, accessLevelList));
        }

        [HttpGet("{code}", Name = "GetAccessLevel")]
        public async Task<IActionResult> GetAccessLevel(string code)
        {
            logger.LogInformation("AccessLevelController >>> GetAccessLevel");

            var accessLevel = mapper.Map<AccessLevelDto>(await accessLevelService.RetrieveAccessLevel(code));

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, accessLevel));
        }

        [HttpPost(Name = "AddAccessLevel")]
        public async Task<IActionResult> AddAccessLevel([FromBody] AccessLevelDto accessLevelDto)
        {
            logger.LogInformation("AccessLevelController >>> AddAccessLevel");

            var accessLevel = mapper.Map<AccessLevel>(accessLevelDto);

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, mapper.Map<AccessLevelDto>(await accessLevelService.RegistAccessLevel(accessLevel))));
        }


        [HttpPut("{code}", Name = "UpdateAccessLevel")]
        public async Task<IActionResult> UpdateAccessLevel(string code, [FromBody] AccessLevelDto accessLevelDto)
        {
            logger.LogDebug("AccessLevelController >>> UpdateAccessLevel");

            var findAccessLevel = await accessLevelService.RetrieveAccessLevel(code);

            if (findAccessLevel == null)
            {
                return NotFound(new ApiResponseBody<object>(ApiResponse.NOT_FOUND));
            }
            else
            {
                findAccessLevel.Name = accessLevelDto.Name;
            }

            await accessLevelService.UpdateAccessLevel(mapper.Map<AccessLevel>(findAccessLevel));

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS));
        }


        [HttpDelete("{code}", Name = "DeleteAccessLevel")]
        public async Task<IActionResult> DeleteAccessLevel(string code)
        {
            logger.LogInformation("AccessLevelController >>> DeleteAccessLevel");

            var findAccessLevel = await accessLevelService.RetrieveAccessLevel(code);

            if (findAccessLevel == null)
            {
                return NotFound(new ApiResponseBody<object>(ApiResponse.NOT_FOUND));
            }

            await accessLevelService.DeleteAccessLevel(findAccessLevel);

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS));
        }
    }
}
