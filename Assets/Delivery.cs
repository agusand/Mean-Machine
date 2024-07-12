using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new(255, 255, 255, 255);
    [SerializeField] Color32 noPackageColor = new(255, 0, 0, 255);
    private bool hasPackage = false;
    private int score = 0;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package"))
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Client"))
        {
            if (hasPackage)
            {
                Debug.Log("Package delivered");
                hasPackage = false;
                Destroy(other.gameObject);
                score++;
                Debug.Log($"Score: {score}");

            }
            else
            {
                Debug.Log("You need to pick up the package");
            }
        }
    }

    private void Update()
    {
        spriteRenderer.color = hasPackage ? hasPackageColor : noPackageColor;
    }
}
