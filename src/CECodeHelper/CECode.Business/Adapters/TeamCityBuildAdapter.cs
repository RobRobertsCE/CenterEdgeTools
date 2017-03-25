﻿using System;
using System.Collections.Generic;
using System.Globalization;
using CECode.TeamCity;
using CECode.TeamCity.Results;

namespace CECode.Business.Adapters
{
    internal class TeamCityBuildAdapter
    {
        #region public methods
        public static IList<ICEBuildDetails> Translate(IEnumerable<BuildDetails> builds)
        {
            IList<ICEBuildDetails> ICEBuilds = new List<ICEBuildDetails>();
            foreach (var entity in builds)
            {
                ICEBuilds.Add(Translate(entity));
            }
            return ICEBuilds;
        }

        public static ICEBuildDetails Translate(BuildDetails build)
        {
            if (null == build)
            {
                return new CEBuildDetails();
            }

            ICEBuildDetails ceBuild = new CEBuildDetails()
            {
                id = build.id,
                state = build.state,
                status = build.status,
                branchName = build.branchName,
                number = build.number,
                buildTypeId = build.buildTypeId,
                href = build.href,
                webUrl = build.webUrl
            };

            return ceBuild;
        }

        public static IList<ICEBuild> Translate(IEnumerable<RunningBuild> builds)
        {
            IList<ICEBuild> ICEBuilds = new List<ICEBuild>();
            if (null != builds)
            {
                foreach (var entity in builds)
                {
                    ICEBuilds.Add(Translate(entity));
                }
            }
            return ICEBuilds;
        }

        public static ICEBuild Translate(RunningBuild build)
        {
            ICEBuild ceBuild = new CEBuild()
            {
                id = build.id,
                state = build.state,
                status = build.status,
                branchName = build.branchName,
                number = build.number,
                buildTypeId = build.buildTypeId,
                href = build.href,
                webUrl = build.webUrl,
                percentageComplete = build.percentageComplete
            };

            return ceBuild;
        }

        //public static IList<ICEBuildDetails> Translate(IEnumerable<BuildDetails> builds)
        //{
        //    IList<ICEBuildDetails> ceBuildDetails = new List<ICEBuildDetails>();
        //    foreach (var entity in builds)
        //    {
        //        ceBuildDetails.Add(Translate(entity));
        //    }
        //    return ceBuildDetails;
        //}

        //public static ICEBuildDetails Translate(BuildDetails build)
        //{
        //    ICEBuildDetails details = new CEBuildDetails()
        //    {
        //        id = build.id,
        //        state = build.state,
        //        status = build.status,
        //        branchName = build.branchName,
        //        number = build.number,
        //        buildTypeId = build.buildTypeId,
        //        href = build.href,
        //        webUrl = build.webUrl,
        //        artifacts = build.artifacts.href,
        //        changes = build.changes.href
        //    };
        //    if (!String.IsNullOrEmpty(build.queuedDate)) details.queuedDate = DateTime.ParseExact(build.queuedDate, "yyyyMMddTHHmmssK", new CultureInfo("en-US"));
        //    if (!String.IsNullOrEmpty(build.startDate)) details.startDate = DateTime.ParseExact(build.startDate, "yyyyMMddTHHmmssK", new CultureInfo("en-US"));
        //    if (!String.IsNullOrEmpty(build.finishDate)) details.finishDate = DateTime.ParseExact(build.finishDate, "yyyyMMddTHHmmssK", new CultureInfo("en-US"));

        //    return details;
        //}
        #endregion
    }
}
