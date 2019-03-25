using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    public void ReactToHit()
    {
        var behaviour = GetComponent<WanderingAI>();
        if (behaviour != null)
            //   behaviour.SetAlive(false);
            behaviour.Alive = false;
            StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }
}
