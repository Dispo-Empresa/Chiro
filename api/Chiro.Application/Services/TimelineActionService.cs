﻿using Chiro.Application.Interfaces;
using Chiro.Domain.DTOs;
using Chiro.Domain.Entities;
using Chiro.Domain.Interfaces;

namespace Chiro.Application.Services
{
    public class TimelineActionService : ITimelineActionService
    {
        private readonly ITimelineActionRepository _repository;

        public TimelineActionService(ITimelineActionRepository actionRepository)
        {
            _repository = actionRepository;
        }

        public async Task<bool> ChangePeriodAsync(ChangePeriodDTO changePeriodDTO)
        {
            var timeline = new TimelineAction
            {
                StartDate = changePeriodDTO.StartDate,
                EndDate = changePeriodDTO.EndDate,
            };

            return await _repository.ChangePeriodAsync(changePeriodDTO.Id, timeline);
        }

        public async Task<bool> CreateTimelineActionAsync(CreateTimelineActionDTO createTimelineActionDTO)
        {
            var timeline = new TimelineAction
            {
                ProjectId = createTimelineActionDTO.ProjectId,
                BoardActionId = createTimelineActionDTO.BoardActionId,
                StartDate = createTimelineActionDTO.StartDate,
                EndDate = createTimelineActionDTO.EndDate,
            };

            return await _repository.CreateTimelineActionAsync(timeline);
        }

        public async Task<bool> ConcludeTimelineActionAsync(ConcludeTimelineActionDTO concludeTimelineActionDTO)
        {
            var timeline = new TimelineAction
            {
                ConcludedAt = DateTime.Now
            };

            return await _repository.ConcludeTimelineActionAsync(concludeTimelineActionDTO.Id, timeline);
        }

        public async Task<bool> LinkTimelineActionsAsync(LinkTimelineActionsDTO linkTimelineActionsDTO)
        {
            var timeline = new TimelineAction
            {
                LinkedTimelineActionId = linkTimelineActionsDTO.TimelineActionToBeLinked
            };

            return await _repository.LinkTimelineActionsAsync(linkTimelineActionsDTO.Id, timeline);
        }
    }
}