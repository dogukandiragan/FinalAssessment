using Quartz;
using FinalAssessment.Shared;

namespace FinalAssessment.API.Quartz
{
    public class MonthlyReportJob : IJob
    { 
        EmailSender es = new EmailSender();
        List<string> receiverlist = new List<string>(new string[] { "test@test.com" });
        public MonthlyReportJob()
        {


        }
        public Task Execute(IJobExecutionContext context)
        {
            es.SendIt(receiverlist, "","");
            return Task.CompletedTask;
        }


    }
}