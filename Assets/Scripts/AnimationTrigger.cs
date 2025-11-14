using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private Player _player => GetComponentInParent<Player>();

    public void OnAnimationTrigger()
    {
        _player.AnimationTrigger();
    }
}
