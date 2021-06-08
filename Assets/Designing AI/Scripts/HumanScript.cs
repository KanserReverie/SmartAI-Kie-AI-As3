using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace KieranAI3
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class HumanScript : MonoBehaviour
    {
        private int collectedCoins;
        public int CollectedCoins => collectedCoins;
        private NavMeshAgent agent;
        private HumanWaypoint[] waypoints;
        private Animator AgentAnimator;
        [SerializeField] private float runSpeed;

        // Will give us a random waypoint in the array as a variable everytime I access it
        private HumanWaypoint RandomPoint => waypoints[Random.Range(0, waypoints.Length)];

        // Start is called before the first frame update
        void Start()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            // FindObjectsOfType gets every instance of this component in the scene
            waypoints = FindObjectsOfType<HumanWaypoint>();
            AgentAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            // Has the agent reached it's position?
            if (!agent.pathPending && agent.remainingDistance < 0.3f)
            {
                // Tell the agent to move to a random position in the scene waypoints
                agent.SetDestination(RandomPoint.Position);
            }

            // If running, play running animation.
            AgentAnimator.SetBool("Running", agent.velocity.magnitude > runSpeed);

        }

        public void CollectCoin()
        {
            collectedCoins++;
        }
    }
}
