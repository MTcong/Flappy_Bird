using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    private GameObject obj;

    private float oldPosition;
    private float moveSpeed;
    private float minY;
    private float maxY;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;

        oldPosition = 16.3f;
        moveSpeed = 1.0f;
        minY = -3.7f;
        maxY = 2.2f;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        transform.Translate(new Vector3(moveSpeed * (-dt), 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Respawn"))
        {
            obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);
        }
    }
}
