using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration7
{
    public class Move : Command
    {
        public Move() : base(["move", "go", "head", "leave"])
        {
            
        }

        private static bool CheckMoveCommand(string command)
        {
            return command == "move" || command == "go" || command == "head" || command == "leave";
        }

        public override string Execute(Player p, string[] text)
        {
            string location;
            string error = "Where do you want to go?";
            string error1 = "Error in move command.";

            if (text.Length < 2 && CheckMoveCommand(text[0].ToLower()))
            {
                return error;
            }
            if (text.Length == 2 && CheckMoveCommand(text[0].ToLower()))
            {
                location = text[1].ToLower();
            }
            else
            {
                return error1;
            }
            return MoveTo(location, p);
        }

        private static string MoveTo(string location, Player p)
        {
            GameObject path = p.Location.Locate(location);
            string nopath = "The exit is not available.";

            if (path == null)
            {
                return nopath;
            }
            else
            {
                p.Move((Path)path);
                return $"You have moved {path.FirstID} through a {path.Name} from {p.SourceLocation.Name} to {p.Location.Name}, {p.Location.FullDescription}{p.Location.PathList}";
            }
        }
    }
}
