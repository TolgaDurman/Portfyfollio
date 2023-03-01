using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] private Vector3Int m_StartPosition;
    [SerializeField] private Vector3Int m_CurrentPosition;
    [SerializeField] private MeshRenderer m_meshRenderer;
    [SerializeField] private Transform back,forward,top,bottom,left,right;
    private Color startColor;

    public Vector3Int CurrentPosition { get => m_CurrentPosition; set => m_CurrentPosition = value; }
    public Vector3Int StartPosition { get => m_StartPosition; }
    private bool isHovering;
    private void Awake()
    {
        startColor = m_meshRenderer.material.color;
    }

    public void Setup(Vector3Int start, float gap,
    Transform back,Transform forward,Transform top,Transform bottom,Transform left,Transform right)
    {
        m_StartPosition = start;
        transform.localPosition = (Vector3)start * gap;
        CurrentPosition = m_StartPosition;

        if(m_StartPosition.x == 0)
            Instantiate(left,this.left);
        else if(m_StartPosition.x == 2)
            Instantiate(right,this.right);
        if(m_StartPosition.y == 0)
            Instantiate(bottom,this.bottom);
        else if(m_StartPosition.y == 2)
            Instantiate(top,this.top);
        if(m_StartPosition.z == 0)
            Instantiate(back,this.back);
        else if(m_StartPosition.z == 2)
            Instantiate(forward,this.forward);
    }

    public void UpdateCurrentPosition(float gap)
    {
        Vector3 localPos = transform.localPosition;
        Vector3Int pos = new Vector3Int(Mathf.RoundToInt(localPos.x / gap), Mathf.RoundToInt(localPos.y / gap), Mathf.RoundToInt(localPos.z / gap));
        CurrentPosition = pos;
    }
    public void Hover(bool isHovering)
    {
        this.isHovering = isHovering;
        m_meshRenderer.material.color = isHovering ? Color.cyan : startColor;
    }
    private void LateUpdate()
    {
        if (isHovering)
        {
            isHovering = false;
            return;
        }
        Hover(isHovering);
    }
}
