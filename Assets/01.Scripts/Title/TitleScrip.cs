using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScrip : MonoBehaviour
{
    public string _sceneName = "InGameScene";
    [SerializeField] GameObject _fadeScreen;

    public float _Timer =5f;
    public void ClickStart()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneName);
        asyncLoad.allowSceneActivation = false;  // �� �ε��� �Ϸ�� ������ ���
        StartCoroutine(CoFadeIn());


        // �ε��� ����Ǵ� ���� ���
        while (!asyncLoad.isDone)
        {
            Debug.Log($"Loading progress: {asyncLoad.progress * 100}%");



            // �ε��� 90% �̻� �Ϸ�Ǹ� �� Ȱ��ȭ
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
                StartCoroutine(CoFadeOut());
            }

            yield return null;
        }
    }
    public void ClickExit()
    {
        Application.Quit();
    }


    public void FadeOut()
    {
        _fadeScreen.SetActive(true); // Panel Ȱ��ȭ
        Debug.Log("FadeCanvasController_ Fade Out ����");
        StartCoroutine(CoFadeOut());
        Debug.Log("FadeCanvasController_ Fade Out ��");
    }

    IEnumerator CoFadeIn()
    {
        float elapsedTime = 0f; // ���� ��� �ð�
        float fadedTime = 0.5f; // �� �ҿ� �ð�

        while (elapsedTime <= fadedTime)
        {
            _fadeScreen.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(1f, 0f, elapsedTime / fadedTime));

            elapsedTime += Time.deltaTime;
            Debug.Log("Fade In ��...");
            yield return null;
        }
        Debug.Log("Fade In ��");
        _fadeScreen.SetActive(false); // Panel�� ��Ȱ��ȭ
        yield break;
    }

    IEnumerator CoFadeOut()
    {
        float elapsedTime = 0f; // ���� ��� �ð�
        float fadedTime = 0.5f; // �� �ҿ� �ð�

        while (elapsedTime <= fadedTime)
        {
            _fadeScreen.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(0f, 1f, elapsedTime / fadedTime));

            elapsedTime += Time.deltaTime;
            Debug.Log("Fade Out ��...");
            yield return null;
        }

        Debug.Log("Fade Out ��");
        yield break;
    }


}
