using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject loseUI;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Игрок умер 💀");

        if (loseUI != null)
            loseUI.SetActive(true);

        Time.timeScale = 0f;

        Destroy(gameObject);
    }
}