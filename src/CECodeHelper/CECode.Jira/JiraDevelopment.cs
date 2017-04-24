using System;

namespace CECode.Jira
{

    public class Rootobject
    {
        public Cachedvalue cachedValue { get; set; }
        public bool isStale { get; set; }
    }

    public class Cachedvalue
    {
        public object[] errors { get; set; }
        public Summary summary { get; set; }
    }

    public class Summary
    {
        public Pullrequest pullrequest { get; set; }
    }

    public class Pullrequest
    {
        public Overall overall { get; set; }
        public Byinstancetype byInstanceType { get; set; }
    }

    public class Overall
    {
        public int count { get; set; }
        public DateTime lastUpdated { get; set; }
        public int stateCount { get; set; }
        public string state { get; set; }
        public bool open { get; set; }
    }

    public class Byinstancetype
    {
        public Githube githube { get; set; }
    }

    public class Githube
    {
        public int count { get; set; }
        public string name { get; set; }
    }

}
/*
customfield_11500:Development:
 * {pullrequest=
 *  {dataType=pullrequest, state=MERGED, stateCount=1}, json=
 *      {"cachedValue":
 *          {"errors":[],
 *           "summary":
 *              {"pullrequest":
 *                  {"overall":
 *                      {"count":1,"lastUpdated":"2017-01-12T09:05:26.000-0500","stateCount":1,"state":"MERGED","open":false},
 *                   "byInstanceType":
 *                      {"githube":{"count":1,"name":"GitHub Enterprise"}
 *                  }
 *              }
 *          }
 *      },
 *  "isStale":true}
 * }
*/