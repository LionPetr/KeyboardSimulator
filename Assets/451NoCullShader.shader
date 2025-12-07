Shader "Unlit/451NoCullShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        MyColor("Color", Color) = (1,1,1,1)
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex MyVert
            #pragma fragment MyFrag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
                float3 worldPos : TEXCOORD2;
            };

            uniform float4x4 MyXformMat;
            uniform sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 MyColor;

            v2f MyVert(appdata v)
            {
                v2f o;

                float4 worldPos = mul(MyXformMat, v.vertex);
                o.vertex = mul(UNITY_MATRIX_VP, worldPos);
                o.worldPos = worldPos;

                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                o.normalWS = normalize(mul((float3x3)MyXformMat, v.normal));

                return o;
            }

            fixed4 MyFrag(v2f i) : SV_Target
            {
                fixed4 texCol = tex2D(_MainTex, i.uv) * MyColor;

                float3 lightDir = normalize(float3(0.3, 1, 0.2));

                float NdotL = max(dot(i.normalWS, lightDir), 0);

                float lighting = 0.2 + NdotL * 0.8;

                return texCol * lighting;
            }

            ENDCG
        }
    }
}