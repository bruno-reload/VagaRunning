﻿Shader "Unlit/Bacground"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _H ("Horizontal speed", float) = 0
        _V("Vertical speed", Range(-1, 1)) = 0
        _StopAnimation("Srop",Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vertex
            #pragma fragment fragment

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _H;
            float _V;
            float time = 0;
            float _StopAnimation;
            float lestStep;

            v2f vertex (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 fragment (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, float2(i.uv.x + _H,i.uv.y + _V/4));
                return col;
            }
            ENDCG
        }
    }
}
