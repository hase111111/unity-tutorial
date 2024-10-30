using UnityEngine;

public class PlayerAnimationSwitcher : MonoBehaviour
{
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        // animator を取得
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // アニメーションを切り替える
        SwitchWalkingAnimation(false);
    }

    public void SwitchWalkingAnimation(bool isWalking)
    {
        // isWalking によってアニメーションを切り替える
        _animator.SetBool("isWalking", isWalking);
    }
}
