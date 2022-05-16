using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _IncreaseSpeed;
    [SerializeField] float _MaxVelocity;

    new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float speed = _IncreaseSpeed * Time.deltaTime;

        Vector2 velocity = rigidbody.velocity;

        bool moveX = false;
        bool moveY = false;

        if (Input.GetKey(KeyCode.A))
        {
            if (velocity.x > -_MaxVelocity)
                velocity.x -= speed;

            moveX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (velocity.x < _MaxVelocity)
                velocity.x += speed;

            moveX = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (velocity.y > -_MaxVelocity)
                velocity.y -= speed;

            moveY = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (velocity.y < _MaxVelocity)
                velocity.y += speed;

            moveY = true;
        }

        if (moveX == false)
            velocity.x = velocity.x > 0.0f ? velocity.x -= speed : velocity.x += speed;

        if (moveY == false)
            velocity.y = velocity.y > 0.0f ? velocity.y -= speed : velocity.y += speed;

        rigidbody.velocity = velocity;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.localPosition.y, mousePos.x - transform.localPosition.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
