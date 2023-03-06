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


        //if (transform.position == targetPos.position)
        //{
        //    moving = false;
        //}

        transform.position = targetPos.position;
        #endregion
    }

    private void OnMouseDown()
    {
        //play card
        if (playerCard)
        {
            Debug.Log("click");
            played = true;
        }

        //switch state in game manager to checking

    }

    private void OnMouseEnter()
    {
        if (playerCard)
        {
            //hover
            _prevPosition = targetPos.position;
            targetPos.position = new Vector3(targetPos.position.x, targetPos.position.y + 0.25f);
            gameManager.PlayerTurn();
        }

    }

    private void OnMouseExit()
    {
        if (playerCard)
        {
            targetPos.position = _prevPosition;
        }
        
    }
}
