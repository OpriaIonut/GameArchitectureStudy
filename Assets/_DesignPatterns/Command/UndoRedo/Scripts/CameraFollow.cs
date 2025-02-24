using UnityEngine;

namespace DesignPatterns.Command.UndoRedo
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform targetTransf;
        [SerializeField] private float cameraSpeed = 3.0f;

        private Vector3 offset;

        private void Start()
        {
            offset = transform.position - targetTransf.position;
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, targetTransf.position + offset, cameraSpeed * Time.deltaTime);
        }
    }
}