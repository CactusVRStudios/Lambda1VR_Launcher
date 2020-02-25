namespace ArionDigital
{
    using UnityEngine;

    public class DestroyAfterTime : MonoBehaviour
    {
        private void Start()
        {
            Invoke("DestroySelf", 3.0f);
        }

        void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}