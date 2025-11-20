Shader "Unlit/451Shader"
{
    Properties
    {
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
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            // uniforms (set from C#)
            uniform float4x4 MyXformMat;
            uniform fixed4 MyColor;

            v2f MyVert(appdata v)
            {
                v2f o;

                // apply your matrix
                float4 worldPos = mul(MyXformMat, v.vertex);

                // camera transform
                o.vertex = mul(UNITY_MATRIX_VP, worldPos);

                return o;
            }

            fixed4 MyFrag(v2f i) : SV_Target
            {
                return MyColor;
            }
            ENDCG
        }
    }
}