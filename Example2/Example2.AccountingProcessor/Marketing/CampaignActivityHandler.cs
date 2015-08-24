using Example2.Contracts.Payments;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2.AccountingProcessor.Marketing
{
    public class CampaignActivityHandler : IHandleMessages<CampaignActivityOccured>
    {
        public void Handle(CampaignActivityOccured message)
        {
            Console.WriteLine("CampaignActivityHandler received " + message.GetType().Name);
        }
    }
}
