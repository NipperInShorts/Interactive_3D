using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBehavior : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;

    public float frames = 3200f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x - 0.12f, startPos.y + 8.76f, startPos.z - 19.67f);
    }

    public void FixPizza()
    {
        StopAllCoroutines();
        StartCoroutine(MovePizza(startPos, endPos, 1 / frames));
    }

    public IEnumerator MovePizza(Vector3 startPos, Vector3 endPos, float step)
    {
        for (float i = 0; i <= 1; i += step)
        {
            Vector3 newPos = Vector3.Lerp(startPos, endPos, i);
            transform.position = newPos;
            yield return null;
        }
    }
}
