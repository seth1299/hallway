using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    [Tooltip("This is the player game object.")]
    public GameObject player;

    [Tooltip("This is the same canvas that you're putting this script on.")]
    public Canvas thisSameCanvas;

    void Update()
    {
        if (player.GetComponent<PlayerShootEnemy>().GetCanShoot())
            thisSameCanvas.enabled = true;
        else
            thisSameCanvas.enabled = false;
    }
}
