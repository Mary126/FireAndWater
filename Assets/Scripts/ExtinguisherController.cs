using HTC.UnityPlugin.Vive;
using UnityEngine.EventSystems;
using UnityEngine;

public class ExtinguisherController : MonoBehaviour, IPointerClickHandler
{
    public GameObject Water;
    public GameObject Hand;
    public bool IsDragging = false;
    public bool PlombaDestroyed = false;
    public bool IsWatering = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        var viveEventData = eventData as VivePointerEventData;
        if (viveEventData != null)
        {
            if (viveEventData.viveButton == ControllerButton.Trigger && viveEventData.viveRole.ToRole<HandRole>() == HandRole.RightHand && !IsDragging)
            {
                transform.SetParent(Hand.transform);
                IsDragging = true;
            }
            else if (viveEventData.viveButton == ControllerButton.Trigger && viveEventData.viveRole.ToRole<HandRole>() == HandRole.RightHand && IsDragging)
            {
                transform.SetParent(null);
                IsDragging = false;
            }
            if (PlombaDestroyed == true && IsDragging == true && IsWatering == false && viveEventData.viveButton == ControllerButton.Grip)
            {
                Water.SetActive(true);
                IsWatering = true;
            }
            else if (viveEventData.viveButton == ControllerButton.Grip && IsWatering == true)
            {
                Water.SetActive(false);
                IsWatering = false;
            }
        }
    }
}
