using Chiro.Application.Interfaces;
using Chiro.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chiro.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/board-action")]
    public class BoardActionController : ControllerBase
    {
        private readonly ILogger<BoardActionController> _logger;
        private readonly IBoardActionService _boardActionService;

        public BoardActionController(ILogger<BoardActionController> logger, IBoardActionService boardActionServices)
        {
            _logger = logger;
            _boardActionService = boardActionServices;
        }

        /// <summary>
        /// Cria um board action.
        /// </summary>
        /// <param name="createBoardActionDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBoardActionDTO createBoardActionDTO)
        {
            var createdBoardAction = await _boardActionService.CreateBoardActionAsync(createBoardActionDTO);
            if (!createdBoardAction)
            {
                return BadRequest("Board Action couldn't be created.");
            }

            return Ok("Board Action Created.");
        }

        /// <summary>
        /// Altera a cor de um board action.
        /// </summary>
        /// <param name="changeBoardActionColorDTO"></param>
        /// <returns></returns>
        [HttpPost("change-color")]
        public async Task<IActionResult> ChangeColorAsync([FromBody] ChangeBoardActionColorDTO changeBoardActionColorDTO)
        {
            var changedColor = await _boardActionService.ChangeColorAsync(changeBoardActionColorDTO);
            if (!changedColor)
            {
                return BadRequest("Color couldn't be changed.");
            }

            return Ok("Color Changed.");
        }

        /// <summary>
        /// Altera o tamanho de um board action.
        /// </summary>
        /// <param name="resizeBoardActionDTO"></param>
        /// <returns></returns>
        [HttpPost("resize")]
        public async Task<IActionResult> ResizeAsync([FromBody] ResizeBoardActionDTO resizeBoardActionDTO)
        {
            var resized = await _boardActionService.ResizeAsync(resizeBoardActionDTO);
            if (!resized)
            {
                return BadRequest("Board Action couldn't be resized.");
            }

            return Ok("Board Action Resized.");
        }

        /// <summary>
        /// Altera a posi��o de um board action.
        /// </summary>
        /// <param name="moveBoardActionDTO"></param>
        /// <returns></returns>
        [HttpPost("move")]
        public async Task<IActionResult> MoveAsync([FromBody] MoveBoardActionDTO moveBoardActionDTO)
        {
            var moved = await _boardActionService.MoveAsync(moveBoardActionDTO);
            if (!moved)
            {
                return BadRequest("Board Action couldn't be moved.");
            }

            return Ok("Board Action Moved.");
        }

        /// <summary>
        /// Altera o tempo de uma board action dentro da board.
        /// </summary>
        /// <param name="changePeriodDTO"></param>
        /// <returns></returns>
        [HttpPost("change-period")]
        public async Task<IActionResult> ChangePeriodAsync([FromBody] ChangePeriodDTO changePeriodDTO)
        {
            var chengedPeriod = await _boardActionService.ChangePeriodAsync(changePeriodDTO);
            if (!chengedPeriod)
            {
                return BadRequest("Period couldn't be changed.");
            }

            return Ok("Period Changed.");
        }

        /// <summary>
        /// Altera o tempo de uma board action dentro da board.
        /// </summary>
        /// <param name="changePeriodDTO"></param>
        /// <returns></returns>
        [HttpPost("conclude")]
        public async Task<IActionResult> ConcludeAsync([FromBody] ConcludeBoardActionDTO concludeBoardActionDTO)
        {
            var chengedPeriod = await _boardActionService.ConcludeBoardActionAsync(concludeBoardActionDTO);
            if (!chengedPeriod)
            {
                return BadRequest("Board Action couldn't be concluded.");
            }

            return Ok("Board Action Concluded.");
        }

        /// <summary>
        /// Altera o tempo de uma board action dentro da board.
        /// </summary>
        /// <param name="changePeriodDTO"></param>
        /// <returns></returns>
        [HttpPost("link")]
        public async Task<IActionResult> LinkAsync([FromBody] LinkBoardActionDTO linkBoardActionDTO)
        {
            var linked = await _boardActionService.LinkAsync(linkBoardActionDTO);
            if (!linked)
            {
                return BadRequest("Board Action couldn't be linked.");
            }

            return Ok("Board Action Linked.");
        }
    }
}