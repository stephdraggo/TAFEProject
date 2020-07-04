using UnityEngine;

[AddComponentMenu("Game Systems/Don't Destroy")]
public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
public enum CharacterClass
{
    Fighter,
    Rogue,
    Witch
}