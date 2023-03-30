using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Slider slider;

    public float t = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadLevel(2);
        }

        t += Time.deltaTime;

        if (t >= 10 )
        {
            LoadLevel(2);

        }

        slider.value = map(t, 0, 10, 0, 1);
    }
        
    public void LoadLevel (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
    }

    
    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}