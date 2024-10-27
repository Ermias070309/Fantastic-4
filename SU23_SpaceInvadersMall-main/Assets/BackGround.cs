using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update 
    SpriteRenderer BG; 
    public Sprite Back1;
    public Sprite Back2;
    public Sprite Back3;
    public Sprite Back4;
    Player Hp; 
    void Start()
    {
        BG = GetComponent<SpriteRenderer>(); 
        Hp = FindAnyObjectByType<Player>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp.currentHealth == 4)
        {
            BG.sprite = Back1; 
        }
        if (Hp.currentHealth == 3)
        {
            BG.sprite = Back2;
        }
        if (Hp.currentHealth == 2)
        {
            BG.sprite = Back3;
        }
        if (Hp.currentHealth == 1)
        {
            BG.sprite = Back4;
        }
    }
}
