using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using CardGameLibrary.Messages;

namespace CardGameLibrary.Network
{
    /// <summary>
    /// A helper class to manage sending/receiving data over the network
    /// </summary>
    public class MessageReader
    {
        /// <summary>
        /// Determines whether to print JSON output to the terminal
        /// </summary>
        protected static bool print_output = false;

        /// <summary>
        /// Message type conversion dictionary defines what message types to use for the provided
        /// message ID values in the JSON packets
        /// </summary>
        readonly static Dictionary<MessageType, Type> type_convert_dict = new Dictionary<MessageType, Type>()
        {
            { MessageType.ClientRequest, typeof(MsgClientRequest) },
            { MessageType.GameList, typeof(MsgGameList) },
            { MessageType.GamePlay, typeof(MsgGamePlay) },
            { MessageType.GameStatus, typeof(MsgGameStatus) },
            { MessageType.Heartbeat, typeof(MsgHeartbeat) },
            { MessageType.LobbyStatus, typeof(MsgLobbyStatus) },
            { MessageType.ServerResponse, typeof(MsgServerResponse) },
            { MessageType.UserLogin, typeof(MsgLogin) }
        };

        /// <summary>
        /// Sets whether console printing of sent/received messages is enabled
        /// </summary>
        /// <param name="enabled">If true, console messages will be output over the consoel</param>
        static public void SetOutputPrinting(bool enabled)
        {
            print_output = enabled;
        }

        /// <summary>
        /// Sends the provided message to the provided TCP client
        /// </summary>
        /// <param name="client">The client to send the message over</param>
        /// <param name="msg">The message to serialize and send</param>
        static public void SendMessage(ClientStruct client, MsgBase msg)
        {
            // Serialize the message
            string s = JsonSerializer.Serialize(msg, msg.GetType());
            if (print_output) Console.WriteLine("Sending " + s);

            // Convert the message to bytes, write, and flush the stream
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            client.stream.Write(bytes, 0, bytes.Length);
            client.stream.Flush();
        }

        /// <summary>
        /// Attempts to receive a message from the provided TCP client
        /// </summary>
        /// <param name="client">The client to read the message from</param>
        /// <returns>A message if found; otherwise null</returns>
        static public MsgBase ReadMessage(ClientStruct client)
        {
            // Check if the client has bytes availble to read
            // If not, return null
            if (client.client.Available > 0)
            {
                // Read the string
                StringBuilder sb = new StringBuilder();

                char c = '\0';
                int colon_count = 0;
                while ((c != '}' || colon_count > 0) && sb.Length < 10240)
                {
                    c = (char)client.stream.ReadByte();
                    sb.Append(c);

                    if (c == '{') colon_count += 1;
                    else if (c == '}') colon_count -= 1;
                }

                string s = sb.ToString();

                // Print the string output
                if (print_output) Console.WriteLine("Receiving " + s);

                // Extract the message type to use in parsing
                MessageType msg_type = MessageType.Invalid;

                {
                    // Parse the JSON document
                    JsonDocument msg_doc = JsonDocument.Parse(s);

                    // Define a value to use for pulling out the message type
                    JsonElement msg_type_element;

                    // Define an integer to use to extract the type id
                    int msg_type_id_int;

                    // Pull out the message type, and if successful, extract the message type value
                    if (msg_doc.RootElement.TryGetProperty("msg_type", out msg_type_element) &&
                        msg_type_element.TryGetInt32(out msg_type_id_int))
                    {
                        msg_type = (MessageType)msg_type_id_int;
                    }
                }

                // Define the message item
                MsgBase msg_item = null;

                if (type_convert_dict.ContainsKey(msg_type))
                {
                    msg_item = (MsgBase)JsonSerializer.Deserialize(
                        s,
                        type_convert_dict[msg_type]);

                    if (msg_item != null && !msg_item.CheckMessage())
                    {
                        msg_item = null;
                    }
                }
                else
                {
                    msg_item = null;
                }

                // Return the parsed message, or null if all failed
                return msg_item;
            }
            // Return null if no bytes available to read
            else
            {
                return null;
            }
        }
    }
}
