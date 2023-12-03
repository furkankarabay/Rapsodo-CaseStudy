using UnityEngine;

namespace Rapsodo.MazeGame
{ 
    public class Billboard : MonoBehaviour
    {
        [SerializeField] private Transform playerCamera;

        private void LateUpdate()
        {
            transform.LookAt(transform.position + playerCamera.forward);
        }
    }
}
