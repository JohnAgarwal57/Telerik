namespace EasyPTC.Web.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EasyPTC.Models;

    public class SessionState
    {
        public SessionState()
        {
            this.PricingPlans = new List<PricingPlan>();
        }

        public List<PricingPlan> PricingPlans { get; set; }
    }
}