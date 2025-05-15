using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject bestRecords;
     
    private TextMeshProUGUI textRecords;

    private void Start()
    {
        
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("fourxfour");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
