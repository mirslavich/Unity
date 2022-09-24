using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using GlobalEventManager;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject grenade;
    [SerializeField] private Camera aimCamera;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private float speedShell;
    [SerializeField] private float speedBall;
    [SerializeField] private float speedGrenade;
    [SerializeField] private float spread;
    private GameObject currectWeapon;

    private void Start()
    {
        GlobalEventMagager.WeaponInHand += ChoseWeapon;
    }

    private void ChoseWeapon(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Shell":
                currectWeapon = bullet;
               break;
            case "TennisBall":
                currectWeapon = ball;
                break;
            case "Grenade":
                currectWeapon = grenade;
                break;
            default:
                Debug.Log("Weapon is NULL"); 
                return;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currectWeapon==bullet)
            {
                ShootShell();
            }
            else if (currectWeapon==ball)
            {
                ShootTennisBall();
            }
            else if (currectWeapon==grenade)
            {
                ShootGrenade();
            }
        }
    }

    private void ShootShell()
    {
        Vector3 dirWihoutSpread = GetRayCastPoint() - spawnBullet.position;
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        var dirWithSpread = dirWihoutSpread + new Vector3(x, y, 0);
        var currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);
        currentBullet.transform.forward = dirWithSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized*speedShell,ForceMode.Impulse);
    }

    private void ShootTennisBall()
    {
        
        var currentBall = Instantiate(ball, spawnBullet.position, Quaternion.identity);
        currentBall.GetComponent<Rigidbody>().AddForce(GetRayCastPoint()*speedBall,ForceMode.Impulse);
    }
    private void ShootGrenade()
    {
        var direction = Quaternion.AngleAxis(25.0f, transform.forward)* transform.up;
        direction.Normalize();
        var currentGrenade = Instantiate(grenade, spawnBullet.position, Quaternion.identity);
        currentGrenade.GetComponent<Rigidbody>().AddForce(direction*speedGrenade , ForceMode.Impulse);
     }

    private Vector3 GetRayCastPoint()
    {
        var ray = aimCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(60);
        }
        return targetPoint;
    }
}
