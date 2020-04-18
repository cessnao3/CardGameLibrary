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
        public string name { get; protected set; }

        public Action(string name, int data)
        {
            this.data = data;
            this.name = name;
        }
    }
}
