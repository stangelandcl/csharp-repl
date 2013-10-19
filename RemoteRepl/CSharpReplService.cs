using System;
using Mono;
using System.ServiceModel;
using RemoteConsole;
using System.Threading;

namespace RemoteRepl
{
	//[CallbackBehavior(UseSynchronizationContext=false)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,
	                 ConcurrencyMode = ConcurrencyMode.Reentrant)]
	public class CSharpReplService : ICSharpReplService
	{
		public CSharpReplService ()
		{
			var console = OperationContext.Current.GetCallbackChannel<IConsoleService>();
			repl = new repl(new ConsoleServiceClient(console), cancel);		
		}
		repl repl;
		RealConsoleCallback cancel = new RealConsoleCallback();

		public void Run(){
			Console.WriteLine("Running");
			//repl.Run();
			var t = new Thread(()=>repl.Run());
			t.Start();
			//return repl.Run();
		}

		public void CancelKeyPress(){
			cancel.CancelKeyPress();
		}
	}
}

