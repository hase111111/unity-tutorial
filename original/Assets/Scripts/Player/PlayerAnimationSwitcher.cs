using UnityEngine;

public class PlayerAnimationSwitcher : MonoBehaviour
{
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        // animator ���擾
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // �A�j���[�V������؂�ւ���
        SwitchWalkingAnimation(false);
    }

    public void SwitchWalkingAnimation(bool isWalking)
    {
        // isWalking �ɂ���ăA�j���[�V������؂�ւ���
        _animator.SetBool("isWalking", isWalking);
    }
}
