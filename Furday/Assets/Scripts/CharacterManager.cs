using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance; // Singleton to access it easily

    public GameObject character1; // First character
    public GameObject character2; // Second character
    private GameObject activeCharacter; // Current character being dressed

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        SetActiveCharacter(character1); // Default character
    }

    public void SetActiveCharacter(GameObject newCharacter)
    {
        activeCharacter = newCharacter;
        Debug.Log("Active character set to: " + activeCharacter.name);
    }

    public GameObject GetActiveCharacter()
    {
        return activeCharacter;
    }
}
