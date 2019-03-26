using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log($"Health: {health}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
