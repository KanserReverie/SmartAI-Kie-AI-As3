using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace KieranAI3
{
    // All AI States.
    public enum States
    {
        CoinCollection,
        FindGateSwitch,
        RuntoFinish
    }

    // The delegate that dictates what the fuctions for each state will look like.
    public delegate void StateDelegate();

    // Basically All The State Machine
    public partial class HumanScript
    {
        // Dictionary of all the states.
        private Dictionary<States, StateDelegate> states = new Dictionary<States, StateDelegate>();

        [SerializeField] private Vector3[] CoinWaypoints;
        [SerializeField] private Vector3[] DoorSwitchWaypoints;
        [SerializeField] private Vector3 FinishDestination;

        private bool haveAllCoinsBeenCollected;

        private NavMeshAgent agent;
        private Animator AgentAnimator;


        // Start is called before the first frame update
        void Start()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            AgentAnimator = GetComponent<Animator>();

            states.Add(States.CoinCollection, GotoClosestCoin);
            //states.Add(States.FindGateSwitch, GotoClosestSwitch);
            //states.Add(States.RuntoFinish, GotoFinishPoint);

            // Starts the state machine.
            FindNextState();
        }

        // Finds the next state.
        private void FindNextState()
        {
            StartCoroutine(FindingNextState());
        }

        // Waits 2 Seconds then Finds the next state, to make sure the path is clear
        public IEnumerator FindingNextState()
        {
            yield return new WaitForSeconds(2);

            // Refresh all the goal points
            UpdateGoals();

            // In Update Goals it will Update if All coins have been collected.
            if (!haveAllCoinsBeenCollected)
            {
                if (CanIGetToAnyPoint(CoinWaypoints))
                {
                    UpdateState(States.CoinCollection);
                }
            }
        }

        // Updates with the new state.
        public void UpdateState(States _NextState)
        {
            // Updates the current state with the new state.
            currentState = _NextState;

            // Go to closest point.
            nextDestination = FindClosestGoal(CoinWaypoints);
            agent.SetDestination(nextDestination);

            // Finally Update all the UI.
            UpdateUI();
        }

        private void GotoClosestCoin()
        {
            // If running, play running animation.
            AgentAnimator.SetBool("Running", agent.velocity.magnitude > runSpeed);
        }

        //private void GotoClosestSwitch() => controlled.Rotate(Vector3.up, speed * 0.5f);
        //private void GotoFinishPoint() => controlled.localScale += Vector3.one * Time.deltaTime * speed;
    }
}