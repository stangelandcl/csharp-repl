using System;
using Mono.CSharp;
using Mono;
using Mono.Terminal;
using RemoteConsole;

namespace Mono
{
	public class repl
	{
		public repl (IConsole console, RealConsoleCallback callback)
		{
			this.console = console;
			this.callback = callback;
		}

		IConsole console;
		RealConsoleCallback callback;

		public int Run(){		
			// Enable unsafe code by default
			var settings = new CompilerSettings () {
				Unsafe = true
			};

			var startup_files = new string [0];		
			settings.SourceFiles.Clear ();
			ReportPrinter printer= new ConsoleReportPrinter ();
			var eval = new Evaluator (new CompilerContext (settings, printer));
			eval.InteractiveBaseClass = typeof (InteractiveBaseShell);
			eval.DescribeTypeExpressions = true;
			eval.WaitOnTask = true;

			CSharpShell shell;
			#if !ON_DOTNET
			if (attach.HasValue) {
				shell = new ClientCSharpShell (eval, attach.Value);
			} else if (agent != null) {
				new CSharpAgent (eval, agent, agent_stderr).Run (startup_files);
				return 0;
			} else
				#endif
			{
				shell = new CSharpShell (eval, console, callback);
			}
			return shell.Run (startup_files);
		}
	}
}

