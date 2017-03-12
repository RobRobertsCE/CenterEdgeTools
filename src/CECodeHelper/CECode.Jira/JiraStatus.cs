using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.Jira
{
    public enum JiraStatus
    {
        Open = 1,
        InProgress = 3,
        Closed = 6,
        InReview = 10000,
        QA = 10100,
        QAApproved = 10101,
        FinalReview = 10200,
        Revise = 10201,
        ProductReview = 10300,
        Done = 10301,
        OnHold = 10400,
        ScopingAndDesign = 10501,
        CustomerReview = 10502,
        StoryCreation = 10503,
        Backlog = 10700,
        SelectedforDevelopment = 10701,
        NeedInfo = 10800,
        ParallelTesting = 11000,
        SelectedforBeta = 11100,
        BetaSetup = 11101,
        LiveBeta = 11102
    }
}
