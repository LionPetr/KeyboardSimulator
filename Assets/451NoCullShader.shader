Shader "Unlit/451NoCullShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _NormalMap("Normal Map", 2D) = "bump" {}
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
                float4 tangent : TANGENT;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
                float3 tangentWS : TEXCOORD2;
                float3 binormalWS : TEXCOORD3;
            };

            uniform float4x4 MyXformMat;
            uniform sampler2D _MainTex;
            uniform sampler2D _NormalMap;
            uniform fixed4 MyColor;
            float4 _MainTex_ST;

            v2f MyVert(appdata v)
            {
                v2f o;

                // Apply your custom transform
                float4 worldPos = mul(MyXformMat, v.vertex);
                o.vertex = mul(UNITY_MATRIX_VP, worldPos);

                // UVs with tiling/offset
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                // Transform normal/tangent/binormal to world space
                float3 n = normalize(mul((float3x3)MyXformMat, v.normal));
                float3 t = normalize(mul((float3x3)MyXformMat, v.tangent.xyz));
                float3 b = cross(n, t) * v.tangent.w;

                o.normalWS = n;
                o.tangentWS = t;
                o.binormalWS = b;

                return o;
            }

            fixed4 MyFrag(v2f i) : SV_Target
            {
                fixed4 texCol = tex2D(_MainTex, i.uv) * MyColor;

                fixed3 normalTS = UnpackNormal(tex2D(_NormalMap, i.uv));

                float3 normalWS = normalize(
                    normalTS.x * i.tangentWS +
                    normalTS.y * i.binormalWS +
                    normalTS.z * i.normalWS
                );

                float3 lightDir = normalize(float3(0.3, 1, 0.2));
                float NdotL = max(dot(normalWS, lightDir), 0);

                fixed lighting = 0.2 + NdotL * 0.8; 
                return texCol * lighting;
            }

            ENDCG
        }
    }
}