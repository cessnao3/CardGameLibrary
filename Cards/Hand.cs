﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CardGameLibrary.Cards
{
    /// <summary>
    /// Provides a hand that contains a card value
    /// </summary>
    public class Hand
    {
        /// <summary>
        /// Defines the cards present in the player hand
        /// </summary>
        public List<Card> cards { get; private set; }

        /// <summary>
        /// Initializes an empty player hand
        /// </summary>
        public Hand()
        {
            cards = new List<Card>();
        }

        /// <summary>
        /// Sorts the cards based on the default card comparison
        /// </summary>
        public void Sort()
        {
            cards.Sort(Card.DefaultComparison);
        }

        /// <summary>
        /// Adds a card to the hand if not null
        /// </summary>
        /// <param name="c">The card to add to the hand</param>
        public void AddCard(Card c)
        {
            if (c == null) throw new ArgumentNullException("Card may not be null");
            cards.Add(c);
        }

        /// <summary>
        /// Plays a card if present in the hand, throwing an error if the card doesn't exist in the player's hand
        /// </summary>
        /// <param name="c">The card to play/remove</param>
        public void PlayCard(Card c)
        {
            if (!cards.Remove(c))
            {
                throw new ArgumentException("Cannot play a card that is not in the hand");
            }
        }

        /// <summary>
        /// Determines if the player has a card of the given suit
        /// </summary>
        /// <param name="suit">The suit to check</param>
        /// <returns>True if the player has a card of the given suit</returns>
        public bool HasCardOfSuit(Card.Suit suit)
        {
            foreach (Card c in cards)
            {
                if (c.suit == suit)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines if the player has a specific card
        /// </summary>
        /// <param name="card">The card to check</param>
        /// <returns>True if the player has the requested card</returns>
        public bool HasCard(Card card)
        {
            foreach (Card c in cards)
            {
                if (c.Equals(card))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Clears the player's hand, resetting to an empty hand
        /// </summary>
        public void Clear()
        {
            cards.Clear();
        }
    }
}
