using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControll : MonoBehaviour
{

    Missile missilePrefab; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FireMissile()
    {
        for (int i = 0; i<10; i++)
        {
            float y = transform.position.y;
            float x = transform.position.x - 5 + i;
            Instantiate(missilePrefab, new Vector3(x, y), Quaternion.identity); 

        }
    }
}
