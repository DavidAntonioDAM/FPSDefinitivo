using UnityEngine;

namespace Nokobot.Assets.Crossbow
{
    public class CrossbowShoot : MonoBehaviour
    {
        public AudioClip shoot;
        private AudioSource audioSource;
        public GameObject arrowPrefab;
        public Transform arrowLocation;

        public float shotPower = 100f;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            if (arrowLocation == null)
                arrowLocation = transform;
        }

        void Update()
        {
            if(Input.GetButtonDown("Fire1"))
            {
                audioSource.PlayOneShot(shoot);
                Instantiate(arrowPrefab, arrowLocation.position, arrowLocation.rotation).GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotPower);

            }
        }
    }
}
