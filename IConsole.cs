using System;

namespace Mono.Terminal
{
	public interface IConsole
	{
		void Write(object o);
		void WriteLine();
		void WriteLine(string format, params object[] args);
		void WriteLine(object o);
		void SetCursorPosition(int x, int y);
		int CursorTop {get;}
		int BufferHeight {get;}
		ConsoleKeyInfo ReadKey(bool intercept);
		int WindowWidth {get;}
		void Clear();
		event ConsoleCancelEventHandler CancelKeyPress;
	}


}

