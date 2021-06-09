using UnityEngine;

namespace KieranAI3
{
    public class HumanWaypoint : MonoBehaviour
    {
        public HumanScript myHuman;
        // Lambda - Inline functions - Functions without actual definitions 
        // like when we use private void - Just points to something // LAMBDAS ROCK
        // In this case points to transform.position
        public Vector3 Position => transform.position;
    }
}