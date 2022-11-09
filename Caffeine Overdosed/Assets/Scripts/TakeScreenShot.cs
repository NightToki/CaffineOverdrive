using System.Collections;
using UnityEngine;
using System.IO;


public class TakeScreenShot : MonoBehaviour
{
  

    private IEnumerator TakeScreenShot1()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/Screenshot.png", bytes);
        Destroy(texture);
    }
    public void takeShot()
    {
        Debug.Log("ScreenShot Taken");

        StartCoroutine("TakeScreenShot1");
    }
}
