using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_FadeScreen : MonoBehaviour
{
    public static UI_FadeScreen Instance { get; private set; }

    public Image _image;    

    public GameObject _button;

    public string _gameSceneName = "InGameScene";

    public string _titleSceneName = "MainMenuScene";

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.O))
        {
            _image.gameObject.SetActive(true);
            FadeOut();
        }
    }
    public void TitletButton()
    {
        StartCoroutine(LoadScene(_titleSceneName));
    }

    public void RestartButton()
    {
        StartCoroutine(LoadScene(_gameSceneName));
    }


    IEnumerator LoadScene(string SceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        asyncLoad.allowSceneActivation = false;  // 씬 로딩이 완료될 때까지 대기


        // 로딩이 진행되는 동안 대기
        while (!asyncLoad.isDone)
        {
            Debug.Log($"Loading progress: {asyncLoad.progress * 100}%");



            // 로딩이 90% 이상 완료되면 씬 활성화
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void FadeOut()
    {
        _image.gameObject.SetActive(true);
        StartCoroutine(FadeCoroutuine());
    }

    IEnumerator FadeCoroutuine()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
                yield return new WaitForSeconds(0.01f);
            _image.color = new Color(0, 0, 0, fadeCount);
        }
    }

}
