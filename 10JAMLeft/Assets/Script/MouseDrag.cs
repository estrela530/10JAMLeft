using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseDrag : MonoBehaviour
{
    Vector3 objectPoint;    //�u���b�N�̃|�W�V�����ϊ��p
    Vector3 screenPoint;    //�u���b�N�̃X�N���[���|�W�V����

    public bool clickedObject { get; set; }     //�N���b�N���ꂽ�Ƃ���Ƀu���b�N�����邩

    Vector3 currentMousePos;    //�}�E�X�|�W�V�����i�[�p(�O�t���[��)
    Vector3 previousMousePos;   //�}�E�X�|�W�V�����i�[�p(���݃t���[��)

    GameObject clickGameObject; //�N���b�N�����I�u�W�F�N�g���擾

    public UnityEvent OnClickNow;

    public UnityEvent OnClickExit;


    // Start is called before the first frame update
    void Start()
    {
        objectPoint = transform.position;   //������
        clickedObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        //���݂̃t���[���̃}�E�X�|�W�V�����i�[
        currentMousePos = Input.mousePosition;

        //�N���b�N������
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            //�u���b�N������ꍇ
            if (Physics.Raycast(ray, out hit))
            {
                clickGameObject = hit.collider.gameObject;
                if (gameObject.name == clickGameObject.name)
                {
                    clickedObject = true;
                    OnClickNow.Invoke();
                }
            }
        }

        //�L�[�𗣂����炻���Ƀu���b�N��z�u
        if (Input.GetMouseButtonUp(0))
        {
            clickedObject = false;
            OnClickExit.Invoke();
            Cursor.lockState = CursorLockMode.None;
        }

        if (clickedObject)
        {
            if (Camera.main.WorldToViewportPoint(transform.position).x >= 0.45f)
            {
                clickedObject = false;
                OnClickExit.Invoke();
                Cursor.lockState = CursorLockMode.None;
                return;
            }

            Cursor.lockState = CursorLockMode.Confined;

            //Block�̍��W�����[���h����X�N���[����
            objectPoint = Camera.main.WorldToScreenPoint(transform.position);

            //Block�̃|�W�V�������}�E�X�̃x�N�g�����ړ�����
            screenPoint = new Vector3(
                (objectPoint + (currentMousePos - previousMousePos)).x,
                (objectPoint + (currentMousePos - previousMousePos)).y,
                objectPoint.z);

            //Block�̍��W���X�N���[�����烏�[���h��
            objectPoint = Camera.main.ScreenToWorldPoint(screenPoint);
            //�u���b�N�̃|�W�V�����ɕω������蓖��
            transform.position = objectPoint;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x,
                Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x,
                Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1, 0)).x), transform.position.y, transform.position.z);
        }
        //�O�̃t���[���̃}�E�X�|�W�V�����i�[
        previousMousePos = Input.mousePosition;
    }
}
