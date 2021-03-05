using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStunned : MonoBehaviour
{
    // This is just an abbreviation for "gameObject.GetComponent<PlayerMovement>()". It can be removed and replaced with that same statement and nothing would change,
    // but it's just easier to read this way.
    private PlayerMovement PMS = null;

    // "index" is just a counter for any loops in this script.
    private int index = 0;

    [Tooltip("This is the sound effect for when the player is hit/damaged.")]
    public AudioSource hitSFX;

    // "PMS" is set to this game object's "PlayerMovement" script.
    void Start()
    {
        PMS = gameObject.GetComponent<PlayerMovement>();
    }

    // Basically, this just chceks to see if the player walks into a hazard, and if so then it "stuns" the player by running the Stunned() IEnumerator.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            Debug.Log("Touching hazard");
            StartCoroutine("Stunned");
        }
    }

    // This just plays the "hit" sound effect and then pushes the player backwards and disables movement for the duration of being pushed backwards.
    private IEnumerator Stunned()
    {
        hitSFX.Play();
        (gameObject.GetComponent<PlayerMovement>()).enabled = false;
        for (index = 0; index < 100; index++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
            yield return null;
        }
        (gameObject.GetComponent<PlayerMovement>()).enabled = true;
    }
}
