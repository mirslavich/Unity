using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] float movementSpeed = 2f;
   [SerializeField] float sprintSpeed = 5f;
   [SerializeField] float rotationSpeed = 0.2f;
   [SerializeField] float animationBlendSpeed = 0.2f;
   [SerializeField] float jumpSpeed = 7f;
   private CharacterController controller;
   private Camera characterCamera;
   private Animator animator;
   private float rotationAngle = 0f;
   private float targetAnimationSpeed = 0f;
   [SerializeField] private float moveSpeed = 10f;
   private bool inputControl = false;
   private float speedY = 0f;
   private float gravity = -9.8f;
   private bool isJumping = false;
   private bool isSprint = true;
   private bool isAttack = false;

   public CharacterController Controller { get { return  controller= controller ?? GetComponent<CharacterController>(); } }
   public Camera CharacterCamera { get { return characterCamera = characterCamera ?? FindObjectOfType<Camera>(); } }
   public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

   private void Update()
   {
      //Death
      if (Input.GetKeyDown(KeyCode.P)&&inputControl)
      {
         CharacterAnimator.SetTrigger("Death");
         inputControl = false;
      }
      if (!inputControl)
      {
         return;
      }
      float vertical = Input.GetAxis("Vertical");
      float horizintal = Input.GetAxis("Horizontal");
      //Jump
      if (Input.GetButtonDown("Jump")&& !isJumping)
      {
         isJumping = true;
         CharacterAnimator.SetTrigger("Jump");
         speedY += jumpSpeed;
      }
      if (!Controller.isGrounded)
      {
         speedY += gravity * Time.deltaTime;
      }
      else if(speedY<0f)
      {
         speedY = 0;
      }
      CharacterAnimator.SetFloat("SpeedY",speedY/jumpSpeed);
      if (isJumping&&speedY<0f)
      {
         RaycastHit hit;
         if (Physics.Raycast(transform.position,Vector3.down,out hit,1f,LayerMask.GetMask("Default")))
         {
            isJumping = false;
            CharacterAnimator.SetTrigger("Land");
         }
      }
      //Attack
      if (Input.GetMouseButtonDown(0)&&!isAttack)
      {
         CharacterAnimator.SetTrigger("Attack");
         CharacterAnimator.SetInteger("AttackValue",Random.Range(1, 5));
      }
      //Movement
      isSprint = Input.GetKey(KeyCode.LeftShift);
      var movement = new Vector3(horizintal* moveSpeed, 0, vertical* moveSpeed);
      var rotateMovement = Quaternion.Euler(0, CharacterCamera.transform.rotation.eulerAngles.y, 0)*movement.normalized;
      var verticalMovement = Vector3.up * speedY;
      float currentSpeed = isSprint ? sprintSpeed : movementSpeed;
      Controller.Move((verticalMovement + rotateMovement * currentSpeed) * Time.deltaTime);
      if (rotateMovement.sqrMagnitude > 0f)
      {
         rotationAngle = Mathf.Atan2(rotateMovement.x, rotateMovement.z) * Mathf.Rad2Deg;
         targetAnimationSpeed = isSprint ? 1f : 0.5f;
      }
      else
      {
         targetAnimationSpeed = 0f;
      }
      CharacterAnimator.SetFloat("Speed",Mathf.Lerp(CharacterAnimator.GetFloat("Speed"),targetAnimationSpeed,animationBlendSpeed));
      var currentRatation = Controller.transform.rotation;
      var targetRatation = Quaternion.Euler(0f, rotationAngle, 0f);
      Controller.transform.rotation = Quaternion.Lerp(currentRatation, targetRatation, rotationSpeed);
   }
   private void OnSpawnSend()
   {
      inputControl = true;
   }
   private void MeleeAttackStart()
   {
      isAttack = true;
   }
   private void MeleeAttackEnd()
   {
      isAttack = false;
   }
}
