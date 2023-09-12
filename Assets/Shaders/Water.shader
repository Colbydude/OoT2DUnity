Shader "Unlit/Water"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Alpha ("Alpha", Range(0, 1)) = 0.7
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float2 uvOpaque : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Alpha;
            sampler2D _CameraOpaqueTexture;
            float4 _CameraOpaqueTexture_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex.xyz);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uvOpaque = TRANSFORM_TEX(mul(UNITY_MATRIX_MV, v.vertex).xy, _CameraOpaqueTexture);

                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                half4 col = tex2D(_MainTex, i.uv);
                half2 tiledUvs = i.uvOpaque * 100.0;
                half2 displacement = half2(
                    cos(_Time.x * 5.0 * tiledUvs.x + tiledUvs.y) * 0.001,
                    cos(_Time.x + tiledUvs.x + tiledUvs.y) * 0.001
                );
                half4 refraction = tex2D(_CameraOpaqueTexture, i.uvOpaque + displacement);

                return lerp(half4(col.rgb, 1.0), refraction, 1.0 - _Alpha);
            }
            ENDHLSL
        }
    }
}
