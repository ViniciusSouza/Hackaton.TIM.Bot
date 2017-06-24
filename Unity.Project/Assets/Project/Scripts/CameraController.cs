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

        private Transform oldTarget;
        private Vector3 oldOffset;
        private Vector3 oldLookOffset;

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
        public void FocusSomething(Transform target, Vector3 offset, Vector3 lookOffset)
        {
            oldTarget = followObject;
            oldOffset = offsetCameraPos;
            oldLookOffset = lookAtOffset;

            followObject = target;
            offsetCameraPos = offset;
            lookAtOffset = lookOffset;
        }
        public void RestoreOldFocus()
        {
            followObject = oldTarget;
            offsetCameraPos = oldOffset;
            lookAtOffset = oldLookOffset;
        }
    }
}