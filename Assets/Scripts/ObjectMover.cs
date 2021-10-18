using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float frequency = 1f;

    public Vector3 amplitudeVector = new Vector3(0f, 1f, 0f);

    private Vector3 startPosition;

    private void Update()
    {
        float sin = Mathf.Sin(Time.deltaTime * frequency * 2f * Mathf.PI);

        Vector3 offset = amplitudeVector * sin;
        transform.position = startPosition + offset;
    }

}
