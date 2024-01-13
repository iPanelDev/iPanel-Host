using System;

using Microsoft.Extensions.Hosting;

namespace iPanel.Core.Interaction;

public abstract class Command
{
    protected readonly IHost _host;
    protected IServiceProvider Services => _host.Services;

    protected Command(IHost host)
    {
        _host = host;
    }

    public abstract void Parse(string[] args);
}
