using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]

public class RaymarchCam : SceneViewFilter
{
    private Shader _shader;

    public Material _raymarchMaterial
    {
        get
        {
            if (!_raymarchMat && _shader)
            {
                _raymarchMat = new Material(_shader);
                _raymarchMat.hideFlags = HideFlags.HideAndDontSave;
            }

            return _raymarchMat;
        }
    }

    private Material _raymarchMat;

    public Camera _camera
    {
        get
        {
            if (!_cam)
            {
                _cam = GetComponent<Camera>();
            }
            return _cam;
        }
    }
    private Camera _cam;

    public Transform _directionalLight;
    [Range(0, 1)]
    public float _shadowIntensity;
    [Range(0, 1)]
    public Color _mainColor;
    public Color _secColor;
    public Color _skyColor;
    public int _iterations;
    public Vector3 _iterationOffsetRot;
    public Vector3 _globalPosition;
    public Vector3 _GlobalRotation;
    public float _smoothRadius;
    public Matrix4x4 _iterationTransform;

    [HideInInspector]
    public Matrix4x4 _globalTransform;


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
            _globalPosition,
            Quaternion.identity,
            Vector3.one);
        _globalTransform *= Matrix4x4.TRS(
            Vector3.zero,
            Quaternion.Euler(_GlobalRotation),
            Vector3.one);
        // Send the matrix to our shader
        _raymarchMaterial.SetMatrix("_globalTransform", _globalTransform.inverse);
        {
            Graphics.Blit(source, destination);
            return;
        }
        _raymarchMaterial.SetMatrix("_CamToWorld", _camera.cameraToWorldMatrix);
        _raymarchMaterial.SetFloat("_precision", _precision);
        _raymarchMaterial.SetFloat("_shadowIntensity", _shadowIntensity);
        _raymarchMaterial.SetFloat("_aoIntensity", _aoIntensity);
        _raymarchMaterial.SetColor("_secColor", _secColor);
        _raymarchMaterial.SetColor("_skyColor", _skyColor);
        _raymarchMaterial.SetFloat("_smoothRadius", _smoothRadius);
        _raymarchMaterial.SetTexture("_MainTex", source);

        GL.PushMatrix();
        GL.LoadOrtho();
        _raymarchMaterial.SetPass(0);
        GL.Begin(GL.QUADS);

        //BL
        GL.MultiTexCoord2(0, 0.0f, 0.0f);
        GL.Vertex3(0.0f, 0.0f, 3.0f);

        //BR
        GL.MultiTexCoord2(0, 1.0f, 0.0f);
        GL.Vertex3(1.0f, 0.0f, 2.0f);

        //TR
        GL.MultiTexCoord2(0, 1.0f, 1.0f);
        GL.Vertex3(1.0f, 1.0f, 1.0f);

        //TL
        GL.MultiTexCoord2(0, 0.0f, 1.0f);
        GL.Vertex3(0.0f, 1.0f, 0.0f);

        GL.End();
        GL.PopMatrix();
    {
        Matrix4x4 frustrum = Matrix4x4.identity;
        float fov = Mathf.Tan((cam.fieldOfView * 0.5f) * Mathf.Deg2Rad);

        Vector3 goUp = Vector3.up * fov;
        Vector3 goRight = Vector3.right * fov * cam.aspect;

        Vector3 TL = (-Vector3.forward - goRight + goUp);
        Vector3 TR = (-Vector3.forward + goRight + goUp);
        Vector3 BL = (-Vector3.forward - goRight - goUp);
        Vector3 BR = (-Vector3.forward + goRight - goUp);

        frustrum.SetRow(0, TL);
        frustrum.SetRow(1, TR);
        frustrum.SetRow(2, BR);
        frustrum.SetRow(3, BL);


        return frustrum;
    }
}