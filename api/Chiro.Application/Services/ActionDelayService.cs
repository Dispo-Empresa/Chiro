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
            var periodicTimer = new PeriodicTimer(new TimeSpan(0, 10, 0));
            while (await periodicTimer.WaitForNextTickAsync())
            {
                var projects = await _projectService.GetProjectsAsync();
                foreach (var project in projects)
                {

                }
            }
        }
    }
}
