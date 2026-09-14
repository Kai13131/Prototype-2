using System.Collections;
using UnityEngine;

public class DiceRollAnimation : MonoBehaviour
{
    public RectTransform playerGlow;
    public RectTransform enmeyGlow;

    private Vector3 playerGlowStartPosition;
    private Vector3 enmeyGlowStartPosition;

    public RectTransform[] dice;

    public float startSpeed = 0.5f;
    public float endSpeed = 1.0f;
    private bool playerIsRolling = false;
    private bool enemyIsRolling = false;

    public Enemy enemy;

    void Start()
    {
        playerGlowStartPosition = playerGlow.position;
        enmeyGlowStartPosition = enmeyGlow.position;
    }

    public void Roll()
    {
        if (!playerIsRolling && !enemyIsRolling)
        {
            StartCoroutine(RollAnimation());
        }
        Debug.Log("Roll Button Pressed");
    }
    IEnumerator RollAnimation()
    {
        playerIsRolling = true;

        int finalNumberr = Random.Range(0, 6);
        int current = 0;

        for(int i = 0; i < 20 + finalNumberr; i++)
        {
            current = i % 6;

            playerGlow.position = dice[current].position;

            float speed = Mathf.Lerp(startSpeed, endSpeed, (float)i / (20 + finalNumberr));
            yield return new WaitForSeconds(speed);

        }
        playerGlow.position = dice[finalNumberr].position;

        Debug.Log("Player rolled: " + (finalNumberr + 1));

        enemy.takeDamage(finalNumberr + 1);


        yield return new WaitForSeconds(1.5f);

        playerGlow.position = playerGlowStartPosition;
        playerIsRolling = false;
        StartCoroutine(EnemyRoll());


    }

    IEnumerator EnemyRoll()
    {
        enemyIsRolling = true;

        int finalNumberr = Random.Range(0, 6);
        int current = 0;

        for (int i = 0; i < 20 + finalNumberr; i++)
        {
            current = i % 6;

            enmeyGlow.position = dice[current].position;

            float speed = Mathf.Lerp(startSpeed, endSpeed, (float)i / (20 + finalNumberr));
            yield return new WaitForSeconds(speed);

        }
        enmeyGlow.position = dice[finalNumberr].position;

        Debug.Log("Enemy rolled: " + (finalNumberr + 1));

        enemy.TakePlayerDamage(finalNumberr + 1);

        yield return new WaitForSeconds(1.5f);
        enemyIsRolling = false;

        enmeyGlow.position = playerGlowStartPosition;
    }
}
