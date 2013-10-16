using System;

namespace Mono.Terminal
{
	public class RealConsole : IConsole{
		public void Write(object o){ Console.Write(o);}
		public void WriteLine(object ob) {Console.WriteLine(ob);}
		public void WriteLine(){Console.WriteLine();}
		public void WriteLine(string format, params object[] args){
			Console.WriteLine(format, args);
		}
		public void SetCursorPosition(int x, int y){
			Console.SetCursorPosition(x, y);
		}
		public int CursorTop{get{return Console.CursorTop;}}
		public int BufferHeight {get {return Console.BufferHeight;}}
		public ConsoleKeyInfo ReadKey(bool intercept){
			return Console.ReadKey(intercept);
		}
		public int WindowWidth{get{return Console.WindowWidth;}}
		public void Clear(){Console.Clear();}
		public event ConsoleCancelEventHandler CancelKeyPress{
			add{
				Console.CancelKeyPress += value;
			}
			remove{
				Console.CancelKeyPress -= value;
			}
		}
	}
}

