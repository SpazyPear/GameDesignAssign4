using System.Collections;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    public Animator[] animations;
    public bool isOn { get; private set; } = false;

    public void Play(int index = 0)
    {
        StartCoroutine("PlayTransition", animations[index]);
    }

    IEnumerator PlayTransition(Animator anim)
    {
        isOn = true;
        anim.SetTrigger("Next");
        yield return new WaitForEndOfFrame();
        yield return new WaitForSecondsRealtime(TransitionLength(anim));
        isOn = false;
    }

    private float TransitionLength(Animator anim)
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        return info.length + info.normalizedTime;
    }
}
