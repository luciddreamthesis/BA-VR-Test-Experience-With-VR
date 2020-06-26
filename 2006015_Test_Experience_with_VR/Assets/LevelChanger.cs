using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    // Update is called once per frame
    void Update()
    {
        Invoke("goToSecondScene", 3);
    }

    public void goToSecondScene ()
    {
        FadeToLevel(1);
    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
