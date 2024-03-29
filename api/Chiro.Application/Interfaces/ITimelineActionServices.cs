using Chiro.Domain.DTOs;

namespace Chiro.Application.Interfaces
{
    public interface ITimelineActionService
    {
        Task<bool> CreateTimelineActionAsync(CreateTimelineActionDTO createTimelineActionDTO);

        Task<bool> ChangePeriodAsync(ChangePeriodDTO changePeriodDTO);

        Task<bool> ConcludeTimelineActionAsync(ConcludeTimelineActionDTO concludeTimelineActionDTO);

        Task<bool> LinkTimelineActionsAsync(LinkTimelineActionsDTO linkTimelineActionsDTO);
    }
}