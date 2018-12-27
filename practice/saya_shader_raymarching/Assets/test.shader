Shader "Unlit/mini"
 {
     Properties
     {
         _MainTex ("Texture", 2D) = "white" {}
     }
     SubShader
     {
         Tags { "RenderType"="Opaque" }
         LOD 100
         Cull Off
 
         Pass
         {
             CGPROGRAM
             #pragma vertex vert_img
             #pragma fragment frag
             #include "UnityCG.cginc"
 
             sampler2D _MainTex;
             float4 _MainTex_ST;
 
 			fixed4 frag(v2f_img i) : SV_Target
             {
                 return i.uv.xxxx;
                 //fixed4(i.uv.x, i.uv.x, i.uv.x, i.uv.x)
             }
             ENDCG
         }
     }
 }