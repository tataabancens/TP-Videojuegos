using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Enums;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private TextMeshProUGUI _progressText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync() {
        AsyncOperation operation = SceneManager.LoadSceneAsync(Scenes.OpenWorld.ToString());

        float progress = 0;
        operation.allowSceneActivation = false;

        while (!operation.isDone) {
            progress = operation.progress;

            _progressBar.fillAmount = progress;
            _progressText.text = $"{progress * 100} %";

            if (operation.progress >= 0.9f) {
                _progressText.text = $"Press space bar to continue";

                if (Input.GetKeyDown(KeyCode.Space)) {
                    operation.allowSceneActivation = true;
				}
            }

            yield return null;
		}
	}
}
