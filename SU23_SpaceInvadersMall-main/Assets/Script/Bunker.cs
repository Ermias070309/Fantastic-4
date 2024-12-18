using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bunker : MonoBehaviour
{
    int nrOfHits = 0;
    SpriteRenderer spRend;
    private void Awake()
    {
        spRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
       
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile") || other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            

            //�ndrar f�rgen beroende p� antal tr�ffar.
            nrOfHits++;
            Color oldColor = spRend.color;

            
            

            Color newColor = new Color(oldColor.r +(nrOfHits*0.025f), oldColor.g + (nrOfHits * 0.025f), oldColor.b + (nrOfHits * 0.025f));
            
            spRend.color = newColor;
            
            if (nrOfHits == 8)
            {
                gameObject.SetActive(false);
            }
            
        }
    }

    public void ResetBunker()
    {
        gameObject.SetActive(true);
    }
}
