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
using Example3.Internal.Commands.Payments;


namespace Example3.Payments
{
    public partial class CreateInvoiceCommandHandler : IHandleMessages<CreateInvoiceCommand>
    {
		
		public void Handle(CreateInvoiceCommand message)
		{
			// Handle message on partial class
			this.HandleImplementation(message);
		}

		partial void HandleImplementation(CreateInvoiceCommand message);

        public IBus Bus { get; set; }

    }

	
}