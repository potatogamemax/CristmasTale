using Unity.VisualScripting;
using UnityEngine;

public class BootsTrapManager : MonoBehaviour
{
    private static bool _initialized = false;

    private void Awake()
    {
        if (_initialized)
        {
            Destroy(gameObject);
            return;

        }

        _initialized = true;
        DontDestroyOnLoad(gameObject);

        CreateIfNotExists<GameManager>("GameManager");
        CreateIfNotExists<SceneLoader>("SceneLoader");
        CreateIfNotExists<EventBus>("EventBus");

        SceneLoader.Instance.Load(SceneNames.MainMenu);
    }

    private void CreateIfNotExists<T>(string objectName) where T : Component
    {
        T existingObject = FindFirstObjectByType<T>();
        if (existingObject != null)
        {
            DontDestroyOnLoad(existingObject.gameObject);
            return;
        }

        GameObject go = new GameObject(objectName);
        T component = go.AddComponent<T>();
        DontDestroyOnLoad(go);
    }

}
