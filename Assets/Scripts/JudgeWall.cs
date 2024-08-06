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
                Debug.Log("RoomAÇ©ÇÁRoomBÇ…à⁄ìÆÇµÇ‹Ç∑");
            }
            else {
                Debug.Log("RoomBÇ©ÇÁRoomAÇ…à⁄ìÆÇµÇ‹Ç∑");
            }
            // isInRoomAÇÃílÇêÿÇËë÷Ç¶ÇÈ
            GlobalVariables.isInRoomA = !GlobalVariables.isInRoomA;
            Debug.Log("isInRoomA toggled to: " + GlobalVariables.isInRoomA);

        }

        door.SmoothCloseMove();
    }
}
