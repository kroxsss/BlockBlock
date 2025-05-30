using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
   
    public void  LoadScene(string name)
    {
        Debug.Log("enes yüklendi"+name);
        SceneManager.LoadScene(name);
        
    }
}
