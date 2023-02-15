using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallBehavior : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;

    public float frames = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x, startPos.y + 7f, startPos.z);
    }

    public void FixBall()
    {
        StopAllCoroutines();
        StartCoroutine(MoveBall(transform.position, endPos, 1 / frames));
    }

    public IEnumerator MoveBall(Vector3 startPos, Vector3 endPos, float step) {
        for (float i = 0; i <= 1; i += step) {
            Vector3 newPos = Vector3.Lerp(startPos, endPos, i);
            transform.position = newPos;
            yield return null;
        }
    }
}
