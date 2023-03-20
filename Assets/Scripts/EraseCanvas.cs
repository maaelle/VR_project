using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseCanvas : MonoBehaviour
{
    public RenderTexture paintableAreaRT;
    public int textureResolution = 256;


    public void Start()
    {
        ClearOutRenderTexture(paintableAreaRT);
    }

    public void Erase(Vector2 uvEraser, float EraserWidth, Texture2D EraserTex, Color colorEraser)
    {
        RenderTexture.active = paintableAreaRT;
        GL.PushMatrix();
        GL.LoadPixelMatrix(0, textureResolution, textureResolution, 0);

        uvEraser.x *= textureResolution;
        uvEraser.y = textureResolution * (1 - uvEraser.y);

        EraserWidth *= textureResolution;

        //Paint on RT
        Rect EraseRect = new Rect(uvEraser.x - EraserWidth * 0.5f, uvEraser.y - EraserWidth * 0.5f, EraserWidth, EraserWidth);
        Graphics.DrawTexture(EraseRect, EraserTex, new Rect(0, 0, 1, 1), 0, 0, 0, 0, colorEraser, null);

        GL.PopMatrix();
        // turn off RT
        RenderTexture.active = null;
    }

    public void ClearOutRenderTexture(RenderTexture renderTexture)
    {
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, new Color(0, 0, 0, 0));
        RenderTexture.active = null;
    }
}
