using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;

    public void SelectCharacter1()
    {
        CharacterManager.Instance.SetActiveCharacter(character1);
        character1.SetActive(true);
        character2.SetActive(false);
    }

    public void SelectCharacter2()
    {
        CharacterManager.Instance.SetActiveCharacter(character2);
        character2.SetActive(true);
        character1.SetActive(false);
    }
}
