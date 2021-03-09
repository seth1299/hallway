using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootEnemy : MonoBehaviour
{

    // "canShoot" tracks if the player can shoot (i.e. if they have picked up the magical stunning tablet)
    private bool canShoot = false;

    [Tooltip("The cooldown between every shot that the player can shoot, measured in seconds.")]
    public float shotCooldown;
    
    [Tooltip("The 'laser beam' game object that the player shoots out at the Guard after picking up the magical stunning tablet.")]
    public GameObject laserBeam;

    [Tooltip("This is the Pause Menu canvas. This is only needed so that this script can tell when the game is paused by accessing the pause menu's script.")]
    public Canvas PauseMenu;

    // This will just be an abbreviation for PauseMenu.GetComponent<PauseMenuController>() which can be a mouthful.
    private PauseMenuController PMC;

    void Awake()
    {
        // This just sets PMC to the Pause Menu Controller script on the Pause Menu canvas passed via the Inspector.
        PMC = PauseMenu.GetComponent<PauseMenuController>();
    }

    // This just checks if the player touches the tablet, then if so then the player can now shoot and then the tablet object is destroyed.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tablet"))
        {
            Debug.Log("Touching tablet");
            canShoot = true;
            Destroy(other.gameObject);
        }
    }

    // This just keeps checking to see if the player has collected the tablet and if so, then it checks if the player is pushing down space, then if so it shoots
    // a laster out.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot && !PMC.GetIsPaused())
        {
            StartCoroutine("Shoot");
        }
    }

    // This just shoots a shot and then makes sure that the player has to wait the amount of time specified in the Inspector under "shotCooldown" before shooting
    // again.
    private IEnumerator Shoot()
    {
        if ( !PMC.GetIsPaused())
        {
        canShoot = false;

        //Destroy(Instantiate(laserBeam, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.FromToRotation(Vector3.up, transform.forward) ), 2f);
        Destroy(Instantiate(laserBeam, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.FromToRotation(Vector3.right, transform.forward) ), 2f);

        yield return new WaitForSeconds(shotCooldown);

        canShoot = true;
        }
    }

    // This just returns the "canShoot" variable.
    public bool GetCanShoot()
    {
        return canShoot;
    }


}
