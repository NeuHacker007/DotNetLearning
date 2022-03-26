using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Stateless;

namespace FakeXieCheng.API.Models
{
    public enum OrderState
    {
        Pending,
        Processing,
        Completed,
        Declined,
        Cancelled,
        Refund
    }

    public enum OrderStateTrigger
    {
        PlaceOrder,
        Approve,
        Reject,
        Cancel,
        Return,
        ReturnToPending
    }
    public class Order
    {

        public Order()
        {
            StateMachineInit();
        }
        [Key]
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<LineItem> OrderItems { get; set; }

        public OrderState State { get; set; }

        public DateTime CreateDateUtc { get; set; }

        public string TransactionMetaData { get; set; }

        private StateMachine<OrderState, OrderStateTrigger> _matchine;

        public void PaymentProcessing()
        {

            _matchine.Fire(OrderStateTrigger.PlaceOrder);

        }

        public void PaymentApprove()
        {
            _matchine.Fire(OrderStateTrigger.Approve);
        }

        public void PaymentReject()
        {
            _matchine.Fire(OrderStateTrigger.Reject);
        }

        public void PaymentReturn()
        {
            _matchine.Fire(OrderStateTrigger.Return);
        }

        public void PaymentRollBackToPending()
        {
            _matchine.Fire(OrderStateTrigger.ReturnToPending);
        }
        private void StateMachineInit()
        {
            _matchine = new StateMachine<OrderState, OrderStateTrigger>(
                () => State,
                s => State = s);
            _matchine.Configure(OrderState.Pending)
                .Permit(OrderStateTrigger.PlaceOrder, OrderState.Processing)
                .Permit(OrderStateTrigger.Cancel, OrderState.Cancelled);

            _matchine.Configure(OrderState.Processing)
                .Permit(OrderStateTrigger.Approve, OrderState.Completed)
                .Permit(OrderStateTrigger.Reject, OrderState.Declined)
                .Permit(OrderStateTrigger.ReturnToPending, OrderState.Pending);

            _matchine.Configure(OrderState.Declined)
                .Permit(OrderStateTrigger.PlaceOrder, OrderState.Processing);

            _matchine.Configure(OrderState.Completed)
                .Permit(OrderStateTrigger.Return, OrderState.Refund);


        }
    }
}
