using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private GameObject obj;
    GameObject gameController;
    private Animator anim;

    private float power;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        anim = obj.GetComponent<Animator>();
        anim.SetFloat("flyPower", 0);
        anim.SetBool("isDead", false);
        power = 250;


        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, power));
        }
        anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameController.GetComponent<GameController>().EndGame();
        anim.SetFloat("flyPower", 0);
        anim.SetBool("isDead", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<GameController>().GetScore();
    }
}
