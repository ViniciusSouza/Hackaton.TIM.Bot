// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:Toony Colors Pro 2/Mobile,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9361,x:34654,y:32967,varname:node_9361,prsc:2|emission-7716-OUT;n:type:ShaderForge.SFN_Tex2d,id:6618,x:31166,y:32454,ptovrint:False,ptlb:HeadBase,ptin:_HeadBase,varname:node_6618,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:283,x:31166,y:32652,ptovrint:False,ptlb:BaseColor,ptin:_BaseColor,varname:node_283,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:8837,x:31963,y:32566,varname:node_8837,prsc:2|A-6618-RGB,B-283-RGB;n:type:ShaderForge.SFN_LightVector,id:370,x:31427,y:32839,varname:node_370,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:5199,x:31487,y:33056,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:5783,x:31657,y:32874,varname:node_5783,prsc:2,dt:1|A-370-OUT,B-5199-OUT;n:type:ShaderForge.SFN_Posterize,id:6097,x:32232,y:32833,varname:node_6097,prsc:2|IN-7783-OUT,STPS-4467-OUT;n:type:ShaderForge.SFN_Slider,id:4467,x:31640,y:33093,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_4467,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Tex2d,id:3173,x:30638,y:33368,ptovrint:False,ptlb:Olhos Fechados Bravos,ptin:_OlhosFechadosBravos,varname:node_3173,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5518,x:30638,y:33585,ptovrint:False,ptlb:Olhos Fechados,ptin:_OlhosFechados,varname:_OlhosFechadosBracos_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4064,x:30638,y:33818,ptovrint:False,ptlb:Olhos Abertos Bravos,ptin:_OlhosAbertosBravos,varname:_OlhosFechados_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3555,x:30638,y:34045,ptovrint:False,ptlb:Olhos Abertos,ptin:_OlhosAbertos,varname:_OlhosAbertosBravos_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_SwitchProperty,id:3810,x:31021,y:32987,ptovrint:False,ptlb:Bravo,ptin:_Bravo,varname:node_3810,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2889-OUT,B-5651-OUT;n:type:ShaderForge.SFN_Vector1,id:2889,x:30594,y:32963,varname:node_2889,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:5651,x:30594,y:33027,varname:node_5651,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:2476,x:31544,y:33797,varname:node_2476,prsc:2|A-3810-OUT,B-5531-OUT,GT-2327-OUT,EQ-5466-OUT,LT-5466-OUT;n:type:ShaderForge.SFN_Vector1,id:5531,x:30594,y:33099,varname:node_5531,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:2327,x:30826,y:33368,varname:node_2327,prsc:2|A-3173-RGB,B-3173-A;n:type:ShaderForge.SFN_Append,id:5466,x:30826,y:33585,varname:node_5466,prsc:2|A-5518-RGB,B-5518-A;n:type:ShaderForge.SFN_If,id:5178,x:31544,y:34018,varname:node_5178,prsc:2|A-3810-OUT,B-5531-OUT,GT-8266-OUT,EQ-5566-OUT,LT-5566-OUT;n:type:ShaderForge.SFN_Append,id:8266,x:30826,y:33818,varname:node_8266,prsc:2|A-4064-RGB,B-4064-A;n:type:ShaderForge.SFN_Append,id:5566,x:30826,y:34045,varname:node_5566,prsc:2|A-3555-RGB,B-3555-A;n:type:ShaderForge.SFN_Tex2d,id:2077,x:30646,y:34323,ptovrint:False,ptlb:Boca Fechada Brava,ptin:_BocaFechadaBrava,varname:node_2077,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6202,x:30649,y:34611,ptovrint:False,ptlb:Boca Fechada,ptin:_BocaFechada,varname:_BocaFechadaBrava_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7524,x:30647,y:34886,ptovrint:False,ptlb:Boca Aberta Brava,ptin:_BocaAbertaBrava,varname:_BocaFechada_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7107,x:30647,y:35165,ptovrint:False,ptlb:Boca Aberta,ptin:_BocaAberta,varname:_BocaAbertaBrava_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:9228,x:30855,y:34323,varname:node_9228,prsc:2|A-2077-RGB,B-2077-A;n:type:ShaderForge.SFN_Append,id:4678,x:30855,y:34571,varname:node_4678,prsc:2|A-6202-RGB,B-6202-A;n:type:ShaderForge.SFN_Append,id:2101,x:30876,y:34869,varname:node_2101,prsc:2|A-7524-RGB,B-7524-A;n:type:ShaderForge.SFN_Append,id:1012,x:30860,y:35165,varname:node_1012,prsc:2|A-7107-RGB,B-7107-A;n:type:ShaderForge.SFN_If,id:1616,x:31544,y:34236,varname:node_1616,prsc:2|A-3810-OUT,B-5531-OUT,GT-9228-OUT,EQ-4678-OUT,LT-4678-OUT;n:type:ShaderForge.SFN_If,id:2805,x:31544,y:34479,varname:node_2805,prsc:2|A-3810-OUT,B-5531-OUT,GT-2101-OUT,EQ-1012-OUT,LT-1012-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:3363,x:32371,y:34412,ptovrint:False,ptlb:Mover Boca,ptin:_MoverBoca,varname:node_3363,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2889-OUT,B-5651-OUT;n:type:ShaderForge.SFN_If,id:576,x:32330,y:34049,varname:node_576,prsc:2|A-1140-OUT,B-5531-OUT,GT-1616-OUT,EQ-1616-OUT,LT-2805-OUT;n:type:ShaderForge.SFN_Time,id:4246,x:31616,y:33274,varname:node_4246,prsc:2;n:type:ShaderForge.SFN_Slider,id:5984,x:31479,y:33613,ptovrint:False,ptlb:Velocidade Bocas,ptin:_VelocidadeBocas,varname:node_5984,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.1,max:20;n:type:ShaderForge.SFN_Multiply,id:4091,x:31802,y:33432,varname:node_4091,prsc:2|A-4246-T,B-5984-OUT;n:type:ShaderForge.SFN_Sin,id:1140,x:31986,y:33432,varname:node_1140,prsc:2|IN-4091-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4363,x:32882,y:34236,varname:node_4363,prsc:2,cc1:3,cc2:-1,cc3:-1,cc4:-1|IN-9419-OUT;n:type:ShaderForge.SFN_OneMinus,id:4987,x:33156,y:34244,varname:node_4987,prsc:2|IN-4363-OUT;n:type:ShaderForge.SFN_If,id:8187,x:32337,y:33754,varname:node_8187,prsc:2|A-8743-OUT,B-2626-OUT,GT-2476-OUT,EQ-2476-OUT,LT-5178-OUT;n:type:ShaderForge.SFN_Vector1,id:2626,x:31873,y:33854,varname:node_2626,prsc:2,v1:0.95;n:type:ShaderForge.SFN_Multiply,id:8238,x:31968,y:33679,varname:node_8238,prsc:2|A-4246-T,B-7890-OUT;n:type:ShaderForge.SFN_Slider,id:7890,x:31479,y:33711,ptovrint:False,ptlb:Frequencia das picadas,ptin:_Frequenciadaspicadas,varname:node_7890,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.1,max:5;n:type:ShaderForge.SFN_Sin,id:8743,x:32166,y:33647,varname:node_8743,prsc:2|IN-8238-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4050,x:32585,y:33810,varname:node_4050,prsc:2,cc1:3,cc2:-1,cc3:-1,cc4:-1|IN-8187-OUT;n:type:ShaderForge.SFN_Lerp,id:4743,x:32877,y:33449,varname:node_4743,prsc:2|A-8187-OUT,B-8837-OUT,T-9448-OUT;n:type:ShaderForge.SFN_Lerp,id:5954,x:33195,y:33630,varname:node_5954,prsc:2|A-9419-OUT,B-4743-OUT,T-4987-OUT;n:type:ShaderForge.SFN_Multiply,id:7716,x:33056,y:32984,varname:node_7716,prsc:2|A-6097-OUT,B-5954-OUT;n:type:ShaderForge.SFN_If,id:9419,x:32556,y:34226,varname:node_9419,prsc:2|A-3363-OUT,B-5531-OUT,GT-576-OUT,EQ-576-OUT,LT-1616-OUT;n:type:ShaderForge.SFN_RemapRange,id:7783,x:31850,y:32832,varname:node_7783,prsc:2,frmn:0,frmx:1,tomn:0.9,tomx:1|IN-5783-OUT;n:type:ShaderForge.SFN_OneMinus,id:9448,x:32767,y:33638,varname:node_9448,prsc:2|IN-4050-OUT;proporder:6618-283-4467-3810-3363-7890-5984-3173-5518-4064-3555-2077-6202-7524-7107;pass:END;sub:END;*/

