using System;
using System.Collections.Generic;
using System.Text;

namespace NetAdmin.Infrastructure
{
    public interface IHandleCommand
    {
    }

    public interface IHandleCommand<TCommand> : IHandleCommand where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
