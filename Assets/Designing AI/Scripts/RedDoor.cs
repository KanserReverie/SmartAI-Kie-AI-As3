using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KieranAI3
{
    public class RedDoor : BaseDoor
    {
        public void LiftThisDoor() => StartCoroutine(LiftDoor());
    }
}