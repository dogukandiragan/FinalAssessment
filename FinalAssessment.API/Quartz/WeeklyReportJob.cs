using FinalAssessment.Shared;
using Quartz;

namespace FinalAssessment.API.Quartz
{
    public class WeeklyReportJob : IJob
    {
        EmailSender es = new EmailSender();
        List<string> receiverlist = new List<string>(new string[] { "dogukandiragan@hotmail.com" });
        public WeeklyReportJob()
        {

        }
        public Task Execute(IJobExecutionContext context)
        {
            object o = new object();
            es.SendIt(receiverlist, o);
            return Task.CompletedTask;
        }

    }
}
