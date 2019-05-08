using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo
{
    public class QuartzJobViewModel
    {

        public string job_name { get; set; }
        public string prog_name { get; set; }
        public string cron { get; set; }

        public QuartzJobViewModel(string job_name, string prog_name, string cron)
        {
            this.job_name = job_name;
            this.prog_name = prog_name;
            this.cron = cron;
        }
    }
}
