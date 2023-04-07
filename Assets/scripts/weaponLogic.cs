using System.Collections;
using UnityEngine;
public enum ShootingMode
{
    SemiAuto,
    FullAuto
}
public class WeaponLogic : MonoBehaviour
{
    protected Animator animator;
    protected AudioSource audioSource;
    public bool timeNoShoot = false;
    public bool canShoot = false;
    public bool reloading = false;

    [Header("Object reference")]
    public ParticleSystem gunFire;
    public Camera mainCamera;
    public Transform GunSight;
    public GameObject damageEffectPrefab;

    [Header("Sound reference")]
    public AudioClip SoundShoot;
    public AudioClip SoundNoBullets;
    public AudioClip SoundCartridgeIn;
    public AudioClip SoundCartridgeOut;
    public AudioClip SoundEmpty;
    public AudioClip SoundDraw;

    [Header("Weapon attributes")]
    public ShootingMode shootingMode  = ShootingMode.FullAuto;
    public float Damage               = 20f;
    public float firingRate           = 0.3f;
    public bool isADS                 = false;
    public int cartridgeSize          = 12;
    public int maximumBullets         = 100;
    public int remainingBullets;
    public int bulletsInCartridge;
    public float timeAim;
    public float zoom;
    public float normal;
    public Vector3 ADS;
    public Vector3 shotFromHip;
    void Start()
    {
        audioSource        = GetComponent<AudioSource>();
        animator           = GetComponent<Animator>();
        bulletsInCartridge = cartridgeSize;
        remainingBullets   = maximumBullets;
        Invoke("EnabledArm", 0.5f);
    }
    void FixedUpdate()
    {
        if (shootingMode == ShootingMode.FullAuto && Input.GetButton("Fire1"))
            CheckShoot();

        else if (shootingMode == ShootingMode.SemiAuto && Input.GetButtonDown("Fire1"))
            CheckShoot();

        if (Input.GetButtonDown("Reload"))
            CheckReload();

        if (Input.GetMouseButton(1))
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, ADS, timeAim * Time.deltaTime);
            isADS = true;
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, zoom, timeAim * Time.deltaTime);
        }

        if (Input.GetMouseButtonUp(1))
            isADS = false;

        if (isADS == false)
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, shotFromHip, timeAim * Time.deltaTime);
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, normal, timeAim * Time.deltaTime);
        }
    }

    void EnabledArm() => canShoot = true;

    void CheckShoot()
    {
        if (!canShoot) return;
        if (timeNoShoot) return;
        if (reloading) return;
        if (bulletsInCartridge > 0)
            Shoot();
        else
            NoBullets();
    }

    void Shoot()
    {
        audioSource.PlayOneShot(SoundShoot);
        timeNoShoot = true;
        gunFire.Stop();
        gunFire.Play();
        PlayAnimationShoot();
        bulletsInCartridge--;
        StartCoroutine(ResetTimeNoShot());
        DirectShot();
    }
    public void CreateDamageEffect(Vector3 pos, Quaternion rot)
    {
        GameObject damageEffect = Instantiate(damageEffectPrefab, pos, rot);
        Destroy(damageEffect, 1f);
    }
    void DirectShot()
    {
        RaycastHit hit;
        if (Physics.Raycast(GunSight.position, GunSight.forward, out hit))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                HP HP = hit.transform.GetComponent<HP>();
                if (HP == null)
                {
                    throw new System.Exception("Enemy health component not found");
                }
                else
                {
                    HP.TakeDamage(Damage);
                    CreateDamageEffect(hit.point,hit.transform.rotation);
                }
            }
        }
    }

    public virtual void PlayAnimationShoot()
    {
        if (gameObject.name == "Police9mm")
        {
            if (bulletsInCartridge > 1)
                animator.CrossFadeInFixedTime("Fire", 0.1f);
            else
                animator.CrossFadeInFixedTime("FireLast", 0.1f);
        }
        else
            animator.CrossFadeInFixedTime("Fire", 0.1f);
    }

    void NoBullets()
    {
        audioSource.PlayOneShot(SoundNoBullets);
        timeNoShoot = true;
        StartCoroutine(ResetTimeNoShot());
    }
    IEnumerator ResetTimeNoShot()
    {
        yield return new WaitForSeconds(firingRate);
        timeNoShoot = false;
    }
    void CheckReload()
    {
        if (remainingBullets > 0 && bulletsInCartridge < cartridgeSize)
            Reload();
    }
    void Reload()
    {
        if (reloading) return;
        reloading = true;
        animator.CrossFadeInFixedTime("Reload", 0.1f);
    }
    void ReloadAmmunition()
    {
        int bulletsToReload       = cartridgeSize - bulletsInCartridge;
        int subtractBullets       = (remainingBullets >= bulletsToReload) ? bulletsToReload : remainingBullets;
        remainingBullets         -= subtractBullets;
        bulletsInCartridge       += bulletsToReload;
    }
    public void cartridgeInside()
    {
        audioSource.PlayOneShot(SoundCartridgeIn);
        ReloadAmmunition();
    }
    public void cartridgeOut()
    {
        audioSource.PlayOneShot(SoundCartridgeOut);
        ReloadAmmunition();
    }
    public void empty()
    {
        audioSource.PlayOneShot(SoundEmpty);
        Invoke("ReiniciarRecargar", 0.1f);
    }
    void ReiniciarRecargar() => reloading = false;
    public void unfoundOn() => audioSource.PlayOneShot(SoundDraw);
}