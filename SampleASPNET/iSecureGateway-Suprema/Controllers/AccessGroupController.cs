using AutoMapper;
using FluentValidation;
using iSecureGateway_Suprema.Commons.Config.Auth;
using iSecureGateway_Suprema.Commons.Http.Request;
using iSecureGateway_Suprema.Commons.Http.Response;
using iSecureGateway_Suprema.DTO;
using iSecureGateway_Suprema.Interfaces;
using iSecureGateway_Suprema.Models;
using iSecureGateway_Union.Commons;
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
        private readonly IValidator<AccessGroupDto> accessGroupValidator;
        private readonly IValidator<RequestInfoDto> requestInfoValidator;
        private readonly IMapper mapper;

        public AccessGroupController(ILogger<AccessGroupController> logger, IAccessGroupService accessGroupService, 
                                     IValidator<AccessGroupDto> accessGroupValidator, IValidator<RequestInfoDto> requestInfoValidator, IMapper mapper)
        {
            this.logger = logger;
            this.accessGroupService = accessGroupService;
            this.accessGroupValidator = accessGroupValidator;
            this.requestInfoValidator = requestInfoValidator;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetAccessGroupList")]
        [ServiceFilter(typeof(HttpAuthentication))]
        public async Task<IActionResult> GetAccessGroupList()
        {
            logger.LogDebug("AccessGroupController >>> GetAccessGroupList");

            var accessGroupList = mapper.Map<ICollection<AccessGroupDto>>(await accessGroupService.RetrieveAccessGroupList());

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, accessGroupList));
        }

        [HttpGet("{code}", Name = "GetAccessGroup")]
        [ServiceFilter(typeof(HttpAuthentication))]
        public async Task<IActionResult> GetAccessGroup(string code)
        {
            logger.LogInformation("AccessGroupController >>> GetAccessGroup");

            var accessGroup = mapper.Map<AccessGroupDto>(await accessGroupService.RetrieveAccessGroup(code));

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, accessGroup));
        }

        [HttpPost(Name = "AddAccessGroup")]
        [ServiceFilter(typeof(HttpAuthentication))]
        public async Task<IActionResult> AddAccessGroup([FromBody] RequestCommonDto<AccessGroupDto> accessGroupDto)
        {
            logger.LogInformation("AccessGroupController >>> PostAccessGroup");

            var validationResult = await accessGroupValidator.ValidateAsync(accessGroupDto.TData!);

            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponseBody<object>(ApiResponse.BAD_REQUEST, validationResult.Errors.First().ErrorMessage));
            }

            var accessGroup = mapper.Map<AccessGroup>(accessGroupDto.TData);

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS, mapper.Map<AccessGroupDto>(await accessGroupService.RegistAccessGroup(accessGroup))));
        }

        [HttpPut("{code}", Name = "PutAccessGroup")]
        [ServiceFilter(typeof(HttpAuthentication))]
        public async Task<IActionResult> PutAccessGroup(string code, [FromBody] RequestCommonDto<AccessGroupDto> accessGroupDto)
        {
            logger.LogDebug("AccessGroupController >>> PutAccessGroup");

            var validationResult = await accessGroupValidator.ValidateAsync(accessGroupDto.TData!);

            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponseBody<object>(ApiResponse.BAD_REQUEST, validationResult.Errors.First().ErrorMessage));
            }

            await accessGroupService.UpdateAccessGroup(code, mapper.Map<AccessGroup>(accessGroupDto));

            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS));
        }


        [HttpDelete("{code}", Name = "DeleteAccessGroup")]
        [ServiceFilter(typeof(HttpAuthentication))]
        public async Task<IActionResult> DeleteAccessGroup(string code, [FromBody] RequestCommonDto<RequestInfoDto> requestInfoDto)
        {
            logger.LogInformation("AccessGroupController >>> DeleteAccessGroup");

            var validationResult = await requestInfoValidator.ValidateAsync(requestInfoDto.Info);

            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponseBody<object>(ApiResponse.BAD_REQUEST, validationResult.Errors.First().ErrorMessage));
            }

            await accessGroupService.DeleteAccessGroup(code);


            return Ok(new ApiResponseBody<object>(ApiResponse.SUCCESS));
        }
    }
}
