using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger3rd : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    // Update is called once per frame
    void Update()
    {
        Invoke("EndScene", 5);
    }

    public void EndScene()
    {
        animator.SetTrigger("FadeOut");
        animator.SetTrigger("Exit");
    }
}
