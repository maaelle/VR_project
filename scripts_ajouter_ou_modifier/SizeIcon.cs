using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SizeIcon : MonoBehaviour
{
    PaintBrush brush;
    XRSimpleInteractable interactable;

    [Range(0, 1)] public float brushWidth;

    void Start()
    {
        brush = FindObjectOfType<PaintBrush>();

        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelect);
    }

    private void OnDestroy()
    {
        if (interactable != null)
            interactable.selectEntered.RemoveListener(OnSelect);
    }

    void OnSelect(SelectEnterEventArgs args)
    {
        UpdateBrushSize();
    }

    [ContextMenu("UpdateBrushColor")]
    public void UpdateBrushSize()
    {
        brush.brushWidth = brushWidth;
    }
}
