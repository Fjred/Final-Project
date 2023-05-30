
using UnityEngine;
using UnityEngine.Events;


public class Gun : MonoBehaviour
{
    public GameObject hitPrefab;
    public GameObject humanHitPrefab;

    public GameObject gunfire;

    private AudioSource source;

    public AudioClip shootSound;

    public ParticleSystem smoke;
    public ParticleSystem blood;

    public float maxDistance = 100;

    //public UnityEvent onShoot;



    public int maxAmmo = 30;
    public int ammo;

    public int recoilAngle = 1;

    public int shotsPerAmmo = 5;

    public int damage = 10;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();

        gunfire.SetActive(false);
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TryShoot();
        }
    }

    void DisableFlashEffect()
    {
        gunfire.SetActive(false);
    }

    void TryShoot()
    {
        if (ammo <= 0) return;

        ammo--;

        //onShoot.Invoke();

        gunfire.SetActive(true);
        Invoke("DisableFlashEffect", 0.05f);

        source.pitch = Random.Range(0.8f, 1.2f);
        source.PlayOneShot(shootSound);

        for (int i = 0; i < shotsPerAmmo; i++)
        {
            Shoot();
        }
    }

    void Shoot()
    {

        var cam = Camera.main;

        var direction = cam.transform.forward;


        direction = Quaternion.Euler(Random.Range(-recoilAngle, recoilAngle), Random.Range(-recoilAngle, recoilAngle), 0) * direction;

        var ray = new Ray(cam.transform.position, direction);


        if (Physics.Raycast(ray, out var hit, maxDistance))
        {

            var health = hit.transform.GetComponent<Health>(); //null
            if (health)
            {
                health.Damage(damage);
            }

            if (!hit.transform.CompareTag("Enemy"))
            { 
                var hitObject = Instantiate(hitPrefab, hit.point, Quaternion.Euler(0, 0, 0), hit.transform);

                hitObject.transform.parent = null;

                hitObject.transform.forward = hit.normal;
                
                hitObject.transform.position += hit.normal * 0.02f;
                
                hitObject.transform.localScale = new Vector3(2f, 2f, 2f);

                ParticleSystem smoked = Instantiate(smoke, hit.point, Quaternion.identity);

                smoked.Play();

                Destroy(hitObject, 5f);
            }
            else
            {
                var hitObject = Instantiate(humanHitPrefab, hit.point, Quaternion.Euler(0, 0, 0), hit.transform);


                hitObject.transform.forward = hit.normal;

                hitObject.transform.position += hit.normal * 0.02f;

                hitObject.transform.localScale = new Vector3(2f, 2f, 2f);

                ParticleSystem blooded = Instantiate(blood, hit.point, Quaternion.identity);

                blooded.Play();

                Destroy(hitObject, 5f);
            }
        }
    }
}
