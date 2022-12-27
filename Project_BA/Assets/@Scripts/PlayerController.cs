using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private	KeyCode	_jumpKeyCode = KeyCode.Space;
	//[SerializeField]
	//private	CameraController	cameraController;
	private	Movement3D _movement3D;
	private Animator _animator;

	private bool _isMove = false;
	private bool _isJump = false;

	private void Awake()
	{
		Init();
	}

	private void Update()
	{
		// x, z축 방향으로 이동
		float x = Input.GetAxisRaw("Horizontal");	// 방향키 좌/우 움직임
		float z = Input.GetAxisRaw("Vertical");		// 방향키 위/아래 움직임
		
		if (x != 0 || z != 0)
			_isMove = true;
		else
		{
			_isMove = false;
		}

		if (_isMove)
		{
			_movement3D.MoveTo(new Vector3(x, 0, z));
			_animator.Play("Move");
		}
		else
		{
			_animator.Play("Idle");
		}

		// y축 방향으로 뛰어오름
		if ( Input.GetKeyDown(_jumpKeyCode) )
		{
			_movement3D.JumpTo();
			_animator.Play("Jump");
		}

		// 카메라 x, y축 회전
		float mouseX = Input.GetAxis("Mouse X");	// 마우스 좌/우 움직임
		float mouseY = Input.GetAxis("Mouse Y");	// 마우스 위/아래 움직임

		//cameraController.RotateTo(mouseX, mouseY);
	}
	
	/// CharacterController 컴포넌트를 가지고 있는 게임오브젝트에서 호출 가능
	/// CharacterController 컴포넌트가 다른 오브젝트와 충돌했을 때 호출되는 유니티 이벤트 함수
	/// (Tip. 플레이어 캐릭터가 움직이고 있을 때만 호출된다)
	/// <param name="hit">플레이어 캐릭터에게 부딪힌 오브젝트 정보</param>
	//private void OnControllerColliderHit(ControllerColliderHit hit)
	//{
	//	// 부딪힌 오브젝트(hit)의 태그가 "Obstacle"이면
	//	if ( hit.transform.CompareTag("Obstacle") )
	//	{
	//		// 플레이어에게 부딪힌 오브젝트의 색상을 변경
	//		hit.transform.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
	//	}
	//}

	private void Init()
	{
		_movement3D = GetComponent<Movement3D>();
		_animator =  GetComponent<Animator>();
		
		SetMouseCursor();
	}

	private void SetMouseCursor()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
}

