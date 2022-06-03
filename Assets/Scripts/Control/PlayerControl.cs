using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Player _playerTemplate;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if(eventData.delta.x > 0)
            {
                _playerTemplate.transform.position += Vector3.right;
            }
            else
            {
                _playerTemplate.transform.position += Vector3.left;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
