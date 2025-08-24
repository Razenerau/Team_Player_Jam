using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RecycleController : MonoBehaviour
{
    public string TargetTag;
    public Color DefaultColor = Color.white;

    [Header("Variables")]
    public float FlashTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(TargetTag))
        {
            Requirements.Instance.OnTrashRecycled(TargetTag);
            StartCoroutine(Flash(Color.green));
        }
        else
        {
            Requirements.Instance.OnTrashMisplaced();
            StartCoroutine(Flash(Color.red));
        }
        Destroy(collision.gameObject);
    }

    private IEnumerator Flash(Color color)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;

        yield return new WaitForSeconds(FlashTime);

        spriteRenderer.color = DefaultColor;
    }
}
