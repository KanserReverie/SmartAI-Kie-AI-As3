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
        [SerializeField] private States currentState;

        // All the main Variables Just fot the player to see.
        [SerializeField] private int collectedCoins;
        public int CollectedCoins => collectedCoins;
        [SerializeField] private Vector3 nextDestination;
        [SerializeField] private float distanceToDestination;
        [SerializeField] private float runSpeed;
        [SerializeField] private NavMeshSurface myNavMeshSurface;
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
            FindNextState();
            UpdateUI();
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
