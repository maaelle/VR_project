using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;
using static System.Net.Mime.MediaTypeNames;

public class ImageComparison : MonoBehaviour
{
    public Material image_comparaison; 
    public RenderTexture material_toile;
    public GameObject boxScript;

    XRSimpleInteractable interactable;


    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelect);
    }

    // ----------------------------------- Touch Shield -----------------------------------

    void OnSelect(SelectEnterEventArgs args)
    {
        Texture2D texture_toile;
        Texture2D texture_comparaison;

        texture_toile = ConvertRenderTexturelToTexture(material_toile);
        texture_comparaison = ConvertMaterialToTexture(image_comparaison, texture_toile);

        float diff = CompareTextures(texture_comparaison, texture_toile); // + score proche de 0 mieux c'est
        //float max_score = KnowScoreMax(texture_comparaison);

        float percent = calculatePercentage(diff);

        UnityEngine.Debug.Log("Score : " + percent + " %");

        TextMesh boxText = boxScript.GetComponent<TextMesh>();
        boxText.text = "Score : " + percent + " %";

    }


    // ----------------------------------- Score calcul -----------------------------------

    float CompareTextures(Texture2D texture1, Texture2D texture2)
    {
        if (texture1.width != texture2.width || texture1.height != texture2.height)
        {
            UnityEngine.Debug.LogError("Les textures doivent avoir la même taille !");
            return -1f;
        }

        Unity.Collections.NativeArray<Color32> tex1Pixels = texture1.GetRawTextureData<Color32>();
        Unity.Collections.NativeArray<Color32> tex2Pixels = texture2.GetRawTextureData<Color32>();
        int numPixels = tex1Pixels.Length;

        float totalDiff = 0f;
        for (int i = 0; i < numPixels; i++)
        {
            totalDiff += Mathf.Abs(tex1Pixels[i].r - tex2Pixels[i].r) +
                         Mathf.Abs(tex1Pixels[i].g - tex2Pixels[i].g) +
                         Mathf.Abs(tex1Pixels[i].b - tex2Pixels[i].b) +
                         Mathf.Abs(tex1Pixels[i].a - tex2Pixels[i].a);
        }

        float avgDiff = totalDiff / (numPixels * 4);
        return avgDiff;
    }

    float calculatePercentage(float max_score)
    {
        float percent;

        if (max_score >= 200)
        {
            percent = 0;
        }
        else
        {
            percent = 100 - 100 * max_score / 200;
            percent = (float)Math.Round(percent, 2);
        }

        return percent;
    }

    float KnowScoreMax(Texture2D myTexture)
    {
        int totalPixels = myTexture.width * myTexture.height;
        int maxDiffPerComponent = 255; // la différence max possible entre 2 composantes de couleur est de 255

        float maxPossibleScore = (float)totalPixels * 4 * maxDiffPerComponent / 4; // 4 = (rouge, vert, bleu et alpha) par pixel

        return maxPossibleScore;
    }


    // ----------------------------------- Convertion -----------------------------------


    private Texture2D ConvertRenderTexturelToTexture(RenderTexture sourceRenderTexture)
    {
        // Créer Texture2D
        Texture2D targetTexture = new Texture2D(sourceRenderTexture.width, sourceRenderTexture.height, TextureFormat.ARGB32, false);
        RenderTexture.active = sourceRenderTexture;

        // Lire les pixels du RenderTexture et les écrire dans la Texture2D
        targetTexture.ReadPixels(new Rect(0, 0, sourceRenderTexture.width, sourceRenderTexture.height), 0, 0);
        targetTexture.Apply();

        RenderTexture.active = null;

        return targetTexture;
    }
    private Texture2D ConvertMaterialToTexture(Material material, Texture2D texture_toile)
    {
        Renderer renderer = GetComponent<Renderer>();
        Texture texture = material.mainTexture;

        // Création texture avec les mêmes dim que la toile
        Texture2D texture2D = new Texture2D(texture_toile.width, texture_toile.height, TextureFormat.RGBA32, false);

        // On met la texture comme destination de rendu
        RenderTexture renderTexture = RenderTexture.GetTemporary(texture_toile.width, texture_toile.height, 24);
        Graphics.Blit(texture, renderTexture);

        // On crée une texture2D à partir de la texture de rendu
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, texture_toile.width, texture_toile.height), 0, 0);
        texture2D.Apply();

        // On libère la mémoire
        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(renderTexture);

        return texture2D;
    }


}
