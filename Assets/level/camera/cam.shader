Shader "Unlit/cam"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ActiveDeadEffect("Dead", Range(0,1)) = 0
        _PlayerPosition("Player",Vector) = (0,0,0)
        _Radius("Radius", float) = 5
    }
    SubShader
    {

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

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
            float _ActiveDeadEffect;
            float3 _PlayerPosition;
            float _Radius;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
            //step(radius,length(position - float2(0.5)))
            float circleShaper(float2 position, float radius){
                position = float2(position.x - 0.5,position.y - 0.5);
                return step(radius,length(position));
            }
            fixed4 frag (v2f i) : SV_Target
            {
                float4 col = tex2D(_MainTex,i.uv);

                col *= 1- circleShaper(_PlayerPosition.xy + i.uv,_Radius);
                return col;
            }
            ENDCG
        }
    }
}
