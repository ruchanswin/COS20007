using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration8
{
    public class CommandProcessor : Command
    {
        readonly List<Command> _commands;

        public CommandProcessor() : base(["command"])
        {
            _commands = [new Look(), new Move()];
        }

        public override string Execute(Player p, string[] text)
        {
            foreach (Command cmd in _commands)
            {
                if (cmd.AreYou(text[0].ToLower()))
                {
                    return cmd.Execute(p, text);
                }
            }
            return "Error in command input.";
        }
    }
}
