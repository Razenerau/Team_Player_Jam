using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleController : MonoBehaviour
{
    public string TargetTag;

    [Header("Score")]
    public int TrashRecycled;
    public int TrashMisplaced;

    [Header("Variables")]
    public float FlashTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(TargetTag))
        {
            TrashRecycled++;
            StartCoroutine(Flash(Color.green));
            
        }
        else
        { 
            TrashMisplaced++;
            StartCoroutine(Flash(Color.red));
        }
        Destroy(collision.gameObject);
    }

    private IEnumerator Flash(Color color)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;

        yield return new WaitForSeconds(FlashTime);

        spriteRenderer.color = Color.white;
    }
}
