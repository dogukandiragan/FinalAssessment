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
           
            es.SendIt(receiverlist, "","");
            return Task.CompletedTask;
        }

    }
}
