using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public List<GameObject> TrashList;
    public Transform SpawnerTransfowm;
    public int maxTrashCount;
    public float SpawnTimer;
    public float SpawnStartOffset;

    [Header("Trash Types")]
    public bool Plastic;
    public bool Metal;
    public bool Paper;
    public bool Compost;

    [Header("Prefabs")]
    public List<GameObject> PaperList;
    public List<GameObject> MetalList;
    public List<GameObject> PlasticList;
    public List<GameObject> CompostList;

    // Start is called before the first frame update
    void Start()
    {
        InitializeTrashList();
    }

    private void InitializeTrashList()
    {
        if (Plastic)
        {
            foreach (var trash in PlasticList)
            {
                TrashList.Add(trash);
            }
        }
        if (Metal)
        {
            foreach (var trash in MetalList)
            {
                TrashList.Add(trash);
            }
        }
        if (Plastic)
        {
            foreach (var trash in PaperList)
            {
                TrashList.Add(trash);
            }
        }
        if (Compost)
        {
            foreach (var trash in CompostList)
            {
                TrashList.Add(trash);
            }
        }

        StartCoroutine(SpawnInterval());
    }

   

    private void SpawnTrash()
    {
        if (gameObject.transform.childCount >= maxTrashCount) return;

        int randomIndex = Random.Range(0, TrashList.Count);
        GameObject trash = TrashList[randomIndex];

        //Debug.Log(trash.name + " " + trash.transform.position + " spawned");
        Instantiate(trash, SpawnerTransfowm.position, Quaternion.identity, SpawnerTransfowm);
    }

    private IEnumerator SpawnInterval()
    {
        yield return new WaitForSeconds(SpawnStartOffset);


        while (true)
        {
            yield return new WaitForSeconds(SpawnTimer);
            SpawnTrash();
        }
    }
}
