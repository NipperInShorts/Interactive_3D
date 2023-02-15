using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeoutBehavior : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;

    public float frames = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x, startPos.y + 5f, startPos.z - 0.43f);
    }

    public void FixTakeout()
    {
        StopAllCoroutines();
        StartCoroutine(MoveTakeout(startPos, endPos, 1 / frames));
    }

    public IEnumerator MoveTakeout(Vector3 startPos, Vector3 endPos, float step)
    {
        for (float i = 0; i <= 1; i += step)
        {
            Vector3 newPos = Vector3.Lerp(startPos, endPos, i);
            transform.position = newPos;
            yield return null;
        }
    }
}
