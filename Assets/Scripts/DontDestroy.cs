using UnityEngine;

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