using DIRC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dirk
{
    class LineFormatterService
    {
        public static string FormatIncomingLine(string line)
        {
            string[] line_parts = line.Split(' ');
            switch(line_parts[1])
            {
                case "NOTICE":
                    if (line_parts[2] == "Auth")
                    {
                        return "<AuthServ>" + ParseIRC.GetSpokenLine(line);
                    }
                    else
                    {
                        return "<" + ParseIRC.GetUsernameSpeaking(line) + "@notice>" + ParseIRC.GetSpokenLine(line);
                    }

                // Private messages can come from other users or channels
                case "PRIVMSG":
                    return "<" + ParseIRC.GetUsernameSpeaking(line) + "> " + ParseIRC.GetSpokenLine(line);

                // We don't really care about mode changes yet
                case "MODE":
                    return line;

                // We also don't really care about people joining/leaving channels yet either
                case "JOIN":
                    return line_parts[2].Split(':')[1];

                // Server-relevant messages
                case "001":
                case "002":
                case "003":
                case "004":
                case "005":
                case "042":
                case "251":
                case "252":
                case "254":
                case "255":
                case "265":
                case "266":
                case "372":
                case "375":
                case "376":
                case "396":
                    return line_parts[0];

                // Channel-relevant messages
                case "332": // TOPIC
                case "333": // TOPIC set-by line
                case "366": // End-of-NAMES message
                    return line_parts[3];
                case "353": // NAMES list
                    return line_parts[4];
                    
                default:
                    return "RAW: " + line;
            }
        }
    }
}
