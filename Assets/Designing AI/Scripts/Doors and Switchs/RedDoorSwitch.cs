using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KieranAI3
{
    public class RedDoorSwitch : DoorSwitch
    {
        private void Start()
        {
            accoceatedDoor = FindObjectOfType<RedDoor>();
        }
    }
}