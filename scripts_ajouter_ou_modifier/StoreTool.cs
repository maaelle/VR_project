using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


using UnityEngine.XR.Interaction.Toolkit;

public class StoreTool : XRGrabInteractable
{
    XRSimpleInteractable interactable;

    private Vector3 originalPosition;
    private Rigidbody rigidBody;

    private void Start()
    {
        originalPosition = transform.position;
        rigidBody = GetComponent<Rigidbody>();
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        UnityEngine.Debug.Log("rangement");

        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        transform.position = originalPosition;

    }

}
