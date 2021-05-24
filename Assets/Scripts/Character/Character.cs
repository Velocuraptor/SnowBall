using UnityEngine;
using Spine.Unity;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation skeletonAnimation = null;
    [SerializeField] private AnimationReferenceAsset idle = null, run = null;
    private string currantAnimation;

    public abstract void GetDamage();

    private void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        if(animation.name == currantAnimation)
            return;
        
        skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
        currantAnimation = animation.name;
    }

    public void SetCharacterState(string state)
    {
        switch (state)
        {
            case "Idle":
                SetAnimation(idle,true, 1.0f);
                break;
            case "Run":
                SetAnimation(run,true, 1.0f);
                break;
        }
    }
    
}
