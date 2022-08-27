using MachineInfo.System;

namespace MachineInfo.CollectorAgent
{
    public class Worker : BackgroundService
    {
        private readonly PeriodicTimer timer = new(TimeSpan.FromSeconds(5));

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            SystemExplorer explorer = new(); 

            while (await timer.WaitForNextTickAsync(cancellationToken) && !cancellationToken.IsCancellationRequested)
            {
                var snapshot = explorer.Run();
            }
        }
    }
}