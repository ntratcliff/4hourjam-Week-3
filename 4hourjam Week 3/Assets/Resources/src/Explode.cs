using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour
{
    public int Voxels;
    public Vector3 VeloMin;
    public Vector3 VeloMax;
    GameObject voxPrefab;
    // Use this for initialization
    void Start()
    {
        voxPrefab = Resources.Load<GameObject>("prefab/Voxel");
        if (!voxPrefab)
        {
            Debug.LogError("Failed to load Voxel prefab");
        }

        StartCoroutine(TestExplode());
    }

    public void DoExplode()
    {
        AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
        Destroy(GetComponent<BoxCollider>());
        Destroy(GetComponent<MeshRenderer>());
        for (int i = 0; i < Voxels; i++)
        {
            StartCoroutine(MakeVoxel());
        }
        Destroy(gameObject);
    }

    IEnumerator MakeVoxel()
    {
        GameObject voxel = Instantiate(voxPrefab);
        Vector3 range = VeloMax - VeloMin;
        Vector3 scale = Random.insideUnitSphere;
        range.Scale(scale);
        if (range.y < 0)
            range.y = -range.y; 
        voxel.GetComponent<Rigidbody>().velocity = range;
        voxel.transform.position = transform.position;
        yield return null;
    }

    IEnumerator TestExplode()
    {
        yield return new WaitForSeconds(Random.Range(15,120));
        DoExplode();
    }
}
