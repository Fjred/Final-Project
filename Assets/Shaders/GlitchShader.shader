Shader "Custom/GlitchShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Intensity ("Intensity", Range(0, 1)) = 0.5
    }

    SubShader {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Intensity;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 color = tex2D(_MainTex, i.uv);
                float r = tex2D(_MainTex, i.uv + float2(_Intensity, 0)).r;
                float g = tex2D(_MainTex, i.uv + float2(-_Intensity, 0)).g;
                float b = tex2D(_MainTex, i.uv + float2(0, _Intensity)).b;
                return fixed4(r, g, b, color.a);
            }
            ENDCG
        }
    }
}
