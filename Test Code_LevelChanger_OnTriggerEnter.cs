using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger2nd : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    public void goToThirdScene()
    {
        FadeToLevel(2);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}

