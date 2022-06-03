using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public Color32 hasPackageColor = new Color32(1,1,1,1);
    public Color32 noPackageColor = new Color32(1,1,1,1);
    public float destroyDelay = 0.5f;
    public bool hasPackage;
    private SpriteRenderer spriteRenderer;

    void Start() {
        Debug.Log(hasPackage);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("you picked up a package!");
            spriteRenderer.color = hasPackageColor;
            hasPackage = true;
            Destroy(other.gameObject,destroyDelay);

        }
        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("you delivered a package!");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
            Destroy(other.gameObject,destroyDelay);
        }
    }
}
