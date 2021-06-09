using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace KieranAI3
{
    [RequireComponent(typeof(NavMeshAgent))]
    public partial class HumanScript : MonoBehaviour
    {
        [SerializeField] private GameObject particles;
        private States currentState;
        public States CurrentState => currentState;
        // All the main Variables Just fot the player to see.
        private int collectedCoins;
        public int CollectedCoins => collectedCoins;
        private Vector3 nextDestination;
        private float distanceToDestination;
        [SerializeField] private float runSpeed;

        // All the text boxes to be seen in UI.
        [SerializeField] private Text LocationPosition;
        [SerializeField] private Text InitialDistance;
        [SerializeField] private Text coinsCollected;
        [SerializeField] private Text playerState;


        // This will update all the goals and show in inspector.

        // Update is called once per frame
        void Update()
        {
            // Basically Go towards the nearest point.
            if (states.TryGetValue(currentState, out StateDelegate state))
            {
                state.Invoke();
            }
            else
            {
                Debug.LogError($"No state fuction set for state {currentState}.");
            }
        }

        public void CollectCoin()
        {
            collectedCoins++;
            UpdateUI();
            FindNextState();
        }

        public void OpenDoor()
        {
            UpdateUI();
            FindNextState();
        }

        public void FinishGame()
        {
            particles.gameObject.SetActive(true);
            UpdateState(States.FinishedGame);
            AgentAnimator.SetBool("FinishedGame",true);
        }

        // Update All the UI.
        private void UpdateUI()
        {
            LocationPosition.text = ("Location Position = " + nextDestination);
            InitialDistance.text = ("Initial Distance = " + distanceToDestination);
            coinsCollected.text = ("Coins Collected = " + collectedCoins);
            playerState.text = (currentState.ToString());
        }
    }
}
