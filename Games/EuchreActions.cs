using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CardGameLibrary.Games
{
    public class EuchreParameters
    {
        public static readonly Action go_alone = new Action(
            name: "Go Alone",
            data: 10);

        public static readonly Action pickup_card = new Action(
            name: "Pickup Card",
            data: 12);

        public static readonly Action skip = new Action(
            name: "Skip",
            data: 14);
    }
}
