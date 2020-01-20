using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIntroText : MonoBehaviour
{
    public float time = 2;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
