using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

    //Once the shot hits the boundary wall, it checks if the game object that hit it is a shot and destroys it as it leaves the trigger if it is
    private void OnTriggerExit(Collider other)
    {
        Destroy(GameObject.FindGameObjectWithTag("Shot"));
    }
}
