using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using UnityEngine.UI;

public class pokeapi : MonoBehaviour
{
    public TMPro.TMP_InputField inputField;
    public Image Preview;

    private AudioSource audioSource;

    void Start()
    {
     audioSource = GetComponent<AudioSource>();   
    }


    void Update()
    {
        if(Keyboard.current.enterKey.wasPressedThisFrame)
        {
            if ( inputField.text.Length > 0)
            {
                StartCoroutine(CheckAPi());
            }
        }
    }

    private IEnumerator CheckAPi()
    {
        PokeData data;
        using (UnityWebRequest request = UnityWebRequest.Get("https://pokeapi.co/api/v2/pokemon/" + inputField.text))
        {
            yield return request.SendWebRequest();
            if(request.result != UnityWebRequest.Result.Success)
            {
                yield break;
            }

            
            data = JsonUtility.FromJson<PokeData>(request.downloadHandler.text);
        }

        if(data != null)
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(data.sprites.front_shiny))
            {
                yield return request.SendWebRequest();
                if(request.result != UnityWebRequest.Result.Success)
                {
                    yield break;
                }
                Texture2D preview = DownloadHandlerTexture.GetContent(request);
                Preview.sprite = Sprite.Create(preview, new Rect(0,0,preview.width, preview.height), new Vector2(0.5f,0.5f));
            }
        }

        using(UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(data.cries.legacy, AudioType.OGGVORBIS))
        {
            yield return request.SendWebRequest();
            if(request.result != UnityWebRequest.Result.Success)
            {
                yield break;
            }
            AudioClip clip = DownloadHandlerAudioClip.GetContent(request);
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    [Serializable]
    public class PokeData
    {
       public string name;
       public PokeSprite sprites;
        public PokeCry cries;
    }

    [Serializable]
    public class PokeSprite
    {
        public string front_shiny;
    }

    [Serializable]
    public class PokeCry
    {
        public string legacy;
    }
}