Shader "Shader Forge/Shader_HeadSF" {
    Properties {
        _HeadBase ("HeadBase", 2D) = "white" {}
        _BaseColor ("BaseColor", Color) = (1,1,1,1)
        _Ramp ("Ramp", Range(0, 10)) = 0
        [MaterialToggle] _Bravo ("Bravo", Float ) = -1
        [MaterialToggle] _MoverBoca ("Mover Boca", Float ) = -1
        _Frequenciadaspicadas ("Frequencia das picadas", Range(0.1, 5)) = 0.1
        _VelocidadeBocas ("Velocidade Bocas", Range(0.1, 20)) = 0.1
        _OlhosFechadosBravos ("Olhos Fechados Bravos", 2D) = "white" {}
        _OlhosFechados ("Olhos Fechados", 2D) = "white" {}
        _OlhosAbertosBravos ("Olhos Abertos Bravos", 2D) = "white" {}
        _OlhosAbertos ("Olhos Abertos", 2D) = "white" {}
        _BocaFechadaBrava ("Boca Fechada Brava", 2D) = "white" {}
        _BocaFechada ("Boca Fechada", 2D) = "white" {}
        _BocaAbertaBrava ("Boca Aberta Brava", 2D) = "white" {}
        _BocaAberta ("Boca Aberta", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 2.0
            uniform float4 _TimeEditor;
            uniform sampler2D _HeadBase; uniform float4 _HeadBase_ST;
            uniform float4 _BaseColor;
            uniform float _Ramp;
            uniform sampler2D _OlhosFechadosBravos; uniform float4 _OlhosFechadosBravos_ST;
            uniform sampler2D _OlhosFechados; uniform float4 _OlhosFechados_ST;
            uniform sampler2D _OlhosAbertosBravos; uniform float4 _OlhosAbertosBravos_ST;
            uniform sampler2D _OlhosAbertos; uniform float4 _OlhosAbertos_ST;
            uniform fixed _Bravo;
            uniform sampler2D _BocaFechadaBrava; uniform float4 _BocaFechadaBrava_ST;
            uniform sampler2D _BocaFechada; uniform float4 _BocaFechada_ST;
            uniform sampler2D _BocaAbertaBrava; uniform float4 _BocaAbertaBrava_ST;
            uniform sampler2D _BocaAberta; uniform float4 _BocaAberta_ST;
            uniform fixed _MoverBoca;
            uniform float _VelocidadeBocas;
            uniform float _Frequenciadaspicadas;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float node_2889 = (-1.0);
                float node_5651 = 1.0;
                float node_5531 = 0.0;
                float node_9419_if_leA = step(lerp( node_2889, node_5651, _MoverBoca ),node_5531);
                float node_9419_if_leB = step(node_5531,lerp( node_2889, node_5651, _MoverBoca ));
                float _Bravo_var = lerp( node_2889, node_5651, _Bravo );
                float node_1616_if_leA = step(_Bravo_var,node_5531);
                float node_1616_if_leB = step(node_5531,_Bravo_var);
                float4 _BocaFechada_var = tex2D(_BocaFechada,TRANSFORM_TEX(i.uv0, _BocaFechada));
                float4 node_4678 = float4(_BocaFechada_var.rgb,_BocaFechada_var.a);
                float4 _BocaFechadaBrava_var = tex2D(_BocaFechadaBrava,TRANSFORM_TEX(i.uv0, _BocaFechadaBrava));
                float4 node_1616 = lerp((node_1616_if_leA*node_4678)+(node_1616_if_leB*float4(_BocaFechadaBrava_var.rgb,_BocaFechadaBrava_var.a)),node_4678,node_1616_if_leA*node_1616_if_leB);
                float4 node_4246 = _Time + _TimeEditor;
                float node_576_if_leA = step(sin((node_4246.g*_VelocidadeBocas)),node_5531);
                float node_576_if_leB = step(node_5531,sin((node_4246.g*_VelocidadeBocas)));
                float node_2805_if_leA = step(_Bravo_var,node_5531);
                float node_2805_if_leB = step(node_5531,_Bravo_var);
                float4 _BocaAberta_var = tex2D(_BocaAberta,TRANSFORM_TEX(i.uv0, _BocaAberta));
                float4 node_1012 = float4(_BocaAberta_var.rgb,_BocaAberta_var.a);
                float4 _BocaAbertaBrava_var = tex2D(_BocaAbertaBrava,TRANSFORM_TEX(i.uv0, _BocaAbertaBrava));
                float4 node_576 = lerp((node_576_if_leA*lerp((node_2805_if_leA*node_1012)+(node_2805_if_leB*float4(_BocaAbertaBrava_var.rgb,_BocaAbertaBrava_var.a)),node_1012,node_2805_if_leA*node_2805_if_leB))+(node_576_if_leB*node_1616),node_1616,node_576_if_leA*node_576_if_leB);
                float4 node_9419 = lerp((node_9419_if_leA*node_1616)+(node_9419_if_leB*node_576),node_576,node_9419_if_leA*node_9419_if_leB);
                float node_8187_if_leA = step(sin((node_4246.g*_Frequenciadaspicadas)),0.95);
                float node_8187_if_leB = step(0.95,sin((node_4246.g*_Frequenciadaspicadas)));
                float node_5178_if_leA = step(_Bravo_var,node_5531);
                float node_5178_if_leB = step(node_5531,_Bravo_var);
                float4 _OlhosAbertos_var = tex2D(_OlhosAbertos,TRANSFORM_TEX(i.uv0, _OlhosAbertos));
                float4 node_5566 = float4(_OlhosAbertos_var.rgb,_OlhosAbertos_var.a);
                float4 _OlhosAbertosBravos_var = tex2D(_OlhosAbertosBravos,TRANSFORM_TEX(i.uv0, _OlhosAbertosBravos));
                float node_2476_if_leA = step(_Bravo_var,node_5531);
                float node_2476_if_leB = step(node_5531,_Bravo_var);
                float4 _OlhosFechados_var = tex2D(_OlhosFechados,TRANSFORM_TEX(i.uv0, _OlhosFechados));
                float4 node_5466 = float4(_OlhosFechados_var.rgb,_OlhosFechados_var.a);
                float4 _OlhosFechadosBravos_var = tex2D(_OlhosFechadosBravos,TRANSFORM_TEX(i.uv0, _OlhosFechadosBravos));
                float4 node_2476 = lerp((node_2476_if_leA*node_5466)+(node_2476_if_leB*float4(_OlhosFechadosBravos_var.rgb,_OlhosFechadosBravos_var.a)),node_5466,node_2476_if_leA*node_2476_if_leB);
                float4 node_8187 = lerp((node_8187_if_leA*lerp((node_5178_if_leA*node_5566)+(node_5178_if_leB*float4(_OlhosAbertosBravos_var.rgb,_OlhosAbertosBravos_var.a)),node_5566,node_5178_if_leA*node_5178_if_leB))+(node_8187_if_leB*node_2476),node_2476,node_8187_if_leA*node_8187_if_leB);
                float4 _HeadBase_var = tex2D(_HeadBase,TRANSFORM_TEX(i.uv0, _HeadBase));
                float3 emissive = (floor((max(0,dot(lightDirection,i.normalDir))*0.1+0.9) * _Ramp) / (_Ramp - 1)*lerp(node_9419,lerp(node_8187,float4((_HeadBase_var.rgb*_BaseColor.rgb),0.0),(1.0 - node_8187.a)),(1.0 - node_9419.a))).rgb;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Toony Colors Pro 2/Mobile"
    CustomEditor "ShaderForgeMaterialInspector"
}
