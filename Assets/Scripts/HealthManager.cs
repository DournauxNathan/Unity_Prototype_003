using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private int startingHealth = 5;
     
    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
            Die(); 
        
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
