using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.GotDotNet;
using System.Reflection;
using Konsole;
using System.Collections.Concurrent;
using Konsole.Internal;

namespace MediSync {
	public class ConsoleHelper {

		public class Spinner {

			private static PerrysNetConsole.LoadIndicator staticLoadIndicator;
			private PerrysNetConsole.LoadIndicator spinner;

			public static PerrysNetConsole.LoadIndicator CreateNew(bool overrideSilent = false)  {
                
                PerrysNetConsole.LoadIndicator li = new PerrysNetConsole.LoadIndicator();
				li.Color = new PerrysNetConsole.ColorScheme(ConsoleColor.Black, ConsoleColor.Green);
				return li;
			}

            public static PerrysNetConsole.LoadIndicator CreateNew() {
                PerrysNetConsole.LoadIndicator li = new PerrysNetConsole.LoadIndicator();
                li.Color = new PerrysNetConsole.ColorScheme(ConsoleColor.Black, ConsoleColor.Green);
                return li;
            }

            private static void CreateStatic() {
				staticLoadIndicator = new PerrysNetConsole.LoadIndicator();
				staticLoadIndicator.Color = new PerrysNetConsole.ColorScheme(ConsoleColor.Black, ConsoleColor.Green);
			}

			public static void Start(string text, ConsoleForeground color = ConsoleForeground.Green, bool overrideSilent = false) {
    //            if (staticLoadIndicator == null)
				//	staticLoadIndicator = CreateNew();

    //            staticLoadIndicator.Stop();
    //            staticLoadIndicator.Message = "";

				//if (text != null) {
				//	staticLoadIndicator.Message = text;
				//}
				
    //            if (staticLoadIndicator != null) {
    //                staticLoadIndicator.Start();
    //            } else {
    //                staticLoadIndicator = CreateNew();
    //                staticLoadIndicator.Start();
    //            }
			}

			public static void Start(bool overrideSilent = false) {
                //if (!overrideSilent) {
                //    if (JobList.DoSilently) { return; }
                //}
                //Start("");
			}

			public static void Message(string msg, bool overrideSilent = false) {
                if (!overrideSilent) {
                    if (JobList.DoSilently) { return; }
                }
                if (staticLoadIndicator != null) {
					staticLoadIndicator.Message = msg;
				}
			}

			public static void Stop(bool overrideSilent = false) {
                if (!overrideSilent) {
                    if (JobList.DoSilently) { return; }
                }
                if (staticLoadIndicator != null) {
					staticLoadIndicator.Stop();
				} else {
					staticLoadIndicator = CreateNew();
				}
			}

            public static void Destroy(bool overrideSilent = false) {
                if (!overrideSilent) {
                    if (JobList.DoSilently) { return; }
                }
                if (staticLoadIndicator != null && staticLoadIndicator.IsRunning) {
                    staticLoadIndicator.Stop();
                }
                staticLoadIndicator = null;
            }
        }

        /// <summary>
        /// Asks a question and awaits user input.  This function is thread-blocking.
        /// </summary>
        /// <param name="question">The boolean question to ask.</param>
        /// <returns>A boolean response.</returns>
        public static bool AskBoolean(String question) {
            if (JobList.DoSilently) { return false; }
            if (!question.Contains("[y/n]"))
                question = question.Replace("[y/n]", "");
                question += " [y/n]";

            System.Console.WriteLine(question);
            String userInput = System.Console.ReadLine();
                return (userInput.StartsWith("y") || userInput.StartsWith("Y") || userInput == String.Empty);
        }

        public static void WaitForInput(bool clear = false, bool showMenu = true) {
            if (JobList.DoSilently) { return; }
            ConsoleEx.Title = Assembly.GetExecutingAssembly().GetName().ToString();
            if (clear) {
                System.Console.Clear();
            } else {
                System.Console.WriteLine();
            }

            if (showMenu) {
                ConsoleHelper.WriteLine("-= MediSync =-", ConsoleForeground.Cyan);
                ConsoleHelper.WriteLine("1 - Get job list");
                ConsoleHelper.WriteLine("2 - Start monitoring");
                ConsoleHelper.WriteLine("3 - Options");
                ConsoleHelper.WriteLine("4 - Exit");
                System.Console.WriteLine();
                ConsoleHelper.WriteLine("Type \"options\" to enter Options or \"exit\" to exit at any time.", ConsoleForeground.DarkGray);
            }
            
            String input = System.Console.ReadLine();
            input = input.Trim().ToLower();
            switch (input) {
                // Get the list of jobs available for execution
                case "1":
                    MainForm.QueryAndShowAvailableJobs(true);
                    break;
                // Execute the jobs in our list
                case "2":
                    System.Console.WriteLine();
                    MainForm.startDbMonitor();
                    break;
                case "3":
                    ConsoleHelper.WriteLine("Entering options...", ConsoleForeground.Yellow);
                    OpenOptions();
                    break;
                case "4":
                    ConsoleHelper.WriteLine("Exiting...", ConsoleForeground.Red);
                    System.Threading.Thread.Sleep(800);
                    break;
                case "options":
                    ConsoleHelper.WriteLine("Entering options...", ConsoleForeground.Yellow);
                    OpenOptions();
                    break;
                case "quit":
                    ConsoleHelper.WriteLine("Exiting...", ConsoleForeground.Red);
                    System.Threading.Thread.Sleep(500);
                    break;
                case "exit":
                    ConsoleHelper.WriteLine("Exiting...", ConsoleForeground.Red);
                    System.Threading.Thread.Sleep(500);
                    break;
                default:
                    WaitForInput();
                    break;
            }
        }

