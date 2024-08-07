using Chiro.Application.Exceptions;
using Chiro.Application.Interfaces;
using Chiro.Domain.DTOs;
using Chiro.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chiro.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/project")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<BoardActionController> _logger;
        private readonly IProjectService _projectService;

        public ProjectController(ILogger<BoardActionController> logger, IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }

        /// <summary>
        /// Cria um novo projeto.
        /// </summary>
        /// <param name="createProjectDTO"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> CreateProjectAsync([FromBody] CreateProjectDTO createProjectDTO)
        {
            var projectCreated = await _projectService.CreateProject(createProjectDTO);
            if (projectCreated <= 0)
            {
                return BadRequest("Project couldn't be created.");
            }

            return Ok(projectCreated);
        }

        /// <summary>
        /// Busca todos os projetos.
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> GetProjectsAsync()
        {
            var result = await _projectService.GetProjectsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Buscar um único projeto juntamente com o Board e a Board.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectAsync(long id)
        {
            try
            {
                var result = await _projectService.GetDelayedProjectAsync(id);
                if (result is null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (BusinessException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Altera o tamanho da bolha do projeto.
        /// </summary>
        /// <param name="resizeProjectDTO"></param>
        /// <returns></returns>
        [HttpPost("resize")]
        public async Task<IActionResult> ResizeAsync([FromBody] ResizeProjectDTO resizeProjectDTO)
        {
            var resized = await _projectService.ResizeAsync(resizeProjectDTO);
            if (!resized)
            {
                return BadRequest("N�o foi poss�vel redimencionar o projeto.");
            }

            return Ok("Projeto redimencionado com sucesso.");
        }

        /// <summary>
        /// Altera a posi��o de um projeto.
        /// </summary>
        /// <param name="moveProjectDTO"></param>
        /// <returns></returns>
        [HttpPost("move")]
        public async Task<IActionResult> MoveAsync([FromBody] MoveProjectDTO moveProjectDTO)
        {
            var moved = await _projectService.MoveAsync(moveProjectDTO);
            if (!moved)
            {
                return BadRequest("Projeto n�o pode ser movido.");
            }

            return Ok("Projeto movido.");
        }

        /// <summary>
        /// Altera a cor de um board action.
        /// </summary>
        /// <param name="changeProjectColorDTO"></param>
        /// <returns></returns>
        [HttpPost("change-color")]
        public async Task<IActionResult> ChangeColorAsync([FromBody] ChangeProjectColorDTO changeProjectColorDTO)
        {
            var changedColor = await _projectService.ChangeColorAsync(changeProjectColorDTO);
            if (!changedColor)
            {
                return BadRequest("N�o foi poss�vel alterar a cor do projeto.");
            }

            return Ok("Cor alterada com sucesso.");
        }

        /// <summary>
        /// Seta um projeto como "Deleted".
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var changedColor = await _projectService.DeleteAsync(id);
            if (!changedColor)
            {
                return BadRequest("N�o foi poss�vel deletar o projeto.");
            }

            return Ok("Project deletado.");
        }

        /// <summary>
        /// Altera o nome de um projeto.
        /// </summary>
        /// <param name="changeProjectNameDTO"></param>
        /// <returns></returns>
        [HttpPost("change-name")]
        public async Task<IActionResult> ChangeNameAsync([FromBody] ChangeProjectNameDTO changeProjectNameDTO)
        {
            var changedName = await _projectService.ChangeNameAsync(changeProjectNameDTO);
            if (!changedName)
            {
                return BadRequest("N�o foi poss�vel alterar o nome do projeto.");
            }

            return Ok("Nome alterado.");
        }

        /// <summary>
        /// Busca as cofigurações para para montar a Timeline
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("timeline-configuration/{id}")]
        public async Task<IActionResult> GetTimelineConfiguration(long id)
        {
            var result = new TimelineConfigurationDTO()
            {
                Period = await _projectService.GetTimelinePeriodAsync(id),
                BiggestRow = await _projectService.GetBiggestTimelineRow(id)
            };

            return Ok(result);
        }

        /// <summary>
        /// Busca o nome do projeto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("name/{id}")]
        public async Task<IActionResult> GetName(long id)
        {
            var result = await _projectService.GetProjectNameAsync(id);
            return Ok(result);
        }

        [HttpGet("get-encrypt-projectId")]
        public IActionResult GetEncryptProjectId(string projectId, string randomNumbers)
        {
            if (!long.TryParse(projectId, out long _projectId))
            {
                return BadRequest("ID do projeto inválido.");
            }

            if (!int.TryParse(randomNumbers, out int _randomNumbers))
            {
                return BadRequest("Número aleatório inválido");
            }

            var encryptProjectId = _projectService.GenerateToken(_projectId, _randomNumbers);
            return Ok(encryptProjectId);
        }
        [HttpGet("get-decrypt-projectId")]
        public IActionResult GetDecryptProjectId(string token)
        {
            var encryptProjectId = _projectService.DecryptToken(token);
            return Ok(encryptProjectId);
        }
    }
}