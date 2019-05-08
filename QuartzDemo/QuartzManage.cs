using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace QuartzDemo
{
    public class QuartzManage
    {
        #region Fields

        private static readonly Task<IScheduler> _taskScheduler = StdSchedulerFactory.GetDefaultScheduler();
        private static readonly IScheduler _scheduler;
        private static readonly object Objlock = new object();

        #endregion

        #region Ctor

        static QuartzManage()
        {
            if (_scheduler == null)
            {
                lock (Objlock)
                {
                    if (_scheduler == null)
                        _scheduler = _taskScheduler.Result;
                }
            }
        }

        #endregion

        #region Methods

        public async Task Initialize(IList<QuartzJobViewModel> data)
        {

            foreach (QuartzJobViewModel item in data)
            {
                // Type type = Type.GetType(item.prog_name);

                var type = Type.GetType(item.prog_name) ??
                           //ensure that it works fine when only the type name is specified (do not require fully qualified names)
                           AppDomain.CurrentDomain.GetAssemblies()
                               .Select(a => a.GetType(item.prog_name))
                               .FirstOrDefault(t => t != null);

                IJobDetail job = JobBuilder.Create(type)
                    .WithIdentity(item.prog_name + "_job")
                    .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity(item.prog_name + "_trigger")
                    .WithCronSchedule(item.cron)
                    .Build();

                await _scheduler.ScheduleJob(job, trigger);
            }

        }

        public async Task Start()
        {
            await _scheduler.Start();
        }

        public async Task PauseAll()
        {
            await _scheduler.PauseAll();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the Quartz manage instance
        /// </summary>
        public static QuartzManage Instance { get; } = new QuartzManage();
        #endregion
    }

}
