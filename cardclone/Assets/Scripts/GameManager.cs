using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    enum GameState
    {
        Shuffling, 
        Dealing,
        Playing,
        Discarding,
        Resetting //foreach card, reset values
    }

    GameState gameState = GameState.Shuffling;

    //card prefab
    public GameObject cardObj;


    //deck
    int deckSize = 24;
    [SerializeField]List<GameObject> deck;

    [SerializeField] List<GameObject> discard;
    [SerializeField] List<GameObject> playerHand;
    [SerializeField] List<GameObject> opponentHand;

    [SerializeField] List<Card> inPlay;

    Card playerSelected, opponentSelected;

    //score
    int playerScore, opponentScore = 0;
    TMP_Text playerScoreDisp;
    TMP_Text oppScoreDisp;

    //position
    [SerializeField] List<Transform> cardTargets; //0 = deck, 9 = discard,
                                                  //1-3 = opponent hand,
                                                  //4-6 = player hand,
                                                  //7 = opponent choice,
                                                  //8 = player choice
    
    //testing bools
    bool isShuffled = false;
    bool dealt = false;
    public bool isPlayerTurn = false;
    bool resultChecked = false;


    // Start is called before the first frame update
    void Start()
    {
        //generate list of cards
        //8 rock
        for(int i = 0; i < deckSize / 3; i++)
        {
            GameObject newCard = Instantiate(cardObj);
            deck.Add(newCard);
            newCard.GetComponent<Card>().rpsType = Card.CardType.Rock;
        }
        //8 paper
        for (int i = 0; i < deckSize / 3; i++)
        {
            GameObject newCard = Instantiate(cardObj);
            deck.Add(newCard);
            newCard.GetComponent<Card>().rpsType = Card.CardType.Paper;
        }
        //8 scissors
        for (int i = 0; i < deckSize / 3; i++)
        {
            GameObject newCard = Instantiate(cardObj);
            deck.Add(newCard);
            newCard.GetComponent<Card>().rpsType = Card.CardType.Scissors;
        }

        playerScoreDisp = GameObject.Find("Player Score").GetComponent<TMP_Text>();
        oppScoreDisp = GameObject.Find("Opponent Score").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreDisp.text = playerScore.ToString();
        oppScoreDisp.text = opponentScore.ToString();

        if(gameState == GameState.Shuffling)
        {
            if (!isShuffled)
            {
                ShuffleDeck();
            }
        }
        if(gameState == GameState.Dealing)
        {
            if (!dealt)
            {
                DealCards();
            }
        }
        
        if(gameState == GameState.Playing)
        {
            if (!isPlayerTurn)
            {
                OpponentTurn();
            }
            
        }
        if(gameState == GameState.Discarding)
        {
            if (!resultChecked)
            {
                CheckResult();
            }
            
        }


    }

    void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            GameObject tempCard = deck[i];
            int rand = Random.Range(i, deck.Count);
            deck[i] = deck[rand];
            deck[rand] = tempCard;
            deck[i].GetComponent<Card>().targetPos = cardTargets[0];
            //it is with a heavy heart that i make the decision to hardcode every transform position index

            isShuffled = true;
            gameState = GameState.Dealing;
        }
    }

    void DealCards()
    {
        //deal opponent cards
        for(int i = 3; i > 0; i--)
        {
            GameObject handCard = deck[deckSize - 1]; //deals from top of deck/end of list
            handCard.GetComponent<Card>().targetPos = cardTargets[i]; //places card in proper area
            opponentHand.Add(handCard); //adds to opponents hand (list)
            deck.RemoveAt(deckSize - 1); //removes from deck
            deckSize--; //counts down

        }

        //deal player cards
        for (int i = 6; i > 3; i--)
        {
            GameObject handCard = deck[deckSize - 1]; //deals from "top" of deck/end of list
            Card cardInfo = handCard.GetComponent<Card>(); //allows us to get info w/o repeatedly calling functions.
            cardInfo.targetPos = cardTargets[i]; //places in proper area
            cardInfo.isFaceUp = true; //deals player cards face up
            cardInfo.playerCard = true; //marks cards as player's
            playerHand.Add(handCard); //adds to player's hand (list)
            deck.RemoveAt(deckSize - 1); //removes from deck
            deckSize--; //counts down

        }
        dealt = true;
        gameState = GameState.Playing;
    }

    void OpponentTurn()
    {
        int rand = Random.Range(0, 3);
        opponentSelected = opponentHand[rand].GetComponent<Card>();
        opponentSelected.targetPos = cardTargets[7];
        isPlayerTurn = true;
    }

    public void PlayerTurn(Card clicked)
    {
        playerSelected = clicked;
        playerSelected.targetPos = cardTargets[8];
        gameState = GameState.Discarding;
    }

    void CheckResult()
    {
        playerSelected.isFaceUp = true;
        opponentSelected.isFaceUp = true;

        //if player card is rock
        if(playerSelected.rpsType is Card.CardType.Rock)
        {
            switch (opponentSelected.rpsType)
            {
                case Card.CardType.Paper:
                    opponentScore++;
                    break;
                case Card.CardType.Scissors:
                    playerScore++;
                    break;
                default:
                    break;
               
            }
        }

        //if player card is paper
        if (playerSelected.rpsType is Card.CardType.Paper)
        {
            switch (opponentSelected.rpsType)
            {
                case Card.CardType.Scissors:
                    opponentScore++;
                    break;
                case Card.CardType.Rock:
                    playerScore++;
                    break;
                default:
                    break;

            }
        }

        //if player card is scissors
        if (playerSelected.rpsType is Card.CardType.Scissors)
        {
            switch (opponentSelected.rpsType)
            {
                case Card.CardType.Rock:
                    opponentScore++;
                    break;
                case Card.CardType.Paper:
                    playerScore++;
                    break;
                default:
                    break;

            }
        }

        resultChecked = true;

    }

    //void Discard()
    //{
    //    foreach(GameObject card in playerHand)
    //    {
    //        discard.Add(card);
    //        playerHand.Remove(card);
    //    }
    //    foreach (GameObject card in opponentHand)
    //    {
    //        discard.Add(card);
    //        opponentHand.Remove(card);
    //    }
    //}

}
