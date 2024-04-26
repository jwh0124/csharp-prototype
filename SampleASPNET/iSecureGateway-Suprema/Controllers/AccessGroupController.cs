using AutoMapper;
using iSecureGateway_Suprema.Commons.Http.Response;
using iSecureGateway_Suprema.DTO;
using iSecureGateway_Suprema.Interfaces;
using iSecureGateway_Suprema.Models;
using Microsoft.AspNetCore.Mvc;

namespace iSecureGateway_Suprema.Controllers
{
    [ApiController]
    [Route("api/access-groups")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AccessGroupController : ControllerBase
    {
        private readonly ILogger<AccessGroupController> logger;
        private readonly IAccessGroupService accessGroupService;
        private readonly IMapper mapper;

        public AccessGroupController(ILogger<AccessGroupController> logger, IAccessGroupService accessGroupService, IMapper mapper)
        {
            this.logger = logger;
            this.accessGroupService = accessGroupService;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetAccessGroupList")]
        public async Task<IActionResult> GetAccessGroupList()
        {
            logger.LogDebug("AccessGroupController >>> GetAccessGroupList");

            var accessGroupList = mapper.Map<ICollection<AccessGroupDto>>(await accessGroupService.RetrieveAccessGroupList());

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, accessGroupList));
        }

        [HttpGet("{code}", Name = "GetAccessGroup")]
        public async Task<IActionResult> GetAccessGroup(string code)
        {
            logger.LogInformation("AccessGroupController >>> GetAccessGroup");

            var accessGroup = mapper.Map<AccessGroupDto>(await accessGroupService.RetrieveAccessGroup(code));

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, accessGroup));
        }

        [HttpPost(Name = "AddAccessGroup")]
        public async Task<IActionResult> AddAccessGroup([FromBody] AccessGroupDto accessGroupDto)
        {
            logger.LogInformation("AccessGroupController >>> PostAccessGroup");

            var accessGroup = mapper.Map<AccessGroup>(accessGroupDto);

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, mapper.Map<AccessGroupDto>(await accessGroupService.RegistAccessGroup(accessGroup))));
        }

        [HttpPut("{code}", Name = "PutAccessGroup")]
        public async Task<IActionResult> PutAccessGroup(string code, [FromBody] AccessGroupDto accessGroupDto)
        {
            logger.LogDebug("AccessGroupController >>> PutAccessGroup");

            var findAccessGroup = await accessGroupService.RetrieveAccessGroup(code);

            if (findAccessGroup == null)
            {
                return NotFound(new ApiResponseBody<object>(ApiResponse.NOT_FOUND));
            }
            else
            {
                findAccessGroup.Name = accessGroupDto.Name;
            }

            var test = mapper.Map<AccessGroup>(accessGroupDto);

            

            await accessGroupService.UpdateAccessGroup(mapper.Map<AccessGroup>(test));

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS));
        }


        [HttpDelete("{code}", Name = "DeleteAccessGroup")]
        public async Task<IActionResult> DeleteAccessGroup(string code)
        {
            logger.LogInformation("AccessGroupController >>> DeleteAccessGroup");

            var findAccessGroup = await accessGroupService.RetrieveAccessGroup(code);

            if (findAccessGroup == null)
            {
                return NotFound(new ApiResponseBody<object>(ApiResponse.NOT_FOUND));
            }

            await accessGroupService.DeleteAccessGroup(findAccessGroup);


            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS));
        }
    }
}
