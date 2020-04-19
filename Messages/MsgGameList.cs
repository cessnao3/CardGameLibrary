using System;
using System.Collections.Generic;
using System.Text;

namespace CardGameLibrary.Messages
{
    /// <summary>
    /// Provides information on available game parameters
    /// </summary>
    public class MsgGameList : MsgBase
    {
        /// <summary>
        /// Defines the item parameters for each list
        /// </summary>
        public class ListItem
        {
            /// <summary>
            /// Defines the game ID value
            /// </summary>
            public int id_val;

            /// <summary>
            /// Defines the game type
            /// </summary>
            public int game_type;
        }

        /// <summary>
        /// Defines the list of lobbies, by ID, that may be joined
        /// </summary>
        public List<ListItem> lobbies;

        /// <summary>
        /// Defines the list of games, by ID, that may be played
        /// </summary>
        public List<ListItem> games;

        /// <summary>
        /// Defines the game list message/response
        /// </summary>
        public MsgGameList() : base(MessageType.GameList)
        {
            // Empty Constructor
        }

        /// <summary>
        /// Determines if the message contains a valid message
        /// </summary>
        /// <returns>True if valid</returns>
        public override bool CheckMessage()
        {
            return
                msg_type == MessageType.GameList &&
                lobbies != null &&
                games != null;
        }
    }
}
