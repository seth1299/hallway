    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LaserBeam : MonoBehaviour
    {
        // This is the target position for where the laser beam will be shot.
        private Vector3 targetPosition;

        // This makes the bullet start the "Pew" coroutine at the beginning of when it's created.
        void Awake()
        {
            //Create a ray that goes from the Camera through the screen to Input.mousePosition in world space
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            targetPosition = new Vector3();

            //Raycast into the scene
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //If something is hit, then take the point hit and set that as the target position
                targetPosition = hitInfo.point;
            }
            else
            {
                //If for some reason the ray hit nothing, pick a point along the ray as the target position
                targetPosition = ray.GetPoint(100f);
            }

            StartCoroutine("Pew");
        }

        // This just makes the bullet fly forward for a long time.
        private IEnumerator Pew()
        {
            for(int i = 0, iMax = 100000; i < iMax; iMax--)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, 20f * Time.deltaTime);

                yield return null;                
            }
        }

        // This checks if the bullet is colliding with anything, and if so then to destroy itself after 0.02 seconds so as to give the rest of the scripts involved time
        // to finish working.
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Colliding with something...");
            if (other != null && !other.CompareTag("Player"))
            {
                Debug.Log("Destroying itself...");
                Destroy(gameObject, 0.02f);
            }
            else if (other.CompareTag("Player"))
            {
                Debug.Log("Bullet is touching player");
            }
        }
    }
