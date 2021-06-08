using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace KieranAI3
{
    // This is the basic door it will have the lifting script.
    [RequireComponent(typeof(NavMeshObstacle))]
    [RequireComponent(typeof(MeshRenderer))]
    public class BaseDoor : MonoBehaviour
    {
        // These Will basically be how the door moves up.
        private float moveSpeed, movingTimer;
        private Vector3 _moveDir;
        public CharacterController _charC;

        void Start()
        {
            _moveDir = Vector3.zero;
            movingTimer = 4;
            moveSpeed = 12;
        }

        private void Update()
        {
            _charC.Move(_moveDir * Time.deltaTime);
        }

        // Do you even lift.
        protected IEnumerator LiftDoor()
        {
            float x = 4;
            while (x > 0)
            {
                _moveDir = transform.TransformDirection(0, 1, 0) * moveSpeed;
                x -= Time.deltaTime;
                yield return null;
            }
        }
    }
}