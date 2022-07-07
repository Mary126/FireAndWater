using HTC.UnityPlugin.Vive;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlombaController : MonoBehaviour, IPointerClickHandler
{
    public ExtinguisherController extinguisherController;
    public void OnPointerClick(PointerEventData eventData)
    {
        var viveEventData = eventData as VivePointerEventData;
        if (viveEventData != null)
        {
            if (viveEventData.viveButton == ControllerButton.Trigger && viveEventData.viveRole.ToRole<HandRole>() == HandRole.LeftHand && extinguisherController.IsDragging == true)
            {
                extinguisherController.PlombaDestroyed = true;
                Destroy(gameObject);
            }
        }
    }
}
