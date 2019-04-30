﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Tape_model : VRTK_InteractableObject {

    private VRTK_ControllerReference controllerReference;

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

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);


        if (StaticData.getShowScissor())
        {
            Debug.Log("start using");
            // drop the tape in hands
            base.ForceStopInteracting();
            GameObject dropped = GameObject.Find("tape_model");
            Debug.Log(dropped.transform.lossyScale);

            // tell the system that the scissor is cut
            StaticData.setIsCut(true);

            Destroy(dropped);
        }

    }

}
