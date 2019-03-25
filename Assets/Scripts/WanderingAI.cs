using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 1.0f;

    private bool alive;

    public bool Alive { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
    }

    //public void SetAlive(bool alive)
    //{
    //    this.alive = alive;
    //} 

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            var ray = new Ray(transform.position, transform.forward);

            if (Physics.SphereCast(ray, 0.75f, out var hit))
            {
                if (hit.distance < obstacleRange)
                {
                    var angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }
}
