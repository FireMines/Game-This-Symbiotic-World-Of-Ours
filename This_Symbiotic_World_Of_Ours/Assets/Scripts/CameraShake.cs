using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {

            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        print("papa?? -><-");
        transform.localPosition = originalPos;
    }

    public void StartShake()
    {
        StartCoroutine(Shake(1f, 500f));
    }
}
