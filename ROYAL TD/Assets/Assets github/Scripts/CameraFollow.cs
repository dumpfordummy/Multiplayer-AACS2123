using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    internal static Transform target;
    public float lerpSpeed = 1.0f;

    private GameObject player;
    private Vector3 offset;

    private Vector3 targetPos;
    float xWidthM = 55f;
    float yHeightM = 30f;
    



    private void Start()
    {
        if (target == null) return;

        offset = transform.position - target.position;

    }

    private void Update()
    {
        if ((player = GameObject.FindGameObjectWithTag("Player")) == null)
            return;
        Camera cam = Camera.main;
        float yHeightC = cam.orthographicSize;
        float xWidthC = yHeightC * cam.aspect;

        target = player.GetComponent<Transform>();

        float xClamp = Mathf.Clamp(target.position.x, -(xWidthM - xWidthC), xWidthM - xWidthC);
        float yClamp = Mathf.Clamp(target.position.y, -(yHeightM - yHeightC), yHeightM - yHeightC);
        transform.position = new Vector3(xClamp, yClamp, transform.position.z);
    }
}

