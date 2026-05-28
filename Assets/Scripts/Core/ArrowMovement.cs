using UnityEngine;

public class ArrowStop : MonoBehaviour
{
    public float speed = 5f;

    private float leftBorder = -2.6f;
    private float rightBorder = 2.6f;

    private int direction = 1;
    private bool stopped = false;

    [SerializeField] public int red = 5;
    [SerializeField] public int orange = 10;
    [SerializeField] public int Yellow = 15;
    [SerializeField] public int Green = 20;

    // Здоровье босса
    public BossHealth bossHealth;

    // Вся миниигра
    public GameObject arrowMiniGame;

    // Стартовая позиция
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void OnEnable()
    {
        stopped = false;
        direction = 1;

        transform.position = startPos;
    }

    void Update()
    {
        if (!stopped)
        {
            // Движение
            transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

            // Разворот
            if (transform.position.x <= leftBorder)
            {
                direction = 1;
            }

            if (transform.position.x >= rightBorder)
            {
                direction = -1;
            }

            // Остановка
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                stopped = true;
                CheckZone();
            }
        }
    }

    void CheckZone()
    {
        float x = transform.position.x;

        float zoneWidth = 5.2f / 7f;

        int zone = Mathf.FloorToInt((x - leftBorder) / zoneWidth);

        string[] colors =
        {
            "Красный",
            "Оранжевый",
            "Желтый",
            "Зеленый",
            "Желтый",
            "Оранжевый",
            "Красный"
        };

        zone = Mathf.Clamp(zone, 0, 6);

        Debug.Log("Выпал цвет: " + colors[zone]);

        int damage = 0;

        switch (colors[zone])
        {
            case "Красный":
                damage = red;
                break;

            case "Оранжевый":
                damage = orange;
                break;

            case "Желтый":
                damage = Yellow;
                break;

            case "Зеленый":
                damage = Green;
                break;
        }

        // Урон боссу
        bossHealth.TakeDamage(damage);

        // Скрываем миниигру
        arrowMiniGame.SetActive(false);
    }
}