using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PostController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PostRequest());
    }
    IEnumerator PostRequest(){
        string uri="https://joytas.net/php/calc.php";
        WWWForm form=new WWWForm();
        form.AddField("x",5);
        form.AddField("y",8);
        using(UnityWebRequest uwr=UnityWebRequest.Post(uri,form)){
            yield return uwr.SendWebRequest();
            if(uwr.result != UnityWebRequest.Result.Success){
                Debug.Log(uwr.error);
            }else{
                Debug.Log(uwr.downloadHandler.text);
            }
        }
    }
}
