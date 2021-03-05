using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardStunned : MonoBehaviour
{

    [Tooltip("This is the same game object that you're putting this script on, i.e. the guard.")]
    public GameObject thisSameGameObject;

    [Tooltip("This is how long the guard gets stunned for when hit by the player's projectile, measured in seconds.")]
    public float stunTime;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Guard is touching something...");
        if (other.CompareTag("LaserBeam"))
        {
            Debug.Log("Being stunned...");
            StartCoroutine("Stunned");
        }
    }

    public IEnumerator Stunned()
    {
        thisSameGameObject.GetComponent<GuardController>().enabled = false;
        thisSameGameObject.GetComponent<GuardRotatingWhenStunned>().enabled = true;
        yield return new WaitForSeconds(stunTime);
        thisSameGameObject.GetComponent<GuardRotatingWhenStunned>().enabled = false;
        thisSameGameObject.GetComponent<GuardController>().enabled = true;
        yield return null;
    }


}
