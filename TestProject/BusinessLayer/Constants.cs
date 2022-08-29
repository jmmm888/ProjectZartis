using System;
namespace TestProject.BusinessLayer
{
    public static class Constants
    {
        public static IReadOnlyDictionary<int, string> LandingResultsOptions = new Dictionary<int, string>
        {
            { -1, "out of plataform" },
            { 0, "clash" },
            { 1, "ok for landing" }
        };
    }
}

