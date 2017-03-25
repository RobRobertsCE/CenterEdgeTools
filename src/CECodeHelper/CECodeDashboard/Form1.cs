using CECode.Business.Services;
using CECodeDashboard.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CECodeDashboard
{
    public partial class Form1 : Form
    {
        WorkItemService _service;

        public Form1()
        {
            InitializeComponent();

            _service = new WorkItemService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunTest();
        }

        async void RunTest()
        {
            try
            {
                var workItems = new List<WorkItem>();

                var pullRequests = await _service.GetPullRequests("Advantage", DateTime.Now.AddDays(-1), 3);
                foreach (var pullRequest in pullRequests)
                {
                    var workItem = new WorkItem()
                    {
                        Number = pullRequest.Number,
                        Id = pullRequest.Id,
                        Status = pullRequest.Status,
                        Title = pullRequest.Title,
                        Developer = pullRequest.User
                    };

                    if (workItem.Status=="Open")
                    {
                        var builds = await _service.GetBuilds(pullRequest.Number);

                        foreach (var build in builds)
                        {
                            var workItemBuild = new WorkItemBuild()
                            {
                                Id = build.id,
                                Number = build.number,
                                Status = build.status,
                                State = build.state,
                                Branch = build.branchName,
                                PercentComplete = build.percentageComplete
                            };
                           
                            workItem.Builds.Add(workItemBuild);
                        }

                        var runningBuilds = await _service.GetRunningBuilds(Convert.ToInt32(pullRequest.Number));//  .(pullRequest.Number);

                        foreach (var runningBuild in runningBuilds)
                        {
                            var runningWorkItemBuild = new WorkItemBuild()
                            {
                                Id = runningBuild.id,
                                Number = runningBuild.number,
                                Status = runningBuild.status,
                                State = runningBuild.state,
                                Branch = runningBuild.branchName,
                                PercentComplete = runningBuild.percentageComplete
                            };
                            workItem.Builds.Add(runningWorkItemBuild);
                        }
                    }

                    workItems.Add(workItem);
                }
                foreach (var workItem in workItems)
                {
                    Console.WriteLine("{0} {1} {2} {3}", workItem.Number, workItem.Status, workItem.Developer, workItem.Title);
                    foreach (var build in workItem.Builds)
                    {
                        Console.WriteLine("\t{1} {2} {3} {4}", build.Number, build.Status, build.State, build.Branch, build.PercentComplete);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
