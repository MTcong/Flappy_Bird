using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private GameObject obj;
    private Vector3 oldPosition;

    private float moveSpeed;
    private float moveRange;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;

        moveSpeed = 1.0f;
        moveRange = 20.4f;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        if (Vector3.Distance(oldPosition, obj.transform.position) < moveRange)
        {
            obj.transform.Translate(new Vector3(moveSpeed * (-dt), 0, 0));
        }
        else obj.transform.position = oldPosition;
    }
}
