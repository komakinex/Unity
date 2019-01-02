Shader "Unlit/RaymarchingPractice#1"
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

            float2 rot(float2 p, float a){
                return float2(p.x * cos(a) - p.y * sin(a), p.x * sin(a) + p.y * cos(a));
            }
            float mod(float x, float y){
                return x - floor(x / y) * y;
            }
            float2 mod(float2 x, float2 y){
                return x - floor(x / y) * y;
            }
            float3 mod(float3 x, float3 y){
                return x - floor(x / y) * y;
            }
             float4 mod(float4 x, float4 y){
                return x - floor(x / y) * y;
            }

            float dSphere(float3 p){
                return length(p) - 1;
            }

            //map関数を作って球を描けるようにする
            float map(float3 p){
                float3 q = p;
                //動かしてみる
                q.xy += sin(_Time.y + UNITY_PI /2);
                float s = dSphere(q - float3(.5, .5, 0));
                return s;
            }

            // //立体感を出すために法線を使う
            // float3 normal(float3 p){
            //     float EPSILON = 0.0001;
            //     return normalize(float3( 
            //         map(float3(p.x + EPSILON, p.y, p.z)) - map(float3(p.x - EPSILON, p.y, p.z)),
            //         map(float3(p.x, p.y + EPSILON, p.z)) - map(float3(p.x, p.y - EPSILON, p.z)),
            //         map(float3(p.x, p.y, p.z + EPSILON)) - map(float3(p.x, p.y, p.z - EPSILON))
            //      ));
            // }
            //軽い法線
            float3 normal(float3 pos){
                float2 e = float2(1., -1.)*0.5773*.0001;
                return normalize(e.xyy * map(pos + e.xyy) +
                                 e.yyx * map(pos + e.yyx) +
                                 e.yxy * map(pos + e.yxy) +
                                 e.xxx * map(pos + e.xxx));
            }
 

 			fixed4 frag(v2f_img i) : SV_Target
             {
            
                 //座標の初期設定
                 float2 uv = 2 * i.uv -1;
                 float2 uv2 = uv + .5 * sin(_Time.y) + .5;
                 uv2.x += sin(floor(4 * uv2.y) - (_Time.y));
                 uv2.x += cos(floor(4 * uv2.x) - (_Time.y));
                //  float3 p = float3(uv, 0);
                 float3 p = float3(uv + step(.4, frac(_Time.y)) * (uv2 - uv), 0);
                 //色の初期設定
                 fixed4 col = (1).xxxx;

                 //カメラ
                 float3 cam = float3(0, 0, -3);

                 //上、前、横軸
                 float3 up = float3(0, 1, 0);
                 float3 fwd = normalize(-cam);
                 float3 side = normalize(cross(up, fwd));

                 //レイの初期座標を決める
                 float3 rayPos = cam;
                 //レイの進む向きを決める
                 float3 rayDir = p.x * side + p.y * up + fwd;


                 //レイマーチするループ
                 float d = 0;
                 float3 N;
                 for(int j=0; j<16; j++){
                     d = map(rayPos);
                     if(d<0.0001){
                         //衝突した場合法線を算出
                         N = normal(rayPos);
                         break;
                     }
                     rayPos += d * rayDir;
                 }

                 //レイが何かに衝突した（この場合はmap関数で決められた形）
                 //ライトと法線の角度を元にライティングする
                 if(d<0.0001){
                     float3 L = normalize(float3(-1, 0.5, -.2));
                     float3 Lcol = float3(2.6, 2.3, 1.4);
                     return fixed4(pow(dot(L, N) * .5 + .5, 3) * lerp(Lcol, 1.2 * Lcol, 1 * (.1 + .2 * N)), 1);//half Lambert
                 }



                 //背景（レイが衝突しなかった）
                 uv = rot(uv, _Time.y);//背景を動かす
                 uv += sin(_Time.y);
                //  col.rg = uv;
                //  col.b = pow(1-dot(uv, uv),.2);

                 col.rgb = float3(1.2 + pow(abs(uv + dot(uv, uv)), 2), pow(1 - dot(uv2, uv2), .2));
                 col.rgb = lerp(col.rgb, 1 - col.rgb, frac(_Time.y));


                //  pow(dot(L, N) * .5 + .5, 3) * lerp(Lcol, 1.2 * Lcol, 1 * (.1 + .2 * N)), 1





                 return col;

                 //i.uv.xxxx = fixed4(i.uv.x, i.uv.x, i.uv.x, i.uv.x)
             }
             ENDCG
         }
     }
 }