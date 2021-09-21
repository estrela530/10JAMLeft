using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    Vector3 objectPoint;    //�u���b�N�̃|�W�V�����ϊ��p
    Vector3 screenPoint;    //�u���b�N�̃X�N���[���|�W�V����

    bool clickedObject;     //�N���b�N���ꂽ�Ƃ���Ƀu���b�N�����邩

    Vector3 currentMousePos;    //�}�E�X�|�W�V�����i�[�p(�O�t���[��)
    Vector3 previousMousePos;   //�}�E�X�|�W�V�����i�[�p(���݃t���[��)

    GameObject clickGameObject; //�N���b�N�����I�u�W�F�N�g���擾

    // Start is called before the first frame update
    void Start()
    {
        objectPoint = transform.position;   //������
        clickedObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Mathf.Approximately(Time.timeScale,0f))
        //{
        //    return;
        //}

        //���݂̃t���[���̃}�E�X�|�W�V�����i�[
        currentMousePos = Input.mousePosition;

        //�N���b�N������
        if (Input.GetMouseButtonDown(0))
        {
            //�N���b�N������Ƀ��C���΂�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            //�u���b�N������ꍇ
            if(Physics.Raycast(ray,out hit))
            {
                clickGameObject = hit.collider.gameObject;
                clickedObject = true;
            }
        }

        //�L�[�𗣂����炻���Ƀu���b�N��z�u
        if (Input.GetMouseButtonUp(0))
        {
            clickedObject = false;
        }

        if (clickedObject&&this.gameObject.name == clickGameObject.name)
        {

            //Block�̍��W�����[���h����X�N���[����
            objectPoint = Camera.main.WorldToScreenPoint(transform.position);

            //Block�̃|�W�V�������}�E�X�̃x�N�g�����ړ�����
            screenPoint = new Vector3(
                (objectPoint + (currentMousePos - previousMousePos)).x,
                (objectPoint + (currentMousePos - previousMousePos)).y,
                objectPoint.z);

            //Block�̍��W���X�N���[�����烏�[���h��
            objectPoint = Camera.main.ScreenToWorldPoint(screenPoint);

        }
        //�u���b�N�̃|�W�V�����ɕω������蓖��
        transform.position = objectPoint;

        //�O�̃t���[���̃}�E�X�|�W�V�����i�[
        previousMousePos = Input.mousePosition;
    }
}
