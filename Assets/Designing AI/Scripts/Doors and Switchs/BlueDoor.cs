using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KieranAI3
{
    public class BlueDoor : BaseDoor
    {
        public void LiftThisDoor() => StartCoroutine(LiftDoor());
    }
}