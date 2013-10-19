using System;
using System.ServiceModel;
using RemoteConsole;

namespace RemoteRepl
{
	[ServiceContract(CallbackContract = typeof(IConsoleService))]
	public interface ICSharpReplService : IConsoleCallback
	{
		[OperationContract(IsOneWay=true)]
		void Run();
	}
}

