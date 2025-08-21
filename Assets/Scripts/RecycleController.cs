using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using TMPro;
using UnityEngine;

public class RecycleController : MonoBehaviour
{
    public string TargetTag;
    public TextMeshProUGUI Text;

    [Header("Score")]
    public int TrashRecycled;
    public int TrashMisplaced;

    public int RequiredScore = 10;

    [Header("Variables")]
    public float FlashTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(TargetTag))
        {
            RequiredScore--;

            Text.SetText(TargetTag + ": " + RequiredScore + " Left");

            TrashRecycled++;
            StartCoroutine(Flash(Color.green));
            if(RequiredScore == 0)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.color = Color.green;
                Requirements.Instance.AddScore();
            }
            
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

    private void Start()
    {
        Text.SetText(TargetTag + ": " + RequiredScore + " Left");
    }
}
