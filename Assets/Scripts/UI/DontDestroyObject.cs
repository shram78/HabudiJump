using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    private static DontDestroyObject _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}