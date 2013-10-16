using System;
using System.IO;
using Mono.CSharp;
using Mono.Terminal;

namespace Mono
{
	public class Driver {
		public static string StartupEvalExpression;
//		static int? attach;
//		static string agent;

		static int Main (string [] args)
		{
			var repl = new repl(new RealConsole());
			return repl.Run();

//			var cmd = new CommandLineParser (Console.Out);
//			cmd.UnknownOptionHandler += HandleExtraArguments;
//
//			// Enable unsafe code by default
//			var settings = new CompilerSettings () {
//				Unsafe = true
//			};
//
//			if (!cmd.ParseArguments (settings, args))
//				return 1;
//
//			var startup_files = new string [settings.SourceFiles.Count];
//			int i = 0;
//			foreach (var source in settings.SourceFiles)
//				startup_files [i++] = source.FullPathName;
//			settings.SourceFiles.Clear ();
//
//			TextWriter agent_stderr = null;
//			ReportPrinter printer;
//			if (agent != null) {
//				agent_stderr = new StringWriter ();
//				printer = new StreamReportPrinter (agent_stderr);
//			} else {
//				printer = new ConsoleReportPrinter ();
//			}
//
//			var eval = new Evaluator (new CompilerContext (settings, printer));
//
//			eval.InteractiveBaseClass = typeof (InteractiveBaseShell);
//			eval.DescribeTypeExpressions = true;
//			eval.WaitOnTask = true;
//
//			CSharpShell shell;
//			#if !ON_DOTNET
//			if (attach.HasValue) {
//				shell = new ClientCSharpShell (eval, attach.Value);
//			} else if (agent != null) {
//				new CSharpAgent (eval, agent, agent_stderr).Run (startup_files);
//				return 0;
//			} else
//				#endif
//			{
//				shell = new CSharpShell (eval, console);
//			}
//			return shell.Run (startup_files);
		}

//		static int HandleExtraArguments (string [] args, int pos)
//		{
//			switch (args [pos]) {
//				case "-e":
//				if (pos + 1 < args.Length) {
//					StartupEvalExpression = args[pos + 1];
//					return pos + 1;
//				}
//				break;
//				case "--attach":
//				if (pos + 1 < args.Length) {
//					attach = Int32.Parse (args[1]);
//					return pos + 1;
//				}
//				break;
//				default:
//				if (args [pos].StartsWith ("--agent:")) {
//					agent = args[pos];
//					return pos + 1;
//				} else {
//					return -1;
//				}
//			}
//			return -1;
//		}

	}
}

