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
using Example2.Contracts.Payments;
using NServiceBus.Saga;


namespace Example2.PremiumMembership
{
    public partial class Membership : Saga<MembershipSagaData>, IAmStartedByMessages<OrderPlacedEvent>, IHandleMessages<InvoiceSentInEncashmentEvent>
    {
		
		public void Handle(OrderPlacedEvent message)
		{
			// Store message in Saga Data for later use
			this.Data.OrderPlacedEvent = message;
			// Handle message on partial class
			this.HandleImplementation(message);

			// Check if Saga is Completed 
			CheckIfAllMessagesReceived();
		}

		public void Handle(InvoiceSentInEncashmentEvent message)
		{
			// Store message in Saga Data for later use
			this.Data.InvoiceSentInEncashmentEvent = message;
			// Handle message on partial class
			this.HandleImplementation(message);

			// Check if Saga is Completed 
			CheckIfAllMessagesReceived();
		}

		partial void HandleImplementation(OrderPlacedEvent message);

		partial void HandleImplementation(InvoiceSentInEncashmentEvent message);

        public void CheckIfAllMessagesReceived()
        {
            if (this.Data.OrderPlacedEvent != null && this.Data.InvoiceSentInEncashmentEvent != null)
            {
                AllMessagesReceived();
            }
        }

        partial void AllMessagesReceived();
     }

     public partial class MembershipSagaData : IContainSagaData
     {
           public virtual Guid Id { get; set; }
           public virtual string Originator { get; set; }
           public virtual string OriginalMessageId { get; set; }

           public virtual OrderPlacedEvent OrderPlacedEvent { get; set; }
           public virtual InvoiceSentInEncashmentEvent InvoiceSentInEncashmentEvent { get; set; }

    }

	
}