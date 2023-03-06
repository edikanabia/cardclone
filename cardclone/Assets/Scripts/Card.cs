using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //set type of card
    public enum CardType
    {
        Rock,
        Paper,
        Scissors
    }
    public CardType rpsType;

    //sprites
    SpriteRenderer cardRenderer;
    public List<Sprite> sprites;
    public bool isFaceUp = false;

    //movement
    public Transform targetPos;
    Vector3 _prevPosition;
    public bool moving;

    //
    public bool playerCard = false;
    public bool played = false;


    GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        cardRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        #region card display logic
        //displays card face
        if (!isFaceUp)
        {
            cardRenderer.sprite = sprites[3];
        }
        else
        {
            cardRenderer.sprite = sprites[(int)rpsType];
        }
        #endregion

        #region movement code

        if (transform.position == targetPos.position)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }

        transform.position = targetPos.position;
        #endregion
    }

    private void OnMouseDown()
    {
        if (gameManager.gameState == GameManager.GameState.Playing && gameManager.isPlayerTurn)
        {
            //play card
            if (playerCard)
            {
                Debug.Log("click");
                played = true;
                gameManager.PlayerTurn(this);
                gameManager.isPlayerTurn = false;
            }
        }
        

        //switch state in game manager to checking

    }

    private void OnMouseEnter()
    {

        if (gameManager.gameState == GameManager.GameState.Playing && gameManager.isPlayerTurn)
        {
            if (playerCard)
            {
                //hover
                _prevPosition = targetPos.position;
                targetPos.position = new Vector3(targetPos.position.x, targetPos.position.y + 0.25f);
            }
        }
        

    }

    private void OnMouseExit()
    {
        //if (gameManager.gameState == GameManager.GameState.Playing && gameManager.isPlayerTurn)
        //{
        //    if (playerCard)
        //    {
        //        targetPos.position = _prevPosition;
        //    }
        //}
        
        
    }
}
