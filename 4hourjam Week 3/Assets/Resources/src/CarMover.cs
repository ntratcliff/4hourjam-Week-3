using UnityEngine;
using System.Collections;

public class CarMover : MonoBehaviour
{
    public Vector3[] Paths;
    public float Speed;
    private int lastNode, nextNode;
    private SlerpToLookAt looker;
    // Use this for initialization
    void Start()
    {
        looker = GetComponent<SlerpToLookAt>();
        GameObject pathObject = GameObject.Find("CarPath");
        for (int i = 0; i < Paths.Length; i++)
        {
            Paths[i] += pathObject.transform.position; //I did a dumb so this has to happen now
        }
        transform.position = Paths[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != Paths[nextNode])
        {
            transform.position = Vector3.MoveTowards(transform.position, Paths[nextNode], Speed * Time.deltaTime);
        }
        else
        {
            lastNode = nextNode;
            if (++nextNode == Paths.Length)
                nextNode = 0;
            looker.Target = Paths[nextNode];
        }
        
    }
}
