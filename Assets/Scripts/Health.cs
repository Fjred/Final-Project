
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    public int maxHp = 100;
    public int hp;

    public bool destroyOnDeath;



    public void Damage(int amount)
    {
        hp -= amount;
        if (hp <= 0) Die();
    }

    public void Die()
    {
        if (destroyOnDeath)
        {

            gameObject.SetActive(false);

            Invoke("Activate", 3f);
        }
    }

    public void Activate()
    {
        maxHp = maxHp + 10;

        hp = maxHp;

        gameObject.transform.position = new Vector3(38.08f, -4.29f, -12.98f);

        gameObject.SetActive(true);
        

    }
}
