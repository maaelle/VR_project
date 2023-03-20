using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErasePaint : MonoBehaviour
{

    [Range(0.05f, 3)] public float EraserDepth = 1;
    public LayerMask layers;
    [Range(0, 1)] public float EraserWidth;
    public Texture2D EraserTexture;
    bool hasHitEraser = false;
    public Color eraserUse = Color.black;


    // Update is called once per frame
    void Update()
    {
        // Créer la ray (demi-droite) partant du pinceau 
        Ray ray = new Ray(transform.position, -transform.forward);
        RaycastHit hit;

        //Raycast pour vérifier si on touche et récupérer les infos dans Raycasthit
        if (Physics.Raycast(ray, out hit, EraserDepth, layers))
        {
            //Trouver les coordonnées où dessiner (avec RaycastHit.textCoord)
            Vector2 hitUV = hit.textureCoord;

            //Peindre sur la texture 
            EraseCanvas erase = hit.transform.GetComponent<EraseCanvas>();
            erase.Erase(hitUV, EraserWidth, EraserTexture, eraserUse);

            hasHitEraser = true;

        }
        // Quand on touche rien
        else
        {
            // on ne fait rien 
            hasHitEraser = false;
        }

    }

    void OnDrawGizmos()
    {

        if (hasHitEraser)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.blue;
        }
        Gizmos.DrawRay(transform.position, -transform.forward * EraserDepth);
    }
}
