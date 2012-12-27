using System;
using System.Collections.Generic;
using GettingReady.Model;

namespace GettingReady.Core
{
    public class CommandParser
    {
        public Mode CommandMode { get; private set; }
        public IList<int> Keys { get; private set; }

        public CommandParser(string commandText)
        {
            Keys = new List<int>();
            var strArray = commandText.Split(',');
            if (strArray.Length > 0)
            {
                var s = strArray[0].Split(' ');

                CommandMode = (Mode)Enum.Parse(typeof(Mode), s[0], true);
                Keys.Add(int.Parse(s[1]));
            }
            for (int i = 1; i < strArray.Length; i++)
            {
                Keys.Add(int.Parse(strArray[i]));
            }
        }
    }
}
