using CardGameLibrary.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGameLibrary.Messages
{
    /// <summary>
    /// Provides the game status for Hearts
    /// </summary>
    public class MsgGameStatus : MsgBase
    {
        /// <summary>
        /// Defines the ID of the game
        /// </summary>
        public int game_id = -1;

        /// <summary>
        /// Defines the game type of the game
        /// </summary>
        public int game_type = -1;

        /// <summary>
        /// The players to read in
        /// </summary>
        public List<GameParameters.GamePlayer> players;

        /// <summary>
        /// The hands for each player
        /// </summary>
        public List<Hand> hands;

        /// <summary>
        /// The center pool of cards for each player
        /// </summary>
        public List<Card> played_cards_by_player;

        /// <summary>
        /// The center cards that can be used for selecting trump or
        /// performing other similar actions
        /// </summary>
        public List<Card> center_action_cards;

        /// <summary>
        /// The current score for each player
        /// </summary>
        public List<int> scores;

        /// <summary>
        /// Defines the current game status for different games
        /// </summary>
        public string current_game_status;

        /// <summary>
        /// The current player needing to play
        /// </summary>
        public int current_player;

        /// <summary>
        /// Default hearts game status constructor
        /// </summary>
        public MsgGameStatus() : base(MessageType.GameStatus)
        {
            // Empty Constructor
        }

        /// <summary>
        /// Checks that the hearts game status is valid
        /// </summary>
        /// <returns>True if valid</returns>
        public override bool CheckMessage()
        {
            return
                msg_type == MessageType.GameStatus &&
                players != null &&
                hands != null &&
                current_game_status != null &&
                game_id >= 0 &&
                scores != null &&
                game_type > 0;
        }
    }
}
