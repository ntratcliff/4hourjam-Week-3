using UnityEngine;
using System.Collections;

public class AnimalMovement : MonoBehaviour
{
    public Vector3 HopForce;
    public float RotMin;
    public float RotMax;
    public float MoveDelay;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Move(MoveDelay, RotMin, RotMax, HopForce));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Move(float delay, float rotMin, float rotMax, Vector3 hopForce)
    {
        yield return new WaitForSeconds(delay);
        //get random rotation
        //move to rotation
        //apply impulse force
        float rot = Random.Range(rotMin, RotMax);
        rot *= Mathf.Sin(Random.Range(-1f, 1f));
        GetComponent<Transform>().Rotate(new Vector3(0, 0, rot));
        GetComponent<Rigidbody>().AddRelativeForce(hopForce, ForceMode.Impulse);
        StartCoroutine(Move(MoveDelay, RotMin, RotMax, HopForce));
    }
}