        public static void PressAnyKey() {
            if (JobList.DoSilently) { return; }
            Spinner.Destroy();
            ConsoleHelper.WriteLine("Press any key to continue", ConsoleForeground.DarkGray);
            Console.ReadKey();
        }

        public static String PressAnyNumberKey(String msg, bool returnKeyPressed) {

            if (JobList.DoSilently) { return ""; }
            ConsoleHelper.WriteLine(msg, ConsoleForeground.Green);
            return Console.ReadKey().KeyChar.ToString();
        }

        public static void Clear(bool AddBlankLineAbove = false) {
            if (JobList.DoSilently) { return; }
            Console.Clear();
            if (AddBlankLineAbove) {
                Console.WriteLine();
            }
        }

        public static void OpenOptions() {
            if (JobList.DoSilently) { return; }
            System.Threading.Thread.Sleep(1000);
            System.Console.Clear();
            System.Console.WriteLine();
            ConsoleHelper.WriteLine("-= OPTIONS =-", ConsoleForeground.Yellow);
            ConsoleHelper.WriteLine("1 : Clear default CRM configuration...", ConsoleForeground.Green);
            ConsoleHelper.WriteLine("\n\n0 : Exit options", ConsoleForeground.Blue);
            String selection = System.Console.ReadLine();
            switch (selection) {
                case "0":
                    System.Console.WriteLine();
                    ConsoleHelper.WaitForInput(true);
                    break;
                case "1":
                    System.Console.WriteLine();
                    // Settings.DefaultCrmServerChoice = "";
                    ConsoleHelper.WriteLine("Cleared");
                    System.Threading.Thread.Sleep(700);
                    OpenOptions();
                    break;
                default:
                    OpenOptions();
                    break;
            }
        }

        /// <summary>
        /// Changes the forecolor of any text entered into the console going forward.
        /// </summary>
        /// <param name="color"></param>
        public static void Color(ConsoleForeground color) {
            ConsoleEx.TextColor(color, ConsoleBackground.Black);
        }

        /// <summary>
        /// Writes a line of text with an optional forecolor.
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="color">The optional forecolor</param>
        /// <param name="overwrite">Whether or not to overwrite the current line instead of making a new line</param>
        public static void WriteLine(String text, ConsoleForeground color = ConsoleForeground.White, bool overwrite = false) {

            if (overwrite) { text = "\r" + text; }
            Color(color);
            System.Console.WriteLine(text);
            ResetColor();
        }
        
        public static void CarriageReturn() {
            if (JobList.DoSilently) { return; }
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Writes text with an optional forecolor.
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="color">The optional forecolor</param>
        public static void Write(String text, ConsoleForeground color = ConsoleForeground.White) {
            if (JobList.DoSilently) { return; }
            Color(color);
            System.Console.Write(text);
            ResetColor();
        }

        /// <summary>
        /// Inputs a carriage return.
        /// </summary>
        public static void WriteLine() {
            if (JobList.DoSilently) { return; }
            System.Console.WriteLine();
        }

        public static void ReuseLine() {
            if (JobList.DoSilently) { return;  }
            System.Console.Write("\n");
        }

		public static void ReuseLine(string text, 
				ConsoleForeground color = ConsoleForeground.Green) {
            if (JobList.DoSilently) { return; }
            Color(color);
			System.Console.Write("\n");
			System.Console.Write(text);
			ResetColor();
		}

		/// <summary>
		/// Resets the color to default white on black. 
		/// </summary>
		public static void ResetColor() {
            ConsoleEx.TextColor(ConsoleForeground.White, ConsoleBackground.Black);
        }

        /// <summary>
        /// Writes green text.
        /// </summary>
        /// <param name="text">The text to write.</param>
        public static void AppendGood(String text) {
            if (JobList.DoSilently) { return; }
            ConsoleEx.TextColor(ConsoleForeground.Green, ConsoleBackground.Black);
            System.Console.WriteLine(text);
            ConsoleEx.TextColor(ConsoleForeground.White, ConsoleBackground.Black);
        }
        /// <summary>
        /// Writes yellow text.
        /// </summary>
        /// <param name="text">The text to write.</param>
        public static void AppendWarning(String text) {

            if (JobList.DoSilently) { return; }
            ConsoleEx.TextColor(ConsoleForeground.Yellow, ConsoleBackground.Black);
            System.Console.WriteLine(text);
            ConsoleEx.TextColor(ConsoleForeground.White, ConsoleBackground.Black);
        }

    }
}
