using UnityEngine;

namespace Platformer.Gameplay
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private Transform cameraMinimum;
        private float yOffset;
        private Camera camera;

        private void Awake()
        {
            camera = GetComponent<Camera>();
            Vector3 bottomLeftCorner = camera.ViewportToWorldPoint(new Vector2(0, 0));
            yOffset = transform.position.y - bottomLeftCorner.y;
        }

        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
            if (transform.position.y - yOffset < cameraMinimum.position.y)
            {
                transform.position = new Vector3(transform.position.x, cameraMinimum.position.y + yOffset, transform.position.z);
            } 
        }
    }
}