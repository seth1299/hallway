using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    [Tooltip("This is how long the door waits before it starts closing, measured in seconds.")]
    public float delay;

    // This checks if the door has "waited" the amount of time specified in "delay" before setting itself to true, allowing the line of code in Update() to keep triggering
    private bool delayOver = false;

    // isPaused just checks to see if the game is paused.
    private bool isPaused = false;

    // isOpen just checks to see if the door is open.
    private bool isOpen = true;

    // anim is just the animtor component for this game object.
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        isPaused = false;
        delayOver = false;
        StartCoroutine("Close");
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(delay);
        isOpen = false;
        delayOver = true;
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.P))
            isPaused = !isPaused;

        anim.SetBool("isOpen", isOpen);
        /*
        if (delayOver && transform.position.y >= 1.7f && !isPaused)
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.005f, transform.position.z);
            */
    }
}
