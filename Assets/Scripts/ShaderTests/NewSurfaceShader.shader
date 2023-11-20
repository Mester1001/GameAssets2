Shader "Custom/OutlineShader"
{
    Properties
    {
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _Outline ("Outline width", Range (.002,.03)) = .005
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB)", 2D) = "white" { }
    }

    SubShader
    {
        Tags { "Queue" = "Overlay" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        Cull Front
        ZWrite On
        ZTest LEqual
        ColorMask RGB
        BlendOp Add

        Pass
        {
            SetTexture [_MainTex]
            {
                combine primary
            }
        }

        Pass
        {
            Name "OUTLINE"
            Tags { "LightMode" = "Always" }

            Cull Front
            ZWrite On
            ZTest LEqual
            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha
            BlendOp Add

            CGPROGRAM
            #pragma exclude_renderers gles xbox360 ps3
            #pragma vertex vert
            ENDCG

            /*SetTexture [_MainTex]
            {
                combine outline
            }
            {
                constantColor [_OutlineColor]
            }*/
        }
    }

    Fallback "Diffuse"
}
