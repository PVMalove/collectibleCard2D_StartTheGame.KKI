using System.Collections;
using UnityEngine;

namespace FX
{
    public class CoroutineFX : MonoBehaviour
    {    
        IEnumerator Start()
        {
            yield return new WaitForSeconds(2);
            ParticleSystem ps = GetComponent<ParticleSystem>();
            var emission = ps.emission;
            emission.enabled = false;
            yield return new WaitForSeconds(4);
            Destroy(gameObject);
        }
    }
}
