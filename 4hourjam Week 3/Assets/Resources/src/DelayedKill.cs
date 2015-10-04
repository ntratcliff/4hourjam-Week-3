using UnityEngine;
using System.Collections;

public class DelayedKill : MonoBehaviour
{
    public bool RandomDelay;
    public float RandSecondsMin, RandSecondsMax;
    public float SecondsDelay;
    // Use this for initialization
    void Start()
    {
        if (RandomDelay)
            SecondsDelay = Random.Range(RandSecondsMin, RandSecondsMax);

        StartCoroutine("Kill", SecondsDelay);
    }

    IEnumerator Kill(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject.Destroy(this.gameObject);
    }
}
