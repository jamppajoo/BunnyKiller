﻿namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class InteractableWithVibration : VRTK_InteractableObject
    {

        private float impactMagnifier = 120f;
        private float collisionForce = 0f;
        private float maxCollisionForce = 4000f;
        private VRTK_ControllerReference controllerReference;

        public float CollisionForce()
        {
            return collisionForce;
        }

        public override void Grabbed(VRTK_InteractGrab grabbingObject)
        {
            base.Grabbed(grabbingObject);
            controllerReference = VRTK_ControllerReference.GetControllerReference(grabbingObject.controllerEvents.gameObject);
        }

        public override void Ungrabbed(VRTK_InteractGrab previousGrabbingObject)
        {
            base.Ungrabbed(previousGrabbingObject);
            controllerReference = null;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            controllerReference = null;
            interactableRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (VRTK_ControllerReference.IsValid(controllerReference) && IsGrabbed())
            {
                collisionForce = VRTK_DeviceFinder.GetControllerVelocity(controllerReference).magnitude * impactMagnifier;
                var hapticStrength = collisionForce * 5 / maxCollisionForce;
                VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, hapticStrength, 0.5f, 0.01f);
            }
            else
            {
                collisionForce = collision.relativeVelocity.magnitude * impactMagnifier * 5;
            }
        }
    }
}