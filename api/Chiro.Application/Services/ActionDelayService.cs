using Chiro.Application.Interfaces;

namespace Chiro.Application.Services
{
    public class ActionDelayService
    {
        private readonly IProjectService _projectService;
        public ActionDelayService(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task HandleActionDelay()
        {
            var periodicTimer = new PeriodicTimer(new TimeSpan(0, 0, 10));
            while (await periodicTimer.WaitForNextTickAsync())
            {
                var alreadyAdjustedActions = new List<long>();
                var projects = await _projectService.GetProjectsWithActionsAsync();
                if (!projects.Any())
                {
                    continue;
                }

                foreach (var project in projects)
                {
                    if (project.TimelineActions != null && !project.TimelineActions.Exists(w => w.EndDate > DateTime.Now))
                    {
                        continue;
                    }

                    foreach (var timelineAction in project.TimelineActions.Where(timelineAction => timelineAction.EndDate > DateTime.Now && !alreadyAdjustedActions.Exists(w => w == timelineAction.Id)))
                    {
                        alreadyAdjustedActions.AddRange(timelineAction.DelaySelfAndChilds());
                    }

                    alreadyAdjustedActions.Clear();
                }
            }
        }
    }
}
