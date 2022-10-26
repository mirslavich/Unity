using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static readonly string[] staticDirections = { "Static N","Static NW","Static W","Static SW","Static S","Static SE","Static E","Static NE" };
    public static readonly string[] runDirection = {"Run N","Run NW","Run W","Run SW","Run S","Run SE","Run E","Run NE"  };
    private Animator _animator;
    private int lastDirection;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if (_animator==null)
        {
            Debug.Log("Animator is null");
        }
    }

    public void SetDirection(Vector2 dirrection)
    {
        string[] dirrectionArray = null;
        if (dirrection.magnitude<0.01f)
        {
            dirrectionArray = staticDirections;
        }
        else
        {
            dirrectionArray = runDirection;
            lastDirection = DirectionToIndex(dirrection);
        }
        _animator.Play(dirrectionArray[lastDirection]);
    }

    private int DirectionToIndex(Vector2 dirrection)
    {
        var normDir = dirrection.normalized;
        var step = 360f / 8;
        var halfstep = step / 2;
        var angle = Vector2.SignedAngle(Vector2.up, normDir);
        angle += halfstep;
        if (angle < 0)
        {
            angle += 360;
        }
        var stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
