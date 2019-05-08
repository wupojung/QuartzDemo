using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace QuartzDemo
{
    public class SimpleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello~ Simple Job executed.");
            return Task.CompletedTask;
        }
    }
}
