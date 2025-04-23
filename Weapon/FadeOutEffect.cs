using UnityEngine;
using UnityEngine.Rendering.Universal; // Potrebno za DecalProjector

public class FadeOutEffect : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    private Material materialInstance; 
    private float fadeSpeed;

    void Start()
    {
        // Pristup Decal Projectoru
        DecalProjector projector = GetComponent<DecalProjector>();
        if (projector != null)
        {
            // Instanciranje
            materialInstance = new Material(projector.material);
            projector.material = materialInstance;
            fadeSpeed = 1.0f / fadeDuration;
            //Debug.Log("FadeOutEffect attached and material instance created.");
        }
        else
        {
            Debug.LogError("Decal Projector not found! Ensure the object uses a Decal Projector.");
        }
    }

    void Update()
    {
        if (materialInstance != null)
        {
            // Smanjivanje aplha vred
            Color color = materialInstance.color;
            color.a = Mathf.Max(0, color.a - fadeSpeed * Time.deltaTime);
            materialInstance.color = color;

            // del obj ako je alph <= 0
            if (color.a <= 0)
            {
                //Debug.Log("Decal faded out and destroyed.");
                Destroy(gameObject);
            }
        }
    }
}
