using System;
using WcfPeer;
using System.ServiceModel;
using RemoteConsole;
using System.Linq;
using System.Threading;

namespace RemoteRepl
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if(args.Any() && args[0] == "server"){
				var host = MultiServiceHost.Default;
				//host.Add<PingService>();
				host.Add<CSharpReplService>();
				host.Open();
				Thread.Sleep(Timeout.Infinite);
				
				Console.WriteLine("Opened");
				Thread.Sleep(Timeout.Infinite);
			}else{					
				var client = DuplexClientFactory.Default.New<ICSharpReplService>("localhost",
				                          new RealConsole());
				Console.CancelKeyPress += (sender, e) => client.CancelKeyPress();
				client.Run();
				Thread.Sleep(Timeout.Infinite);
				GC.KeepAlive(client);

				Console.WriteLine("Running");
				Thread.Sleep(Timeout.Infinite);
//
//				var client = ClientFactory.Default.New<IPingService>("localhost");
//				Console.WriteLine("ping");
//				var bytes = client.Ping(new byte[10]);
//				Console.WriteLine("pong");
//				Thread.Sleep(Timeout.Infinite);
			}
		}
	}
}
