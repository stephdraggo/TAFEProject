using UnityEngine;

[AddComponentMenu("Game Systems/Don't Destroy")]
public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
//and here are our global enums
public enum CharacterClass
{
    Fighter,
    Rogue,
    Witch
}
public enum AiBehaviour
{
    Player,
    Wandering,
    Fleeing,
    Hidden,
    Patrolling,
    Chasing
}
public enum QuestState
{
    Available,
    Active,
    Complete,
    Claimed
}