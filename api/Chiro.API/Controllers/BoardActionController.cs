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
            var boardActionId = await _boardActionService.CreateBoardActionAsync(createBoardActionDTO);
            if (boardActionId <= 0)
            {
                return BadRequest("Board Action couldn't be created.");
            }

            return Ok(boardActionId);
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

        /// <summary>
        /// Deleta uma Board Action.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var deletedBoardAction = await _boardActionService.DeleteAsync(id);
            if (!deletedBoardAction)
            {
                return BadRequest("N�o foi poss�vel deletar a Board Action.");
            }

            return Ok("Board Action deletada.");
        }


        /// <summary>
        /// Altera o conte�do de um Projeto.
        /// </summary>
        /// <param name="changeBoardActionContentDTO"></param>
        /// <returns></returns>
        [HttpPost("change-content")]
        public async Task<IActionResult> ChangeContentAsync([FromBody] ChangeBoardActionContentDTO changeBoardActionContentDTO)
        {
            var changedName = await _boardActionService.ChangeContentAsync(changeBoardActionContentDTO);
            if (!changedName)
            {
                return BadRequest("N�o foi poss�vel alterar o nome do projeto.");
            }

            return Ok("Nome alterado.");
        }
    }
}