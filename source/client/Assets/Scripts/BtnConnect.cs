using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnConnect : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_InputField inputField2;
    public void Connect() { 
        string s = inputField.text;
        NetManager.Connect(s,int.Parse(inputField2.text));
        SceneManager.LoadScene(1);
    }
}
