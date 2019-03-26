using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed = 10.0f;
    public int Damage = 1; 

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(Damage);
        }
        Destroy(this.gameObject);
    }
}
