using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ProjectPlanner.Cqrs.Base.CQRS.Commands.Decorator
{
    public class TransactionalCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> _inner;

        public TransactionalCommandHandlerDecorator(ICommandHandler<TCommand> inner)
        {
            _inner = inner;
        }

        public void Handle(TCommand command)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                _inner.Handle(command);
                transaction.Complete();
            }
        }
    }
}