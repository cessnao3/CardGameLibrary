using System;
using System.Collections.Generic;
using System.Text;

namespace CardGameLibrary.GameParameters
{
    /// <summary>
    /// Defines an action that can be taken by the player
    /// </summary>
    public class Action
    {
        /// <summary>
        /// The data parameter to be used in selecting the 
        /// </summary>
        public int data { get; protected set; }

        /// <summary>
        /// The name associated with the action parameter
        /// </summary>
        public string name { get; protected set; }

        /// <summary>
        /// Creates an action parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public Action(string name, int data)
        {
            this.data = data;
            this.name = name;
        }

        /// <summary>
        /// Defines the overall action database to be used for parsing card actions
        /// </summary>
        public static readonly Dictionary<int, Action> action_database = new Dictionary<int, Action>()
        {
            [EuchreParameters.go_alone.data] = EuchreParameters.go_alone,
            [EuchreParameters.pickup_card.data] = EuchreParameters.pickup_card,
            [EuchreParameters.skip.data] = EuchreParameters.skip,
        };
    }
}
