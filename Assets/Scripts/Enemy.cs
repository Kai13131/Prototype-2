using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 100;

    public TextMeshProUGUI healthText;
    
    public Player player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthText.text = enemyHealth.ToString();
    }

    public void takeDamage(int damage)
    {
        enemyHealth -= damage;
        healthText.text = enemyHealth.ToString();

        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakePlayerDamage(int damage)
    {
        player.takeDamage(damage);
        Debug.Log("Enemy attacked");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
