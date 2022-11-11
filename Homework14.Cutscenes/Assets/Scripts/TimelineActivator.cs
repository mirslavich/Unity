using UnityEngine;
using UnityEngine.Playables;

public class TimelineActivator : MonoBehaviour
{
    private PlayableDirector _director;
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        _director = GetComponent<PlayableDirector>();
        if (_director==null)
        {
            print("Playable Direction is null");
        }
        _playerController.OnDeadEvent += ActivePlayable;
    }

    private void ActivePlayable()
    {
        print("Play death");
        _director.Play();
    }
}
