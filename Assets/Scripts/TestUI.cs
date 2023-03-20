using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TestUI : MonoBehaviour
{
    XRSimpleInteractable interactable;
    int count = 0;

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
        count++;
        Debug.Log("Bouton pinceau cliqué " + count);
        PaintBrush paintBrush =  GameObject.FindWithTag("brush").GetComponent<PaintBrush>();
        paintBrush.colorBrush = Color.green;
    }
}
