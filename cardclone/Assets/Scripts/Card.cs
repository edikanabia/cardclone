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
    public bool moving;

    //states
    public bool playerCard = false;


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
            Debug.Log("face down");
            cardRenderer.sprite = sprites[3];
        }
        else
        {
            cardRenderer.sprite = sprites[(int)rpsType];
        }
        #endregion

        //if (transform.position == targetPos.position)
        //{
        //    moving = false;
        //}

        transform.position = targetPos.position;

    }

    private void OnMouseDown()
    {
       //play card
    }

    private void OnMouseOver()
    {
        //hover
    }
}
