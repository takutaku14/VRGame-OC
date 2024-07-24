using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotationSpeed = 90f; // 1•bŠÔ‚É90“x‰ñ“]
    private bool isVerticalRotation = false;

    private bool contactLeft = false;
    private bool contactRight = false;
    private bool contactForward = false;
    private bool contactBackward = false;

    private Quaternion targetRotation;
    private bool isRotating = false;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    void Update()
    {
        // “ü—Í‚Ìæ“¾
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // ‰ñ“]‚ªŠ®—¹‚µ‚Ä‚¢‚È‚¢ê‡‚ÍA‰ñ“]ˆ—‚ğs‚¤
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
            return;
        }

        // ã‰º•ûŒü‚Ì‰ñ“]‚Ìˆ—
        if (Input.GetKeyDown(KeyCode.I))
        {
            targetRotation = Quaternion.Euler(transform.eulerAngles.x - 90, transform.eulerAngles.y, transform.eulerAngles.z);
            isVerticalRotation = true;
            isRotating = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            targetRotation = Quaternion.Euler(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z);
            isVerticalRotation = true;
            isRotating = true;
        }

        // ã‰º•ûŒü‚Ì‰ñ“]‚ª‚È‚¢ê‡‚Ì‚İ¶‰E•ûŒü‚Ì‰ñ“]‚ğ‹–‰Â
        if (!isVerticalRotation)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
                isRotating = true;
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
                isRotating = true;
            }
        }

        // ã‰º•ûŒü‚Ì‰ñ“]‚ğƒŠƒZƒbƒg
        if (Input.GetKey(KeyCode.N))
        {
            targetRotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
            isVerticalRotation = false;
            isRotating = true;
        }

        // ã‰º¶‰E‚Ì‰ñ“]‚ğƒŠƒZƒbƒg
        if (Input.GetKey(KeyCode.M))
        {
            targetRotation = Quaternion.identity;
            isVerticalRotation = false;
            isRotating = true;
        }

        // ˆÚ“®‚ÌŒvZ
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;

        // ƒJƒƒ‰‚Ì…•½‰ñ“]‚ğl—¶‚µ‚ÄˆÚ“®•ûŒü‚ğŒvZ‚·‚é
        Quaternion horizontalRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        movement = horizontalRotation * movement;

        // ÚG•ûŒü‚ÉŠî‚Ã‚¢‚ÄˆÚ“®‚ğ§ŒÀ
        if ((contactLeft && horizontal < 0) || (contactRight && horizontal > 0))
        {
            movement.x = 0;
        }

        if ((contactForward && vertical > 0) || (contactBackward && vertical < 0))
        {
            movement.z = 0;
        }

        // ƒJƒƒ‰‚ÌˆÊ’u‚ğXV
        transform.position += movement;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 contactNormal = contact.normal;

            // ƒJƒƒ‰‚Ì‰ñ“]‚ğl—¶‚µ‚ÄÚG•ûŒü‚ğXV
            contactNormal = transform.InverseTransformDirection(contactNormal);

            if (Vector3.Dot(contactNormal, Vector3.left) > 0.5f)
            {
                contactLeft = true;
                Debug.Log("ÚG: ¶");
            }
            if (Vector3.Dot(contactNormal, Vector3.right) > 0.5f)
            {
                contactRight = true;
                Debug.Log("ÚG: ‰E");
            }
            if (Vector3.Dot(contactNormal, Vector3.forward) > 0.5f)
            {
                contactForward = true;
                Debug.Log("ÚG: ‘O");
            }
            if (Vector3.Dot(contactNormal, Vector3.back) > 0.5f)
            {
                contactBackward = true;
                Debug.Log("ÚG: Œã‚ë");
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        contactLeft = false;
        contactRight = false;
        contactForward = false;
        contactBackward = false;
        Debug.Log("ÚG‰ğœ");
    }
}
