namespace Blackbaud.Interview.Cards;

/// <summary>
/// A deck of cards
/// </summary>
public class Deck
{
    private static readonly Random Random = new();
    private Stack<Card> _stackOfCards;

    /// <summary>
    /// Private constructor for a new deck of <paramref name="cards"/>.
    /// Use Deck.NewDeck() static factory method.
    /// </summary>
    /// <param name="cards"></param>
    private Deck(IEnumerable<Card> cards)
    {
        _stackOfCards = new Stack<Card>(cards);
    }

    /// <summary>
    /// Creates and returns a new deck of cards.
    /// </summary>
    /// <returns></returns>
    public static Deck NewDeck()
    {
        return new Deck(
            Enum.GetValues<Suit>().SelectMany(suit =>
                Enum.GetValues<Rank>().Select(rank =>
                    new Card(rank, suit))
        ));
    }

    /// <summary>
    /// Shuffles the current deck once using the Fisher-Yates algorithm.
    /// </summary>
    public void Shuffle()
    {
        var cards = _stackOfCards.ToList();

        for (var i = cards.Count - 1; i > 0; i--)
        {
            var j = Random.Next(0, i + 1);
            (cards[i], cards[j]) = (cards[j], cards[i]);
        }

        _stackOfCards = new Stack<Card>(cards);
    }

    /// <summary>
    /// Shuffles the deck a given number of times.
    /// </summary>
    /// <param name="times"></param>
    public void Shuffle(int times)
    {
        for (var i = 0; i < times; i++)
        {
            Shuffle();
        }
    }

    /// <summary>
    /// The number of remaining cards in the deck
    /// </summary>
    public int RemainingCards => _stackOfCards.Count;

    /// <summary>
    /// Returns true if there are no remaining cards in the deck
    /// </summary>
    public bool Empty => RemainingCards == 0;

    /// <summary>
    /// Removes the next card from the deck.
    /// </summary>
    /// <returns>The next card from the deck.
    /// Returns null if no cards remain.</returns>
    public Card NextCard()
    {
        if (!Empty)
        {
            var nextCard = _stackOfCards.Pop();
            return nextCard;
        }
        else
        {
            return null;
        }
    }

}
