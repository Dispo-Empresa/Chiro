﻿using Chiro.Application.Interfaces;
using Chiro.Domain.DTOs;
using Chiro.Domain.Entities;
using Chiro.Domain.Interfaces;

namespace Chiro.Application.Services
{
    public class BoardActionService : IBoardActionServices
    {
        private readonly IBoardActionRepository _repository;
        public BoardActionService(IBoardActionRepository boardActionRepository)
        {
            _repository = boardActionRepository;
        }

        public async Task<bool> ChangeColor(ChangeBoardActionColorDTO changeBoardActionColorDTO)
        {
            var boardAction = new BoardAction
            {
                Color = changeBoardActionColorDTO.Color,
            };

            return await _repository.ChangeColorAsync(changeBoardActionColorDTO.Id, boardAction);
        }

        public async Task<bool> CreateBoardAction(CreateBoardActionDTO createBoardActionDTO)
        {
            var boardAction = new BoardAction
            {
                ProjectId = createBoardActionDTO.ProjectId,
                Content = createBoardActionDTO.Content,
                Color = createBoardActionDTO.Color,
                Height = createBoardActionDTO.Height,
                Width = createBoardActionDTO.Width,
                PositionX = createBoardActionDTO.PositionX,
                PositionY = createBoardActionDTO.PositionY
            };

            return await _repository.CreateBoardActionAsync(boardAction);
        }

        public async Task<bool> Move(MoveBoardActionDTO moveBoardActionDTO)
        {
            var boardAction = new BoardAction
            {
                PositionX = moveBoardActionDTO.PositionX,
                PositionY = moveBoardActionDTO.PositionY
            };

            return await _repository.MoveAsync(moveBoardActionDTO.Id, boardAction);
        }

        public async Task<bool> Resize(ResizeBoardActionDTO resizeBoardActionDTO)
        {
            var boardAction = new BoardAction
            {
                Width = resizeBoardActionDTO.Width,
                Height = resizeBoardActionDTO.Height,
            };

            return await _repository.ResizeAsync(resizeBoardActionDTO.Id, boardAction);
        }
    }
}
