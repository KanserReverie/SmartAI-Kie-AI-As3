using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KieranAI3
{
    public class RedDoorSwitch : DoorSwitch
    {
        private RedDoor accoceatedDoor;
        private void Start()
        {
            accoceatedDoor = FindObjectOfType<RedDoor>();
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