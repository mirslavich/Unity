using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] private CinemachineVirtualCameraBase cameraBase;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject playerPrefab;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
       var player= Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
       cameraBase.Follow = player.transform;
    }
}
