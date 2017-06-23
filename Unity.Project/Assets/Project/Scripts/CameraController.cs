using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Talent
{
    /// <summary>
    /// Faz a camera seguir o personagem 
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        public Transform followObject;
        public Transform thisTransform;
        public Vector3 offsetCameraPos;
        public Vector3 lookAtOffset;
        public float lerpSpeed = 2;

        public void Initialize(Transform target)
        {
            followObject = target;
        }
        private void LateUpdate()
        {
            if (followObject == null)
                return;

            LookPlayer();
            FollowPlayer();
        }
        private void LookPlayer()
        {
            thisTransform.LookAt(followObject.position + lookAtOffset);
        }
        private void FollowPlayer()
        {
            thisTransform.position = Vector3.Lerp(thisTransform.position, followObject.position + offsetCameraPos, Time.deltaTime * lerpSpeed);
        }
    }
}