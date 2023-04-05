using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _nameInputField;

    void Start()
    {
        if (_nameInputField == null)
            throw new UnassignedReferenceException("_nameInputField is not assigned.");

        // Auto-select name field at start
        _nameInputField.Select();
    }

    void Update()
    {
        // Enter key (there is no Keycode.Enter - this is the keycode to use)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Player must insert a name
            if (_nameInputField.text.Length > 0)
            {
                SwitchGameScene();
            }
        }
    }

    private void SwitchGameScene()
    {
        // NOTE: if we need to save the name for the game, do it here.
        SceneManager.LoadScene("Main");
    }
}
