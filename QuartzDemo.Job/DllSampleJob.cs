using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace QuartzDemo.Job
{
    public class DllSampleJob :IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello~ DllSampleJob Job executed.");
            return Task.CompletedTask;
        }
    }
}
