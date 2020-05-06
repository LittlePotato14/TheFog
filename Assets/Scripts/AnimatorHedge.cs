using UnityEngine;

/// <summary>
/// Скрипт анимации главного героя.
/// </summary>
public class AnimatorHedge : MonoBehaviour
{
    public static Animator anim;

    // Вызывается один раз при запуске.
    void Start()
    {
        anim = GetComponent<Animator>();
    }
}