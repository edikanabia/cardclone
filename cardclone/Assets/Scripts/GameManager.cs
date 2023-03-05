using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //initialize info
    int deckSize = 24; //this should always be a multiple of six
    public GameObject cardObject;

    //scorekeeping
    int playerScore, opponentScore = 0;

    //keeping track of cards
    //[SerializeField] List<Card> deck;
    [SerializeField] List<GameObject> cardDeck; //keeps all cards on screen

    



    // Start is called before the first frame update
    void Start()
    {
        //rock
        for(int i = 0; i <deckSize/3; i++)
        {
            cardDeck.Add(cardObject);
            Card card = cardDeck[i].GetComponent<Card>();
            card.rpsType = Card.CardType.Rock;
            Instantiate(cardDeck[i]);
        }

        //paper
        for (int i = 0; i < deckSize / 3; i++)
        {
            cardDeck.Add(cardObject);
            Card card = cardDeck[i].GetComponent<Card>();
            card.rpsType = Card.CardType.Paper;
            Instantiate(cardDeck[i]);
        }
        
        //scissors
        for (int i = 0; i < deckSize / 3; i++)
        {
            cardDeck.Add(cardObject);
            Card card = cardDeck[i].GetComponent<Card>();
            card.rpsType = Card.CardType.Scissors;
            Instantiate(cardDeck[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ShuffleDeck()
    {

    }
}
