using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger2nd : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    // Update is called once per frame
    void Update()
    {
        Invoke("goToThirdScene", 50);
    }

    public void goToThirdScene()
    {
        FadeToLevel(2);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
