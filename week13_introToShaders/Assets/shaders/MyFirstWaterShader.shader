// name of the shader as it will appear in Unity Editor
Shader "Custom/Water/MyFirstWaterShader"
{  
    // the "public variables" that get exposed to the material
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _WaveHeight ("Wave Height", Float) = 0.5
        _WaveFrequency ("Wave Frequency", Float) = 2.0
    }
    // where we actually start writing code? almost, kind of
    SubShader
    {
        // Unity-specific stuff to help Unity optimize this shader
        Tags { "RenderType"="Opaque" }
        // LOD = level of detail... higher numbers tell Unity this is a more $$$ shader
        LOD 100

        // "Pass" is like an update loop for your shader
        // fewer passes is better and more optimized ("single-pass" vs multi-pass)
        Pass
        {
            // "CGPROGRAM" marks the start of HLSL code (HLSL used to be called CG)
            CGPROGRAM
            // "pragma" means compiler directive... setting variables / binding stuff
            #pragma vertex vert // = "the vertex program is called VERT"
            #pragma fragment frag // = "the fragment program is called FRAG"
            // make fog work
            #pragma multi_compile_fog // = "make fog work"

            #include "UnityCG.cginc" // .cginc = other CG shader code Unity wrote?

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            // you must declare "twins" that correspond to your Properties
            float _WaveHeight;
            float _WaveFrequency;

            // VERTEX PROGRAM
            v2f vert (appdata v)
            {
                v2f o;
                // add sine wave to vertex position, to make it bumpy
                // float4 = Vector4 (4th number is special thing Unity uses)
                v.vertex += float4( 0, sin( (_Time.z + v.vertex.x + v.vertex.z) * _WaveFrequency ) * _WaveHeight, 0, 0); // _Time is like Time.time
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                // "+ float2(_Time.y, 0)" scrolls the texture by making the UV values larger
                fixed4 col = tex2D(_MainTex, i.uv + float2(_Time.y, 0) );
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
