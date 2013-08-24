using System.Collections.Generic;

namespace delvers.Log
{
	using delvers.Characters;

	public class GameLogger
	{
		private static readonly IList<string> Logs = new List<string>();
 
		public static void ResetLog()
		{
			Logs.Clear();
		}

		public static void Log(string value)
		{
			Logs.Add(value);
		}

		public static void LogFormat(string template, params object[] values)
		{
			Logs.Add(string.Format(template, values));
		}

		public static void LogTurnStart(int turnNumber)
		{
			Logs.Add("--- TURN " + turnNumber + " ---");
		}

		public static void LogTurnEnd(IList<Player> players)
		{
			Logs.Add("--- PLAYER STATS ---");
			foreach (var player in players)
			{
				Logs.Add(string.Format("Name: {0}, Hp: {1}", player.Name, player.Hp));
			}
		}

		public static IList<string> GameLogs()
		{
			return Logs;
		}
	}
}
