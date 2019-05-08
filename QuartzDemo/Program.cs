using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            IList<QuartzJobViewModel> model = new List<QuartzJobViewModel>();
            model.Add(new QuartzJobViewModel("JOB001", "QuartzDemo.SimpleJob", "0/5 * * * * ?"));

            QuartzManage.Instance.Initialize(model).GetAwaiter().GetResult();
            QuartzManage.Instance.Start().GetAwaiter().GetResult();

            Console.ReadKey();
        }
    }
}
