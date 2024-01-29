using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float jumpPower;
    Rigidbody2D rb;
    Vector2 screenTop, screenBottom;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        screenTop = Camera.main.ViewportToWorldPoint(Vector2.one);
        screenBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;

        if(pos.y > screenTop.y)
        {
            rb.velocity = Vector2.zero;
            pos.y = screenTop.y;
        }

        if(pos.y < screenBottom.y)
        {
            Jump();
            pos.y = screenBottom.y;
        }

        transform.position = pos;
    }

    void Jump()
    {
        rb.velocity = Vector2.zero;

        rb.AddForce(new Vector2(0, jumpPower*100));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
