using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintWand: MonoBehaviour
{

    [Range(0.05f,3)] public float brushDepth = 1;
    public LayerMask layers;
    [Range(0, 1)] public float brushWidth;
    public Texture2D brushTexture;
    bool hasHitPaintable = false;
    public Color colorBrush;


    // Update is called once per frame
    void Update()
    {
        // Créer la ray (demi-droite) partant du pinceau 
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;

        //Raycast pour vérifier si on touche et récupérer les infos dans Raycasthit
        if (Physics.Raycast(ray, out hit, brushDepth, layers))
        {
            //Trouver les coordonnées où dessiner (avec RaycastHit.textCoord)
            Vector2 hitUV = hit.textureCoord;

            //Peindre sur la texture 
            PaintCanvas paintCanvas =  hit.transform.GetComponent<PaintCanvas>();
            paintCanvas.Paint(hitUV, brushWidth, brushTexture, colorBrush);

            hasHitPaintable = true;

        }
        // Quand on touche rien
        else {
            // on ne fait rien 
            hasHitPaintable = false;
        }
        
    }

    void OnDrawGizmos(){

        if( hasHitPaintable){
            Gizmos.color = Color.green;
        }
        else{
            Gizmos.color = Color.blue;
        }
        Gizmos.DrawRay(transform.position, transform.up*brushDepth);
    }
}
