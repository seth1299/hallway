using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardController : MonoBehaviour
{

    public NavMeshAgent agent;

    public float view_distance;

    private bool seesObject = false, seesPlayer = false, canRotate = true, isRotating = false;

    private int randomValue, index;

    private PlayerMovement PMS = null;

    void Start()
    {
        StartCoroutine("RandomlyTurnAround");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        seesObject = Physics.Raycast(ray, out hit, view_distance);

        if (hit.collider != null)
        {
            Debug.Log("Ray hit something...");
            if (seesObject)
            {
                PMS = hit.collider.GetComponent<PlayerMovement>();
                    if (PMS != null)
                    {
                        seesPlayer = true;
                    }
                    else
                    {
                        seesPlayer = false;
                    }
            }
        }
        PMS = null;
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
            StartCoroutine("RandomlyTurnAround");

    }

    public IEnumerator RandomlyTurnAround()
    {
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
    }

    public IEnumerator CanRotateFalse()
    {
        canRotate = false;
        yield return new WaitForSeconds(3.5f);
        canRotate = true;
    }
    
}
