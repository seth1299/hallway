using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardRotatingWhenStunned : MonoBehaviour
{
    // This just makes the guard continuously rotate while the script is active, but stop rotating once the script is disabled.
    void Update()
    {
        transform.Rotate (new Vector3 (0, 6f, 0));
    }
}
