using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScreenShake : MonoBehaviour
{
    public void startshake()
    {
        StartCoroutine(Shake(0.2f, 0.8f));
    }

    public IEnumerator Shake(float shakeTime, float amplitude)
    {
        
        Vector3 originalPosition = transform.position;

        float elapsedTime = 0.0f;

        while (elapsedTime < shakeTime)
        {
            print("shake shake");
            Vector2 offset = Random.insideUnitCircle * amplitude;
            

            transform.position = new Vector3(offset.x, offset.y, originalPosition.z);
            elapsedTime += Time.deltaTime;

            yield return new WaitForSeconds(Time.deltaTime);
        }
        
        transform.position = originalPosition;

  
    }
    
    
}

