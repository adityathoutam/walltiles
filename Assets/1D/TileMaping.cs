using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TileMaping : MonoBehaviour
{
    public GameObject Tile;
    public GameObject Panel;
    public Dropdown dropdown;
    public Canvas canvas;
    GridLayoutGroup m_CellSize;
    List<RaycastResult> results = new List<RaycastResult>();
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    Sprite Image;
    private void Awake()
    {
        Populate();
        dropdown.onValueChanged.AddListener(delegate
        {
            ChangeCellSize(dropdown);
        });
        m_Raycaster =canvas.GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
        m_CellSize = Panel.GetComponent<GridLayoutGroup>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            m_Raycaster.Raycast(m_PointerEventData, results);
        }
        CellSelected();
    }
    void CellSelected()
    {
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.name == "Element 0" || result.gameObject.name == "Element 1" ||
               result.gameObject.name == "Element 2" || result.gameObject.name == "Element 3")
            {
                Image = result.gameObject.GetComponent<Image>().sprite;
            }
            if (Image != null && result.gameObject.name == "Tile(Clone)")
            {
                result.gameObject.GetComponent<Image>().sprite = Image;
            }
        }
    }
    void ChangeCellSize(Dropdown dropdown)
    {
        if (dropdown.value == 0)
        {
            //2X3
            Vector2 size = m_CellSize.cellSize;
            size.x = 519;
            size.y = 530;
            m_CellSize.cellSize = size;
        }
        if (dropdown.value == 1)
        {
            //2X2
            Vector2 size = m_CellSize.cellSize;
            size.x = 784;
            size.y = 530;
            m_CellSize.cellSize = size;
        }
        if (dropdown.value == 2)
        {
            //2 X 4
            Vector2 size = m_CellSize.cellSize;
            size.x = 386.5f;
            size.y = 530f;
            m_CellSize.cellSize = size;
        }
        if (dropdown.value == 3)
        {
            //1 X 3
            Vector2 size = m_CellSize.cellSize;
            size.x = 519f;
            size.y = 1080f;
            m_CellSize.cellSize = size;
        }
    }
    void Populate()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(Tile, Panel.transform);
        }
    }
}
