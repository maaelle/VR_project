using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSpray : MonoBehaviour
{

    [Range(0.05f,3)] public float sprayDepth = 1;
    public LayerMask layers;
    [Range(0, 1)] public float sprayWidth;
    public Texture2D sprayTexture;
    bool hasHitPaintable = false;
    public Color colorSpray = Color.white;

 	public GameObject exampleOne;


    // Update is called once per frame
    void Update()
    {
        // Créer la ray (demi-droite) partant du pinceau 
        Ray ray = new Ray(transform.position, -transform.forward);
        RaycastHit hit;

        //Raycast pour vérifier si on touche et récupérer les infos dans Raycasthit
        if(Physics.Raycast(ray, out hit, sprayDepth, layers)){
            //Trouver les coordonnées où dessiner (avec RaycastHit.textCoord)
            Vector2 hitUV = hit.textureCoord;

            //Peindre sur la texture 
            PaintCanvas paintCanvas =  hit.transform.GetComponent<PaintCanvas>();
            paintCanvas.Paint(hitUV, sprayWidth, sprayTexture, colorSpray);

            hasHitPaintable = true;

        }
        // Quand on touche rien
        else {
            // one ne fait rien 
            hasHitPaintable = false;
        }
        
    }

    void OnDrawGizmos(){
        if (hasHitPaintable){
            Gizmos.color = Color.yellow;
        }
        else {
            Gizmos.color = Color.red;
        Debug.Log("The names of these three objects are " + exampleOne.name );

        }
        Gizmos.DrawRay(transform.position, -transform.forward*sprayDepth);
    }
}
