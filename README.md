Quartz.Net Demo
===

### Install Package with Nuget
You can search and install package with *Quartz*
or runing command with PM like this:
```shell=
PM> Install-Package Quartz
```

### Create IJob like SimpleJob
```cshape=
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
```
Now, we have a job call *QuartzDemo.SimpleJob* in you project. 

### Initialize the job with manage
```cshape= 
	//...
    IList<QuartzJobViewModel> model = new List<QuartzJobViewModel>();
    model.Add(new QuartzJobViewModel("JOB001", "QuartzDemo.SimpleJob", "0/5 * * * * ?"));

    await QuartzManage.Instance.Initialize(model);
	//...
```

### Start jobs
```
	//...
	QuartzManage.Instance.Start()
	//...
```

### Ref

[Create Job With Type(chinese)](https://www.cnblogs.com/refuge/p/10324578.html)

[QuartzManage Sample(chinese)](https://blog.csdn.net/commandbaby/article/details/82686377)