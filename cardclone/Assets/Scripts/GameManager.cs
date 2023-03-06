using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //initialize info
    int deckSize = 24;
    public GameObject cardObject; //passes in card prefab

    //scorekeeping
    [SerializeField] int playerScore, opponentScore = 0;
    TMP_Text playerScoreDisplay;
    TMP_Text opponentScoreDisplay;



    //keeping track of cards
    [SerializeField] List<GameObject> cardDeck; //all cards on screen

    



    // Start is called before the first frame update
    void Start()
    {
        //adds rock to deck
        for(int i = 0; i <deckSize/3; i++)
        {
            cardDeck.Add(cardObject);
            Card card = cardDeck[i].GetComponent<Card>();
            card.rpsType = Card.CardType.Rock;
            Instantiate(cardDeck[i]);
        }

        //adds paper to deck
        for (int i = 0; i < deckSize / 3; i++)
        {
            cardDeck.Add(cardObject);
            Card card = cardDeck[i].GetComponent<Card>();
            card.rpsType = Card.CardType.Paper;
            Instantiate(cardDeck[i]);
        }
        
        //adds scissors to deck
        for (int i = 0; i < deckSize / 3; i++)
        {
            cardDeck.Add(cardObject);
            Card card = cardDeck[i].GetComponent<Card>();
            card.rpsType = Card.CardType.Scissors;
            Instantiate(cardDeck[i]);
        }

        playerScoreDisplay = GameObject.Find("Player Score").GetComponent<TMP_Text>();
        opponentScoreDisplay = GameObject.Find("Opponent Score").GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        playerScoreDisplay.text = playerScore.ToString();
        opponentScoreDisplay.text = opponentScore.ToString();
    }


    void ShuffleDeck()
    {

    }
}
