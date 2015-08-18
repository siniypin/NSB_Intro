using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example1.UI.Controllers
{
    public partial class TestMessagesController
    {
        // TODO: Example1.UI: Configure sent/published messages' properties implementing the partial Configure[MessageName] method.");
        partial void ConfigurePlaceOrderCommand(Internal.Commands.Payments.PlaceOrderCommand message)
        {
            message.UserId = 1;
            message.Price = 1;
        }
    }
}

