using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    //[SerializeField] private float duration;
    //[SerializeField] private float magnitud;

    void Start()
    {
        //Lamar funcion
        //Shake();
        //Llamar corrutina
        //StartCorrutine(Shake());
    }


    public IEnumerator  Shake(float duration, float magnitud)
    {
        //yield return new WaitForSeconds(1f);

        Vector3 originalPos = transform.position;
        float elapsed = 0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitud; 
            float y = Random.Range(-1f, 1f) * magnitud;

            transform.position = new Vector3 (x + originalPos.x, y + originalPos.y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }

        /*for(float i = elapsed; i < duration; i += Time.deltaTime)
        {
            float x = Random.Range(-1f, 1f) * magnitud; 
            float y = Random.Range(-1f, 1f) * magnitud;

            transform.position = new Vector3 (x + originalPos.x, y + originalPos.y, transform.position.z);
            yield return 0;
        }

        GameObject[] vidas;

        foreach(GameObject vida in vidas)
        {
            vida.SetActive(false);

        }

        do
        {
            float x = Random.Range(-1f, 1f) * magnitud; 
            float y = Random.Range(-1f, 1f) * magnitud;

            transform.position = new Vector3 (x + originalPos.x, y + originalPos.y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;

        }while(elapsed < duration) */  

    }
}
