using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speedX = 20.0f;
    public float speedY = 20.0f;
    public float gravity = 9.8f;
    public float disperseX = 20;
    public float disperseY = 30;
    private float borderX = 4.5f;
    private float borderY = 4.5f;
    private float time = 5.0f;
    private bool onTime= false;

    private void Start() 
    {
        onTime = true;
    }
    void FixedUpdate()
    {
        if(onTime)
        {
            if(time > 0)
            {
                time -= Time.deltaTime;
                speedY += gravity*Time.deltaTime;
                transform.Translate(Vector2.down * Time.deltaTime * speedY);
                transform.Translate(Vector2.right *Time.deltaTime *speedX);
            }
            else
            {
                time = 0;
                onTime = false;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Bottom" || other.tag == "Top" )
        {
            speedY = -(speedY - (speedY*disperseY)/100);
            Debug.Log("collisionVertical");
        }

        if (other.tag == "Right" || other.tag == "Left")
        {
            speedX = -(speedX - (speedX*disperseX)/100);
            Debug.Log("collisionHorizontal");
        }

        if (other.tag == "Obstacle" || other.tag == "Ball")
        {
            speedY = -(speedY - (speedY*disperseY)/100);
            speedX = -(speedX - (speedX*disperseX)/100);
            Debug.Log("collisionObstacle");
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.tag == "Bottom")
        {
        transform.position = new Vector2(transform.position.x, -borderY);
        speedY = -(speedY - (speedY*disperseY)/100);
        if (speedY == 0.0f)
        {
            gravity= 0.0f;
        }
        }

        if (other.tag == "Top")
        {
        transform.position = new Vector2(transform.position.x, borderY);
        speedY = -(speedY - (speedY*disperseY)/100);
        if (speedY == 0.0f)
        {
            gravity= 0.0f;
        }
        }

        if (other.tag == "Right")
        {
        transform.position = new Vector2(borderX, transform.position.y);
        speedX = -(speedX - (speedX*disperseX)/100);
        }

        if (other.tag == "Left")
        {
        transform.position = new Vector2(-borderX, transform.position.y);
        speedX = -(speedX - (speedX*disperseX)/100);
        }
    }
}
