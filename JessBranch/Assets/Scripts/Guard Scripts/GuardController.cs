using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardController : MonoBehaviour
{

    [Tooltip("This is what the Guard walks on, which Unity calls an 'agent'.")]
    public NavMeshAgent agent;

    [Tooltip("This is how far the Guard can see the player from.")]
    public float view_distance;

    // These are all booleans for if the guard sees an object/the player, if the guard can rotate (i.e. if he is currently moving), and if the guard is
    // currently rotating, respectively.
    private bool seesObject = false, seesPlayer = false, canRotate = true, isRotating = false;

    // "randomValue" is an integer that will later be set to a random value, and "index" is just a simple counting variable for any loops in this script.
    private int randomValue, index;

    // "CCS" is just an abbreviation for "hit.collider.GetComponent<Character Controller Script>()", which I am sure is a lot easier to remember than all that.
    private CharacterController CCS = null;

    [Tooltip("This is the Player game object.")]
    public GameObject player;

    // isPaused just checks if the game is paused.
    private bool isPaused = false;


    // This just makes sure that the Guard vigilantly turns around at the start of the game.
    void Start()
    {
        StartCoroutine("RotateVigilantly");
    }

    // This uses raycasting in order to "see" the player. Basically, think of it like a laser pointer. The guard is constantly pointing a laser forward and if
    // that "laser" touches something, then "seesObject" is set to true and if it's the player then "seesPlayer" is also set to true. The guard can also only see
    // a number of feet away equal to "view_distance", which is set in the Inspector.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            isPaused = !isPaused;

        Ray ray = new Ray(transform.position, transform.right);
        RaycastHit hit;
        Debug.DrawRay (transform.position,transform.right*view_distance,Color.green,2f,false);

        seesObject = Physics.Raycast(ray, out hit, view_distance);

        if (hit.collider != null)
        {
            Debug.Log("Guard sees "+ hit.collider.gameObject);
            if (seesObject)
            {
                CCS = hit.collider.GetComponent<CharacterController>();
                    if (CCS != null)
                    {
                        seesPlayer = true;
                    }
                    else
                    {
                        seesPlayer = false;
                    }
            }
        }
        CCS = null;
                //seesPlayer = hit.collider.gameObject.CompareTag("Player");
            
        //CompareTag(Physics.Raycast(ray, out hit, view_distance), "Player");

        if ( seesPlayer )
        {
            StartCoroutine("CanRotateFalse");
            Debug.Log("Moving towards player...");
            agent.SetDestination(hit.point);
        }

        seesPlayer = false;

        if ( !isRotating )  
            StartCoroutine("RotateVigilantly");

    }

    // This makes sure that the Guard is randomly turning around to try and spot the player at correct times.
    public IEnumerator RotateVigilantly()
    {
        isRotating = true;
        for ( index = 0; index < 40 && canRotate && !isPaused; index++ )
        {
            transform.Rotate (new Vector3 (0, 0.65f, 0));
            yield return null;
        }
        isRotating = false;
        /*
        if ( canRotate )
        {
        isRotating = true;
        yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
        //yield return null;

        randomValue = (int)Mathf.Round((int)Random.Range((int)-100, (int)100));

        if (randomValue == 0)
            randomValue = 1;
        else if (randomValue < 0)
            randomValue = -1;
        else if (randomValue > 0)
            randomValue = 1;

        for ( index = 0; index < 40; index++ )
        {
            transform.Rotate (new Vector3 (0, randomValue * 1.25f, 0));
            yield return null;
        }
        isRotating = false;
        }
        */
    }

    // This just prevents the guard from rotating for 3.5 seconds to make sure that it isn't just constantly rotating.
    public IEnumerator CanRotateFalse()
    {
        canRotate = false;
        yield return new WaitForSeconds(3.5f);
        canRotate = true;
    }
    
}
