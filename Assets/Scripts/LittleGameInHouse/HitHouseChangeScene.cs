using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;


public class HitHouseChangeScene : MonoBehaviour
{
    XRSimpleInteractable interactable;
    public string sceneToLoad = "LittleGameInHouse";


    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelect);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSelect(SelectEnterEventArgs args)
    {
        UnityEngine.Debug.Log("Hit change scene");
        SceneManager.LoadScene(sceneToLoad);
    }

}
