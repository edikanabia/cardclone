using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] bool isFaceUp = false;
    public enum CardType
    {
        Rock,
        Paper,
        Scissors
    }

    public CardType rpsType;
    SpriteRenderer cardRenderer;
    public List<Sprite> sprites;
    

    // Start is called before the first frame update
    void Start()
    {
        cardRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //displays card face
        if (isFaceUp)
        {
            cardRenderer.sprite = sprites[(int)rpsType];
        }
        else
        {
            cardRenderer.sprite = sprites[3];
        }
    }

    private void OnMouseDown()
    {
        
    }
}
