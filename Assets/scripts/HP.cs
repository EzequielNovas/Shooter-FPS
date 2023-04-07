using UnityEngine;
public class HP : MonoBehaviour
{
    public AudioClip bulletImpact;
    public AudioSource audioSource;
    public GameObject floatingTextPrefab;
    public HP fatherRef;
    public float value = 100;
    public float damageMultiplier = 1.0f;
    public float fullDamage;

    public void TakeDamage(float damage)
    {
        audioSource.PlayOneShot(bulletImpact);
        damage *= damageMultiplier;

        if (fatherRef!= null)
        {
            fatherRef.TakeDamage(damage);
            return;
        }

        value -= damage;
        fullDamage = damage;

        if (value>= 0)
            ShowFloatingText();

        if (value < 0)
        {
            value = 0;
            ShowFloatingText();
        }
    }
    void  ShowFloatingText()
    {
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = fullDamage.ToString();
    }
}


