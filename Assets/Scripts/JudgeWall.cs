using UnityEngine;

public class JudgeWall : MonoBehaviour
{
    [SerializeField]
    private SmoothMoveOnTrigger door;
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        UpdateColor();
    }

    void Update()
    {
        UpdateColor();
    }

    private void UpdateColor()
    {
        if (GlobalVariables.isClear)
        {
            objectRenderer.material.color = Color.black;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GlobalVariables.isInRoomA)
            {
                Debug.Log("RoomA����RoomB�Ɉړ����܂�");
            }
            else {
                Debug.Log("RoomB����RoomA�Ɉړ����܂�");
            }
            // isInRoomA�̒l��؂�ւ���
            GlobalVariables.isInRoomA = !GlobalVariables.isInRoomA;
            Debug.Log("isInRoomA toggled to: " + GlobalVariables.isInRoomA);

        }

        door.SmoothCloseMove();
    }

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            if (GlobalVariables.isClear) {
                GameManager.Instance.GameClear(other.gameObject);
                Debug.Log("�ړ������I�I�I�I�I");
            }
        }
    }
}
