using System;
using Mono.CSharp;

namespace Mono
{
	public class InteractiveBaseShell : InteractiveBase {
		static bool tab_at_start_completes;

		static InteractiveBaseShell ()
		{
			tab_at_start_completes = false;
		}

		internal static Mono.Terminal.LineEditor Editor;

		public static bool TabAtStartCompletes {
			get {
				return tab_at_start_completes;
			}

			set {
				tab_at_start_completes = value;
				if (Editor != null)
					Editor.TabAtStartCompletes = value;
			}
		}

		public static new string help {
			get {
				return InteractiveBase.help +
					"  TabAtStartCompletes      - Whether tab will complete even on empty lines\n";
			}
		}
	}

}

