using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace KieranAI3
{
    public class FinishDoor : BaseDoor
    {
        private HumanScript myPlayer;
        // Start is called before the first frame update
        void Start()
        {
            myPlayer = FindObjectOfType<HumanScript>();
            StartCoroutine(OpenFinalDoor());
        }

        IEnumerator OpenFinalDoor()
        {
            if(myPlayer.CollectedCoins < 3)
                yield return new WaitForSeconds(1);
            StartCoroutine(LiftDoor());
        }
    }
}