using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GrapInteration.cs와 Object Manipulator.cs 두 가지 스크립트 연동

// 손 추적을 기반으로 Hand Pointer를 업데이트 기능
public class GrabInteraction : MonoBehaviour
{
    [SerializeField] private GameObject handPointer;
    [SerializeField] private GameObject handPointer2;
    [SerializeField] private GameObject handPointer3;
    [SerializeField] private GameObject handPointer4;// 손 포인터
    //[SerializeField] private GameObject DrumStick;

    private float skeletonConfidence = 0.0001f; // 뼈대 자신감 / 0.0001f 최소값

    // Update is called once per frame
    void Update()
    {

        bool hasConfience = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.skeleton.confidence > skeletonConfidence;

        // 손의 추적 정보에서 스켈레톤의 신뢰도 > skeletonConfidence
        if (hasConfience)
        {
            var palmCenter = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.skeleton.joints[8]; // palm_center : 손의 중심
            var finger2 = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.skeleton.joints[12];
            var finger3 = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.skeleton.joints[16];
            var finger4 = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.skeleton.joints[20];
            //var stick = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.skeleton.joints[9];

            var depthEstimation = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.depth_estimation; // 깊이 추정 정보

            Vector3 positionPointer = ManoUtils.Instance.CalculateNewPositionDepth(palmCenter, depthEstimation); // 위에 두 가지 이용 -> 손 포인터의 위치 계산 
            Vector3 positionPointer2 = ManoUtils.Instance.CalculateNewPositionDepth(finger2, depthEstimation);
            Vector3 positionPointer3 = ManoUtils.Instance.CalculateNewPositionDepth(finger3, depthEstimation);
            Vector3 positionPointer4 = ManoUtils.Instance.CalculateNewPositionDepth(finger4, depthEstimation);
            //Vector3 positionPointer5 = ManoUtils.Instance.CalculateNewPositionDepth(stick, depthEstimation);

            handPointer.transform.position = positionPointer; // 계산된 위치로 손 포인터의 위치 이동
            handPointer.SetActive(true); // 손 포인터 활성화
            handPointer2.transform.position = positionPointer2; // 계산된 위치로 손 포인터의 위치 이동
            handPointer2.SetActive(true); // 손 포인터 활성화
            handPointer3.transform.position = positionPointer3; // 계산된 위치로 손 포인터의 위치 이동
            handPointer3.SetActive(true); // 손 포인터 활성화
            handPointer4.transform.position = positionPointer4; // 계산된 위치로 손 포인터의 위치 이동
            handPointer4.SetActive(true); // 손 포인터 활성화
            //DrumStick.transform.position = positionPointer5; // 계산된 위치로 손 포인터의 위치 이동
            //DrumStick.SetActive(true); // 손 포인터 활성화
        }

        // 손의 추적 정보에서 스켈레톤의 신뢰도 < skeletonConfidence
        // 신뢰도가 충분하지 않으면, 손 포인터와의 부모-자식 관계를 해제하고, 손 포인터를 비활성화
        else
        {
            handPointer.transform.DetachChildren();
            handPointer.SetActive(false);
            handPointer2.transform.DetachChildren();
            handPointer2.SetActive(false);
            handPointer3.transform.DetachChildren();
            handPointer3.SetActive(false);
            handPointer4.transform.DetachChildren();
            handPointer4.SetActive(false);
            //DrumStick.transform.DetachChildren();
            //DrumStick.SetActive(false);
        }
    }
}