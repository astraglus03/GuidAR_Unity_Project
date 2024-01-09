using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{                                                // private -> public 
    [SerializeField] public Renderer aRObject; // 
    [SerializeField] public Renderer snare;
    [SerializeField] public Renderer crash;
    [SerializeField] public Renderer basedrum;
    [SerializeField] public Renderer basetom;
    int count;
    //private Material myMaterial;
    //private Renderer renderer;

    private Renderer objectPrefab1; // 생성할 오브젝트 프리팹
    private Renderer objectPrefab2; // 생성할 오브젝트 프리팹
    private Renderer objectPrefab3; // 생성할 오브젝트 프리팹
    private Renderer objectPrefab4; // 생성할 오브젝트 프리팹
    private Renderer objectPrefab5; // 생성할 오브젝트 프리팹
    private Renderer[] spawnedObjects;
    Vector3 jointPosition;

    [SerializeField]
    private Button startBtn;

    private AudioSource audioSource;
    public AudioClip[] audioClips; // 여러 오디오 클립을 담을 배열
    private int currentClipIndex = 0;

    [SerializeField] private Material[] materials = new Material[6];

    private bool buttonClicked;
    //private bool firstObjectColorChanged = false;


    public void Start()
    {

        count = 0;
        buttonClicked = false;

        audioSource = GetComponent<AudioSource>();
        // objectRenderer 초기화
        //basedrum = GetComponent<Renderer>();

        // 정적으로 오디오 클립 할당
        audioClips = new AudioClip[1];
        audioClips[0] = Resources.Load<AudioClip>("60guidesound"); // 실제 오디오 클립 경로 및 이름으로 대체
                                                                   //audioClips[1] = Resources.Load<AudioClip>("Snare-Drum-Hit-Level-4a-www.fesliyanstudios.com"); // 다른 오디오 클립 경로 및 이름으로 대체
                                                                   //audioClips[2] = Resources.Load<AudioClip>("Floor-Tom-Drum-Hit-Level-6A-www.fesliyanstudios.com");
                                                                   //audioClips[3] = Resources.Load<AudioClip>("Hi-Hat-Closed-Hit-B1-www.fesliyanstudios.com");
                                                                   //audioClips[4] = Resources.Load<AudioClip>("China-Cymbal-Crash-Level-6A-www.fesliyanstudios.com");

        //spawnedObjects = new List<Renderer>(); // 생성된 오브젝트들을 저장할 리스트
        spawnedObjects = new Renderer[5];


        startBtn.onClick.AddListener(AudioOn);
    }

    // Update is called once per frame
    public void Update()
    {
        ManomotionManager.Instance.ShouldCalculateGestures(true); // 

        GestureInfo gestureInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info; // 
        ManoGestureTrigger currentGesture = gestureInfo.mano_gesture_trigger;


        if (currentGesture == ManoGestureTrigger.CLICK) // 
        {
            if (count == 4)
            {
                objectPrefab5 = SpawnObject5();

                count = 5;

            }
            if (count == 3)
            {
                objectPrefab4 = SpawnObject4();

                count = 4;
            }
            if (count == 2)
            {
                objectPrefab1 = SpawnObject1();
                

                count = 3;
            }
            if (count == 1)
            {
                objectPrefab2 = SpawnObject2();

                count = 2;
                //objectPrefab1.material = materials[1];
            }

            if (count == 0)
            {
                
                objectPrefab3 = SpawnObject3();
                count = 1;
            }

        }


        // 첫 번째 오브젝트의 색상을 변경하는 로직 수정
        if (buttonClicked == true)
        {
            Invoke("ChangeObjectColors6", 0.0f);
            Invoke("ChangeObjectColors1", 0.25f); // 1초 후 ChangeObjectColors 함수 실행 하이햇,베이스 off

            Invoke("ChangeObjectColors2", 0.5f);//하이햇 on
            Invoke("ChangeObjectColors3", 0.75f);//하이햇 off

            Invoke("ChangeObjectColors4", 1.0f);//하이햇,스네어 on
            Invoke("ChangeObjectColors5", 1.25f);//하이햇,스네어 off

            Invoke("ChangeObjectColors2", 1.5f);//하이햇 on
            Invoke("ChangeObjectColors3", 1.75f);//해이햇 off

            Invoke("ChangeObjectColors6", 2.0f);
            Invoke("ChangeObjectColors1", 2.25f);

            Invoke("ChangeObjectColors2", 2.5f);
            Invoke("ChangeObjectColors3", 2.75f);

            Invoke("ChangeObjectColors4", 3.0f);
            Invoke("ChangeObjectColors5", 3.25f);

            Invoke("ChangeObjectColors2", 3.5f);
            Invoke("ChangeObjectColors3", 3.75f);

            Invoke("ChangeObjectColors6", 4.0f);
            Invoke("ChangeObjectColors1", 4.25f);

            Invoke("ChangeObjectColors2", 4.5f);
            Invoke("ChangeObjectColors3", 4.75f);

            Invoke("ChangeObjectColors4", 5.0f);
            Invoke("ChangeObjectColors5", 5.25f);

            Invoke("ChangeObjectColors2", 5.5f);
            Invoke("ChangeObjectColors3", 5.75f);

            Invoke("ChangeObjectColors6", 6.0f);
            Invoke("ChangeObjectColors1", 6.25f);

            Invoke("ChangeObjectColors2", 6.5f);
            Invoke("ChangeObjectColors3", 6.75f);

            Invoke("ChangeObjectColors4", 7.0f);
            Invoke("ChangeObjectColors5", 7.25f);

            Invoke("ChangeObjectColors2", 7.5f);
            Invoke("ChangeObjectColors3", 7.75f);

            Invoke("ChangeObjectColors6", 8.0f);
            Invoke("ChangeObjectColors1", 8.25f);

            Invoke("ChangeObjectColors2", 8.5f);
            Invoke("ChangeObjectColors3", 8.75f);

            Invoke("ChangeObjectColors4", 9.0f);
            Invoke("ChangeObjectColors5", 9.25f);

            Invoke("ChangeObjectColors2", 9.5f);
            Invoke("ChangeObjectColors3", 9.75f);

            Invoke("ChangeObjectColors6", 10.0f);
            Invoke("ChangeObjectColors1", 10.25f);

            Invoke("ChangeObjectColors2", 10.5f);
            Invoke("ChangeObjectColors3", 10.75f);

            Invoke("ChangeObjectColors4", 11.0f);
            Invoke("ChangeObjectColors5", 11.25f);

            Invoke("ChangeObjectColors2", 11.5f);
            Invoke("ChangeObjectColors3", 11.75f);

            Invoke("ChangeObjectColors6", 12.0f);
            Invoke("ChangeObjectColors1", 12.25f);

            Invoke("ChangeObjectColors2", 12.5f);
            Invoke("ChangeObjectColors3", 12.75f);

            Invoke("ChangeObjectColors4", 13.0f);
            Invoke("ChangeObjectColors5", 13.25f);

            Invoke("ChangeObjectColors2", 13.5f);
            Invoke("ChangeObjectColors3", 13.75f);

            Invoke("ChangeObjectColors6", 14.0f);
            Invoke("ChangeObjectColors1", 14.25f);

            Invoke("ChangeObjectColors2", 14.5f);
            Invoke("ChangeObjectColors3", 14.75f);

            Invoke("ChangeObjectColors4", 15.0f);
            Invoke("ChangeObjectColors5", 15.25f);

            Invoke("ChangeObjectColors2", 15.5f);
            Invoke("ChangeObjectColors3", 15.75f);

            Invoke("ChangeObjectColors6", 16.0f);
            Invoke("ChangeObjectColors1", 16.25f);

            Invoke("ChangeObjectColors2", 16.5f);
            Invoke("ChangeObjectColors3", 16.75f);

            Invoke("ChangeObjectColors4", 17.0f);
            Invoke("ChangeObjectColors5", 17.25f);

            Invoke("ChangeObjectColors2", 17.5f);
            Invoke("ChangeObjectColors3", 17.75f);

            Invoke("ChangeObjectColors6", 18.0f);
            Invoke("ChangeObjectColors1", 18.25f);

            Invoke("ChangeObjectColors2", 18.5f);
            Invoke("ChangeObjectColors3", 18.75f);

            Invoke("ChangeObjectColors4", 19.0f);
            Invoke("ChangeObjectColors5", 19.25f);

            Invoke("ChangeObjectColors2", 19.5f);
            Invoke("ChangeObjectColors3", 19.75f);

            Invoke("ChangeObjectColors6", 20.0f);
            Invoke("ChangeObjectColors1", 20.25f);

            Invoke("ChangeObjectColors2", 20.5f);
            Invoke("ChangeObjectColors3", 20.75f);

            Invoke("ChangeObjectColors4", 21.0f);
            Invoke("ChangeObjectColors5", 21.25f);

            Invoke("ChangeObjectColors2", 21.5f);
            Invoke("ChangeObjectColors3", 21.75f);

            Invoke("ChangeObjectColors6", 22.0f);
            Invoke("ChangeObjectColors1", 22.25f);

            Invoke("ChangeObjectColors2", 22.5f);
            Invoke("ChangeObjectColors3", 22.75f);

            Invoke("ChangeObjectColors4", 23.0f);
            Invoke("ChangeObjectColors5", 23.25f);

            Invoke("ChangeObjectColors2", 23.5f);
            Invoke("ChangeObjectColors3", 23.75f);

            Invoke("ChangeObjectColors6", 24.0f);
            Invoke("ChangeObjectColors1", 24.25f);

            Invoke("ChangeObjectColors2", 24.5f);
            Invoke("ChangeObjectColors3", 24.75f);

            Invoke("ChangeObjectColors4", 25.0f);
            Invoke("ChangeObjectColors5", 25.25f);

            Invoke("ChangeObjectColors2", 25.5f);
            Invoke("ChangeObjectColors3", 25.75f);

            Invoke("ChangeObjectColors6", 26.0f);
            Invoke("ChangeObjectColors1", 26.25f);

            Invoke("ChangeObjectColors2", 26.5f);
            Invoke("ChangeObjectColors3", 26.75f);

            Invoke("ChangeObjectColors4", 27.0f);
            Invoke("ChangeObjectColors5", 27.25f);

            Invoke("ChangeObjectColors2", 27.5f);
            Invoke("ChangeObjectColors3", 27.75f);

            Invoke("ChangeObjectColors6", 28.0f);
            Invoke("ChangeObjectColors1", 28.25f);

            Invoke("ChangeObjectColors2", 28.5f);
            Invoke("ChangeObjectColors3", 28.75f);

            Invoke("ChangeObjectColors4", 29.0f);
            Invoke("ChangeObjectColors5", 29.25f);

            Invoke("ChangeObjectColors2", 29.5f);
            Invoke("ChangeObjectColors3", 29.75f);

            Invoke("ChangeObjectColors6", 30.0f);
            Invoke("ChangeObjectColors1", 30.25f);

            Invoke("ChangeObjectColors2", 30.5f);
            Invoke("ChangeObjectColors3", 30.75f);
            /*
            Invoke("ChangeObjectColors4", 31.0f);
            Invoke("ChangeObjectColors5", 31.25f);

            Invoke("ChangeObjectColors2", 31.5f);
            Invoke("ChangeObjectColors3", 31.75f);

            Invoke("ChangeObjectColors6", 32.0f);
            Invoke("ChangeObjectColors1", 32.25f);

            Invoke("ChangeObjectColors2", 32.5f);
            Invoke("ChangeObjectColors3", 32.75f);

            Invoke("ChangeObjectColors4", 33.0f);
            Invoke("ChangeObjectColors5", 33.25f);

            Invoke("ChangeObjectColors2", 33.5f);
            Invoke("ChangeObjectColors3", 33.75f);

            Invoke("ChangeObjectColors6", 34.0f);
            Invoke("ChangeObjectColors1", 34.25f);

            Invoke("ChangeObjectColors2", 34.5f);
            Invoke("ChangeObjectColors3", 34.75f);

            Invoke("ChangeObjectColors4", 35.0f);
            Invoke("ChangeObjectColors5", 35.25f);

            Invoke("ChangeObjectColors2", 35.5f);
            Invoke("ChangeObjectColors3", 35.75f);

            Invoke("ChangeObjectColors6", 36.0f);
            Invoke("ChangeObjectColors1", 36.25f);

            Invoke("ChangeObjectColors2", 36.5f);
            Invoke("ChangeObjectColors3", 36.75f);

            Invoke("ChangeObjectColors4", 37.0f);
            Invoke("ChangeObjectColors5", 37.25f);

            Invoke("ChangeObjectColors2", 37.5f);
            Invoke("ChangeObjectColors3", 37.75f);

            Invoke("ChangeObjectColors6", 38.0f);
            Invoke("ChangeObjectColors1", 38.25f);

            Invoke("ChangeObjectColors2", 38.5f);
            Invoke("ChangeObjectColors3", 38.75f);

            Invoke("ChangeObjectColors4", 39.0f);
            Invoke("ChangeObjectColors5", 39.25f);

            Invoke("ChangeObjectColors2", 39.5f);
            Invoke("ChangeObjectColors3", 39.75f);

            Invoke("ChangeObjectColors6", 2.4f);
            Invoke("ChangeObjectColors1", 2.7f);

            Invoke("ChangeObjectColors2", 3.0f);
            Invoke("ChangeObjectColors3", 3.3f);

            Invoke("ChangeObjectColors4", 3.6f);
            Invoke("ChangeObjectColors5", 3.9f);

            Invoke("ChangeObjectColors2", 4.2f);
            Invoke("ChangeObjectColors3", 4.5f);

            Invoke("ChangeObjectColors6", 2.4f);
            Invoke("ChangeObjectColors1", 2.7f);

            Invoke("ChangeObjectColors2", 3.0f);
            Invoke("ChangeObjectColors3", 3.3f);

            Invoke("ChangeObjectColors4", 3.6f);
            Invoke("ChangeObjectColors5", 3.9f);

            Invoke("ChangeObjectColors2", 4.2f);
            Invoke("ChangeObjectColors3", 4.5f);

            */
            buttonClicked = false;
        }




        /*
        // renderer = GetComponent<Renderer>(); // 
        if (buttonClicked == true)
        {
            objectPrefab1.material = materials[1];

            //buttonClicked = false;
        }
        */


    }

    // 1초 후 실행될 함수
    void ChangeObjectColors1() // 하이햇, 베이스 off
    {
        objectPrefab1.material = materials[0]; // objectPrefab1의 색상을 materials[0]으로 변경
        objectPrefab4.material = materials[3];
    }
    void ChangeObjectColors2() // 하이햇 on
    {
        objectPrefab1.material = materials[5]; // objectPrefab1의 색상을 materials[0]으로 변경
    }

    void ChangeObjectColors3() // 하이햇 off
    {
        objectPrefab1.material = materials[0];// objectPrefab1의 색상을 materials[0]으로 변경
    }
    void ChangeObjectColors4() // 하이햇, 스네어 on
    {
        objectPrefab1.material = materials[5]; // objectPrefab1의 색상을 materials[0]으로 변경
        objectPrefab2.material = materials[5];
    }

    void ChangeObjectColors5() // 하이햇, 스네어 off
    {
        objectPrefab1.material = materials[0]; // objectPrefab1의 색상을 materials[0]으로 변경
        objectPrefab2.material = materials[1];
    }
    void ChangeObjectColors6()//하이햇, 베이스 on
    {
        objectPrefab1.material = materials[5]; // objectPrefab1의 색상을 materials[0]으로 변경
        objectPrefab4.material = materials[5];
    }

    public Renderer SpawnObject1()
    {
        ManomotionManager.Instance.ShouldCalculateSkeleton3D(true);

        TrackingInfo trackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;

        float depthEstimation = trackingInfo.depth_estimation; // 
                                                               // 
        jointPosition = ManoUtils.Instance.CalculateNewPositionSkeletonJointDepth(new Vector3(trackingInfo.skeleton.joints[8].x,
            trackingInfo.skeleton.joints[8].y, trackingInfo.skeleton.joints[8].z), depthEstimation);

        //Instantiate(aRObject, jointPosition, Quaternion.identity);

        Renderer spawnObject = Instantiate(aRObject, jointPosition, Quaternion.identity);

        //aRObject = Instantiate(aRObject, jointPosition, Quaternion.identity);
        spawnObject.transform.rotation = Quaternion.Euler(-90, 0, 0); //  회전

        Handheld.Vibrate();
        //spawnedObjects.Add(spawnObject); // 생성된 오브젝트를 리스트에 추가
        //spawnedObjects[0] = spawnObject;

        //objectPrefab1 = spawnObject;

        return spawnObject;

    }



    public Renderer SpawnObject2()
    {
        ManomotionManager.Instance.ShouldCalculateSkeleton3D(true);

        TrackingInfo trackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;

        float depthEstimation = trackingInfo.depth_estimation; // 
                                                               // 
        Vector3 jointPosition = ManoUtils.Instance.CalculateNewPositionSkeletonJointDepth(new Vector3(trackingInfo.skeleton.joints[8].x,
            trackingInfo.skeleton.joints[8].y, trackingInfo.skeleton.joints[8].z), depthEstimation);

        Renderer spawnObject = Instantiate(snare, jointPosition, Quaternion.identity);

        //aRObject = Instantiate(aRObject, jointPosition, Quaternion.identity);
        spawnObject.transform.rotation = Quaternion.Euler(90, 0, 0); //  회전

        Handheld.Vibrate();
        //spawnedObjects.Add(spawnObject); // 생성된 오브젝트를 리스트에 추가
        //objectPrefab2 = spawnObject;

        return spawnObject;
    }
    public Renderer SpawnObject3()
    {
        ManomotionManager.Instance.ShouldCalculateSkeleton3D(true);

        TrackingInfo trackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;

        float depthEstimation = trackingInfo.depth_estimation; // 
                                                               // 
        Vector3 jointPosition = ManoUtils.Instance.CalculateNewPositionSkeletonJointDepth(new Vector3(trackingInfo.skeleton.joints[8].x,
            trackingInfo.skeleton.joints[8].y, trackingInfo.skeleton.joints[8].z), depthEstimation);

        Renderer spawnObject = Instantiate(crash, jointPosition, Quaternion.identity);

        //aRObject = Instantiate(aRObject, jointPosition, Quaternion.identity);
        spawnObject.transform.rotation = Quaternion.Euler(-90, 0, 0); //  회전


        Handheld.Vibrate();
        //spawnedObjects.Add(spawnObject); // 생성된 오브젝트를 리스트에 추가
        //objectPrefab3 = spawnObject;

        return spawnObject;
    }
    public Renderer SpawnObject4()
    {
        ManomotionManager.Instance.ShouldCalculateSkeleton3D(true);

        TrackingInfo trackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;

        float depthEstimation = trackingInfo.depth_estimation; //          
                                                               // 
        Vector3 jointPosition = ManoUtils.Instance.CalculateNewPositionSkeletonJointDepth(new Vector3(trackingInfo.skeleton.joints[8].x,
            trackingInfo.skeleton.joints[8].y, trackingInfo.skeleton.joints[8].z), depthEstimation);

        Quaternion cameraRotation = Camera.main.transform.rotation; // 카메라 회전시켜도 영향 안 받기 위해, 카메라 위치 받아옴
        Renderer spawnObject = Instantiate(basedrum, jointPosition, Quaternion.identity);
        //spawnedObject.transform.rotation = Quaternion.Euler(0, 0, 0); //  회전
        spawnObject.transform.rotation = Quaternion.Euler(0, cameraRotation.eulerAngles.y - 5, 0); // y축 기준 왼쪽으로 5도 회전

        Handheld.Vibrate();
        //spawnedObjects.Add(spawnObject); // 생성된 오브젝트를 리스트에 추가
        //objectPrefab4 = spawnObject;

        return spawnObject;
    }

    public Renderer SpawnObject5()
    {
        ManomotionManager.Instance.ShouldCalculateSkeleton3D(true);

        TrackingInfo trackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;

        float depthEstimation = trackingInfo.depth_estimation; // 
                                                               // 
        Vector3 jointPosition = ManoUtils.Instance.CalculateNewPositionSkeletonJointDepth(new Vector3(trackingInfo.skeleton.joints[8].x,
            trackingInfo.skeleton.joints[8].y, trackingInfo.skeleton.joints[8].z), depthEstimation);

        Renderer spawnObject = Instantiate(basetom, jointPosition, Quaternion.identity);

        //aRObject = Instantiate(aRObject, jointPosition, Quaternion.identity);
        spawnObject.transform.rotation = Quaternion.Euler(-90, 0, 0); //  회전


        Handheld.Vibrate();

        //spawnedObjects.Add(spawnObject); // 생성된 오브젝트를 리스트에 추가
        //objectPrefab5 = spawnObject;

        return spawnObject;
    }

    public void AudioOn()
    {
        // 새 오브젝트를 생성하고 spawnedObjects 배열에 추가
        buttonClicked = true;
        //objectPrefab1.material = materials[1];

        //spawnedObjects[0].material = materials[1];
        //spawnedObjects[0].material = materials[1];
        //SpawnObject1().material = materials[1];


        /*
        // 첫 번째 에셋의 렌더러 컴포넌트의 material을 변경합니다.
        firstSpawnedObject = spawnObjectScript.spawnedObjects[0];
        firstSpawnedObject.material = materials[1]; // 여기에서 원하는 색상으로 변경할 수 있습니다.
        */


        /* 1. 0번 오디오만 재생
        // 첫 번째 오디오 클립 가져오기*/

        AudioClip firstAudioClip = audioClips[0];

        // 현재 재생 중인 오디오 소스의 클립을 첫 번째 오디오 클립으로 설정하고 재생
        audioSource.clip = firstAudioClip;
        audioSource.Play();

    }
}
// 이 방식은 버튼을 한번 누르면 0번 오디오만, 또 한번 누르면 1번 오디오만 재생됨. 다시 누르면 0번 오디오 재생
/* 2. 버튼 누를 때마다, 오디오 인덱스 하나씩 증가
// 현재 재생 중인 오디오 소스의 클립을 현재 인덱스의 오디오 클립으로 설정하고 재생
audioSource.clip = audioClips[currentClipIndex];
audioSource.Play();

// 다음에 재생할 오디오 클립의 인덱스 업데이트
currentClipIndex = (currentClipIndex + 1) % audioClips.Length;

*/



//audioSource.Stop(); // 현재 재생 중인 오디오를 정지하고 초기화
// 현재 재생 중인 오디오 소스의 클립을 설정하고 재생
//audioSource.clip = audioClips[currentClipIndex];
//audioSource.Play();
// 현재 클립의 길이만큼 대기 후 다음 클립을 재생하는 함수 호출
//Invoke("PlayNextClip", audioSource.clip.length); // 연속으로 호출할 때 필요.

// 다음에 재생할 오디오 클립의 인덱스 업데이트
//currentClipIndex = (currentClipIndex + 1) % audioClips.Length;
//  }
/*
    private void PlayNextClip()
    {
        // 다음에 재생할 오디오 클립의 인덱스 업데이트
        currentClipIndex = (currentClipIndex + 1) % audioClips.Length;

        // 다음에 재생할 오디오 클립을 설정하고 재생
        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play();

        // 현재 클립의 길이만큼 대기 후 다음 클립을 재생하는 함수 호출
        Invoke("PlayNextClip", audioSource.clip.length);
    }

}
*/