using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHealth = 100;
    public TextMeshProUGUI healthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthText.text = playerHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        playerHealth -= damage;
        healthText.text = playerHealth.ToString();

        if(playerHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
