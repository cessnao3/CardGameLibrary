using System;
using System.Collections.Generic;
using System.Text;

namespace CardGameLibrary.Messages
{
    /// <summary>
    /// Class to facilitate communication within a game
    /// </summary>
    public class MsgGamePlay : MsgBase
    {
        /// <summary>
        /// Defines the game ID to use
        /// </summary>
        public int game_id { get; set; }

        /// <summary>
        /// Sets up the player requesting the action
        /// </summary>
        public GameParameters.GamePlayer player { get; set; }

        /// <summary>
        /// Defines the card to play
        /// </summary>
        public Cards.Card card { get; set; }

        /// <summary>
        /// Constructor to set the server response
        /// </summary>
        public MsgGamePlay() : base(MessageType.GamePlay)
        {
            // Initialize an empty game ID
            game_id = -1;
        }


        /// <summary>
        /// Checks whether message parameters are valid
        /// </summary>
        /// <returns>true if valid</returns>
        public override bool CheckMessage()
        {
            return
                game_id >= 0 &&
                card != null &&
                player != null &&
                msg_type == MessageType.GamePlay;
        }
    }
}
