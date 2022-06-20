using System;

namespace PlanTechShenApp
{
    internal class ActivityAttribute : Attribute
    {
        public bool MainLauncher { get; set; }
    }
}