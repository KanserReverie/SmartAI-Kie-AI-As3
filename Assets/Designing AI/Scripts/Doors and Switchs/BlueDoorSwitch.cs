using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KieranAI3
{
    public class BlueDoorSwitch : DoorSwitch
    {
        private void Start()
        {
            accoceatedDoor = FindObjectOfType<BlueDoor>();
        }
    }
}