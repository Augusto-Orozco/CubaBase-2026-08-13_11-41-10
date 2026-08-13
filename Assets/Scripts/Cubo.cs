using UnityEngine;
using UnityEngine.InputSystem;

public class Cubo1 : MonoBehaviour
{
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private Rigidbody _rb;
    public float speed = 5f;
    public float jumpHeight = 2f;
    private Vector3 _jumpUp;
    private bool isGrounded = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _jumpUp = Vector3.up * jumpHeight;
    }

    // Update is called once per frame
    void Update()
    {
        // TRUE: Está presionado en el frame
        if (_moveAction.IsPressed())
        {
            var movVal = _moveAction.ReadValue<Vector2>();
            var mov = new Vector3(movVal.x, 0f, movVal.y);
            mov *= (speed * Time.deltaTime);
            transform.Translate(mov, Space.World);
        }
            // TRUE:Solo el frame en el que fue presionado
            if (_jumpAction.WasPressedThisFrame() && isGrounded){
            _rb.AddForce(_jumpUp, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
