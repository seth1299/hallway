using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStunned : MonoBehaviour
{

    // "index" is just a counter for any loops in this script.
    private int index = 0;

    // This is the Rigidbody component for the player.
    private Rigidbody rb;

    [Tooltip("This is the sound effect for when the player is hit/damaged.")]
    public AudioSource hitSFX;

    [Tooltip("This is the sound effect for when the player collects the tablet powerup.")]
    public AudioSource powerupSFX;

    // This is to check when the game is paused or not. Returning it from the PauseMenuController script is bugged for some reason.
    private bool isPaused = false;

    [Tooltip("This is how long the player will be stunned for when getting hit, measured in seconds.")]
    public float stunTime;

    [Tooltip("This is a TextMeshProUGUI object that displays that the player is stunned.")]
    public TextMeshProUGUI stunText;

    [Tooltip("This is the Guard.")]
    public GameObject guard;

    // Set "rb" to the Rigidbody component of the player.
    void Start()
    {
        stunText.text = "";
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            isPaused = !isPaused;
    }

    // Basically, this just chceks to see if the player walks into a hazard, and if so then it "stuns" the player by running the Stunned() IEnumerator.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard") && guard.GetComponent<GuardController>().enabled == true)
        {
            Debug.Log("Touching hazard");
            StartCoroutine("Stunned");
        }
        else if (other.CompareTag("Staff"))
        {
            Debug.Log("Winning");
            SceneManager.LoadScene("Victory");
        }
        else if (other.CompareTag("Tablet"))
            powerupSFX.Play();
    }

    // This just plays the "hit" sound effect and then pushes the player backwards and disables movement for the duration of being pushed backwards.
    private IEnumerator Stunned()
    {
        stunText.text = "You are stunned and cannot move!";
        hitSFX.Play();
        rb.AddForce(transform.forward * -100000f * Time.deltaTime);
        (gameObject.GetComponent<PlayerMovement>()).enabled = false;
        yield return new WaitForSeconds(stunTime);
        (gameObject.GetComponent<PlayerMovement>()).enabled = true;
        stunText.text = "";
    }
}
