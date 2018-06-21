using System;
using System.Threading.Tasks;
using Example1.Contracts.Billing;
using Example1.Contracts.Sales;
using NServiceBus;

namespace Eample1.Content
{
    public class PremiumContentSubscriptionSaga : Saga<PremiumContentSubscriptionSaga.SubscriptionData>,
        IAmStartedByMessages<OrderAcceptedEvent>, IAmStartedByMessages<OrderBilledEvent>,
        IHandleTimeouts<PremiumContentSubscriptionSaga.SubscriptionExpired>,
        IHandleTimeouts<PremiumContentSubscriptionSaga.TrialExpired>
    {
        public async Task Handle(OrderAcceptedEvent message, IMessageHandlerContext context)
        {
            Console.WriteLine("Premium Content saga received " + message);
            Data.UserId = message.UserId;
            Data.OrderId = message.OrderId;
            if (!Data.IsInTrial)
            {
                Data.IsInTrial = true;
                await RequestTimeout(context, TimeSpan.FromDays(10),
                    new TrialExpired {OrderId = message.OrderId});
            }

            await ActivateSubscription(message.OrderId, context);
            await RequestTimeout(context, TimeSpan.FromSeconds(10), new TrialExpired {OrderId = message.OrderId});

            await Task.CompletedTask;
        }

        public async Task Handle(OrderBilledEvent message, IMessageHandlerContext context)
        {
            Console.WriteLine("Premium Content saga received " + message);
            Data.UserId = message.UserId;
            Data.OrderId = message.OrderId;
            Data.IsInTrial = false;
            await ActivateSubscription(message.OrderId, context);

            await Task.CompletedTask;
        }

        public async Task Timeout(SubscriptionExpired state, IMessageHandlerContext context)
        {
            Console.WriteLine("Premium Content saga expired");
            Data.IsRunning = false;
            await Task.CompletedTask;
        }

        public async Task Timeout(TrialExpired state, IMessageHandlerContext context)
        {
            if (Data.IsInTrial)
            {
                Console.WriteLine("Premium Content saga trial period expired");
                Data.IsRunning = false;
            }

            await Task.CompletedTask;
        }

        private async Task ActivateSubscription(Guid orderId, IMessageHandlerContext context)
        {
            if (!Data.IsRunning)
            {
                Data.IsRunning = true;
                await RequestTimeout(context, TimeSpan.FromSeconds(30), //FromDays(30),
                    new SubscriptionExpired {OrderId = orderId}).ConfigureAwait(false);
            }
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<SubscriptionData> mapper)
        {
            mapper.ConfigureMapping<OrderAcceptedEvent>(from => from.OrderId).ToSaga(x => x.OrderId);
            mapper.ConfigureMapping<OrderBilledEvent>(from => from.OrderId).ToSaga(x => x.OrderId);
            mapper.ConfigureMapping<SubscriptionExpired>(from => from.OrderId).ToSaga(x => x.OrderId);
        }

        public class SubscriptionData : ContainSagaData
        {
            public int UserId { get; set; }
            public Guid OrderId { get; set; }
            public bool IsRunning { get; set; }
            public bool IsInTrial { get; set; }
        }

        public class SubscriptionExpired : IMessage
        {
            public Guid OrderId { get; set; }
        }

        public class TrialExpired : IMessage
        {
            public Guid OrderId { get; set; }
        }
    }
}