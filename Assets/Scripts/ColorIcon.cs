using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorIcon : MonoBehaviour
{
    PaintBrush brush;
    XRSimpleInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        //Cherche mon pinceau
        brush = FindObjectOfType<PaintBrush>();

        //J'�coute l'�v�nement select
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelect);
    }

    //Facultatif � l'�chelle du projet
    private void OnDestroy()
    {
        if(interactable!=null)
            interactable.selectEntered.RemoveListener(OnSelect);
    }

    //Quand je clique
    void OnSelect(SelectEnterEventArgs args)
    {
        UpdateBrushColor();
    }

    [ContextMenu("UpdateBrushColor")]
    public void UpdateBrushColor()
    {
        //Trouver la couleur
        Color iconColor = GetComponent<Image>().color;
        //Changer la couleur du pinceau
        brush.colorBrush = iconColor;
    }
}
