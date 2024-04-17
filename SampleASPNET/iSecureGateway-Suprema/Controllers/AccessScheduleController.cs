using AutoMapper;
using iSecureGateway_Suprema.Commons.Http.Response;
using iSecureGateway_Suprema.Contexts.Handlers;
using iSecureGateway_Suprema.Dtos;
using iSecureGateway_Suprema.Interfaces;
using iSecureGateway_Suprema.Models;
using Microsoft.AspNetCore.Mvc;

namespace iSecureGateway_Suprema.Controllers
{
    [ApiController]
    [Route("api/access-schedules")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AccessScheduleController : ControllerBase
    {
        private readonly ILogger<AccessScheduleController> logger;
        private readonly IAccessScheduleService accessScheduleService;
        private readonly IMapper mapper;
        public AccessScheduleController(ILogger<AccessScheduleController> logger, IAccessScheduleService accessScheduleService, IMapper mapper)
        {
            this.logger = logger;
            this.accessScheduleService = accessScheduleService;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetScheduleGroupList")]
        public async Task<IActionResult> GetScheduleGroupList()
        {
            logger.LogDebug("AccessScheduleController >>> GetScheduleGroupList");

            var accessScheduleList = mapper.Map<ICollection<AccessScheduleDto>>(await accessScheduleService.RetrieveAccessScheduleList());

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, accessScheduleList));
        }

        [HttpGet("{code}", Name = "GetScheduleGroup")]
        public async Task<IActionResult> GetScheduleGroup(string code)
        {
            logger.LogInformation("AccessScheduleController >>> GetScheduleGroup");

            var accessSchedule = mapper.Map<AccessScheduleDto>(await accessScheduleService.RetrieveAccessSchedule(code));

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, accessSchedule));
        }

        [HttpPost(Name = "AddAccessSchedule")]
        public async Task<IActionResult> AddAccessSchedule([FromBody] AccessScheduleDto accessScheduleDto)
        {
            logger.LogInformation("AccessScheduleController >>> AddAccessSchedule");

            var accessSchedule = mapper.Map<AccessScheduleDto>(await accessScheduleService.RegistAccessSchedule(mapper.Map<AccessSchedule>(accessScheduleDto)));

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, accessSchedule));
        }

        [HttpPut("{code}", Name = "UpdateScheduleGroup")]
        public async Task<IActionResult> UpdateScheduleGroup(string code, [FromBody] AccessScheduleDto accessScheduleDto)
        {
            logger.LogDebug("AccessScheduleController >>> UpdateScheduleGroup");

            var findAccessSchedule = await accessScheduleService.RetrieveAccessSchedule(code);

            if (findAccessSchedule == null)
            {
                return NotFound(new ApiResponseBody<object>(ApiResponse.NOT_FOUND));
            }

            findAccessSchedule.Name = accessScheduleDto.Name;

            await accessScheduleService.UpdateAccessSchedule(mapper.Map<AccessSchedule>(findAccessSchedule));

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS));
        }

        [HttpDelete("{code}", Name = "DeleteScheduleGroup")]
        public async Task<IActionResult> DeleteScheduleGroup(string code)
        {
            logger.LogInformation("AccessScheduleController >>> DeleteScheduleGroup");

            var findAccessSchedule = await accessScheduleService.RetrieveAccessSchedule(code);

            if (findAccessSchedule == null)
            {
                return NotFound(new ApiResponseBody<object>(ApiResponse.NOT_FOUND));
            }

            await accessScheduleService.DeleteAccessSchedule(findAccessSchedule);

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS));
        }
    }
}
