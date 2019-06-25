using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject muzzleFlash;
    [SerializeField]
    private Transform MuzzleFlashPoint;
    [SerializeField]
    private GameObject Bullet;

    //[SerializeField] private Camera bulletCam;

    private Animator shutterAnimator;
    public bool debugMode;
    [Range(0.000001f, 1f)]
    public float timescale;

    public float bulletSpeed;

    [SerializeField] private Transform SpawnPoint;
    public static bool reloading { get; private set; }

    void Start()
    {
        reloading = false;
        debugMode = false;
        shutterAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {

    }
    // Could improve this in future to respawn a bullet that has already been fired instead of instantiating a new one and destroying it on impact.
    public void ShootWeapon()
    {
        StartCoroutine(MuzzleFlash());
        StartCoroutine(ContVibration(1, 1));
        GameObject bullet = Instantiate(Bullet, SpawnPoint.position, SpawnPoint.rotation);
        if (debugMode)
        {
            bullet.GetComponent<TrailRenderer>().enabled = true;
            //Instantiate(bulletCam, SpawnPoint.position, SpawnPoint.localRotation);
        }
        else
        {
            bullet.GetComponent<TrailRenderer>().enabled = false;
            reloading = true;
            StartCoroutine(ReloadTimer());
        }

        
        bullet.transform.Rotate(90f,0f,0f);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(SpawnPoint.forward*bulletSpeed);
        shutterAnimator.SetTrigger("Reload");
        
    }

    IEnumerator ReloadTimer()
    {
        yield return new WaitForSeconds(2);
        reloading = false;
    }

    IEnumerator MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.03f);
        muzzleFlash.SetActive(false);
    }

    IEnumerator ContVibration(float frequency, float amplitude)
    {
        ControllerVibration.EnableVibration(frequency,amplitude);
        yield return new WaitForSeconds(0.3f);
        ControllerVibration.DisableVibration();
    }
}
