Shader "Unlit/451Shader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _NormalMap("Normal Map", 2D) = "bump" {}
        MyColor ("Color", Color) = (1,1,1,1)

    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex MyVert
            #pragma fragment MyFrag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv     : TEXCOORD0; // safe because default Unity meshes have UVs
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv     : TEXCOORD0;
            };

            uniform float4x4 MyXformMat;
            sampler2D _MainTex;
            uniform fixed4 MyColor;

            v2f MyVert(appdata v)
            {
                v2f o;
                float4 worldPos = mul(MyXformMat, v.vertex);
                o.vertex = mul(UNITY_MATRIX_VP, worldPos);
                o.uv = v.uv; // pass mesh UVs directly
                return o;
            }

            fixed4 MyFrag(v2f i) : SV_Target
            {
                fixed4 texCol = tex2D(_MainTex, i.uv);
                return texCol * MyColor;
            }
            ENDCG
        }
    }
}