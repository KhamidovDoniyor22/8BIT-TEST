using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject _loadingPanel;
    [SerializeField] private Slider _loadingSlider;

    [Header("Settings")]
    [SerializeField] private float _minLoadTime = 1.0f;

    public void LoadNewScene(string sceneName)
    {
        _loadingPanel.SetActive(true);
        StartCoroutine(LoadAsync(sceneName));
    }

    private IEnumerator LoadAsync(string sceneName)
    {
        float timer = 0;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        operation.allowSceneActivation = false;

        while (timer < _minLoadTime || operation.progress < 0.9f)
        {
            timer += Time.deltaTime;

            // Плавное заполнение слайдера (от 0 до 1)
            float progress = Mathf.Clamp01(timer / _minLoadTime);
            _loadingSlider.value = progress;

            yield return null;
        }

        _loadingSlider.value = 1f;
        yield return new WaitForSeconds(0.2f);
        operation.allowSceneActivation = true;
    }
}