﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by ServiceMatrix.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using NServiceBus;
 
namespace Example2.MembershipProcessor
{
	public partial class EndpointConfig : IConfigureThisEndpoint, AsA_Server, ISpecifyMessageHandlerOrdering    
	{
	    public void SpecifyOrder(Order order)
	    {
	        order.Specify(First<Example2.PremiumMembership.Membership>.Then<Example2.PremiumMembership.SendTermsOfUsageHandler>());
	    }
    }
}
