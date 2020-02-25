namespace ArionDigital
{
    using UnityEngine;

    public class Shooter : MonoBehaviour
    {
        public GameObject ball;
        public Transform spawnPoint;
        public Transform target;
        public AudioSource shootAudioClip;

        public void Shoot()
        {
            GameObject objToSpawn = Instantiate(ball, spawnPoint.position, Quaternion.identity);
            objToSpawn.transform.LookAt(target);
            Rigidbody rbody = objToSpawn.GetComponent<Rigidbody>();
            rbody.AddForce(objToSpawn.transform.forward, ForceMode.Impulse);
            shootAudioClip.Play();
        }


    }
}