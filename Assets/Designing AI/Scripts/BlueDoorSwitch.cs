using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KieranAI3
{
    public class BlueDoorSwitch : DoorSwitch
    {
        private BlueDoor accoceatedDoor;
        // Start is called before the first frame update
        private void Start()
        {
            accoceatedDoor = FindObjectOfType<BlueDoor>();
        }

        private void OnCollisionEnter(Collision _collision)
        {
            if (_collision.gameObject.tag == "Player")
            {
                accoceatedDoor.LiftThisDoor();
                Destroy(transform.parent.gameObject);
            }
        }
    }
}