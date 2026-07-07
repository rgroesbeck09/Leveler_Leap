using System.Collections;
using UnityEngine;

public class LightController : MonoBehaviour
{
    IEnumerator Start()
    {
        Light lightSource = GetComponent<Light>();

        yield return null;
        yield return null;

        lightSource.enabled = false;
        yield return null;
        lightSource.enabled = true;
    }
}
