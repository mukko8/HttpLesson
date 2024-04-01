using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("https://p.potaufeu.asahi.com/a3e7-p/picture/26795629/ecedd94bde04ca0e056135a8a2e541d8_640px.jpg"));
    }
    IEnumerator GetRequest(string uri){
        using(UnityWebRequest uwr=UnityWebRequestTexture.GetTexture(uri)){
            yield return uwr.SendWebRequest();
            if(uwr.result != UnityWebRequest.Result.Success){
                Debug.Log(uwr.error);
            }else{
                Texture texture=DownloadHandlerTexture.GetContent(uwr);
                Sprite sp=Sprite.Create(
                    (Texture2D)texture,
                    new Rect(0,0,texture.width,texture.height), //元画像のサイズ
                    new Vector2(0.5f,0.5f)
                );
                Image image=GetComponent<Image>();
                image.preserveAspect=true; //縦横比を変えない

                image.rectTransform.sizeDelta=new Vector2(
                    300, //縦横の短いほうが300になる
                    300
                );
                image.sprite=sp;
            }
        }
    }
}
