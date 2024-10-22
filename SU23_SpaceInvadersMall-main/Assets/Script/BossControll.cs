using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControll : MonoBehaviour
{

    [SerializeField] Missile missilePrefab; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(FireMissile), 1f, 2.6f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FireMissile()
    {
        for (int i = 0; i<30; i++)
        {
            float y = transform.position.y;
            float x = transform.position.x - 15 + i;
            Instantiate(missilePrefab, new Vector3(x, y), Quaternion.identity); 

        }
    }
}
