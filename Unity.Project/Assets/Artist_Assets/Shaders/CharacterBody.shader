// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:Toony Colors Pro 2/Mobile,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:34344,y:32297,varname:node_3138,prsc:2|emission-3549-OUT,olwid-7922-OUT,olcol-3034-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:33076,y:32216,ptovrint:False,ptlb:BaseColor,ptin:_BaseColor,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:8274,x:33201,y:32549,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_8274,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:974b4e90202059347924d761dc91dbcb,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:2681,x:32673,y:33166,ptovrint:False,ptlb:Outline_Width,ptin:_Outline_Width,varname:node_2681,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1601015,max:1;n:type:ShaderForge.SFN_Divide,id:7922,x:33546,y:33144,varname:node_7922,prsc:2|A-2681-OUT,B-3467-OUT;n:type:ShaderForge.SFN_Vector1,id:3467,x:32830,y:33264,varname:node_3467,prsc:2,v1:10;n:type:ShaderForge.SFN_Multiply,id:7776,x:33573,y:32768,varname:node_7776,prsc:2|A-8274-RGB,B-107-OUT;n:type:ShaderForge.SFN_Slider,id:107,x:32673,y:33057,ptovrint:False,ptlb:OutlineValue,ptin:_OutlineValue,varname:node_107,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8703384,max:1;n:type:ShaderForge.SFN_LightVector,id:7941,x:33399,y:31398,varname:node_7941,prsc:2;n:type:ShaderForge.SFN_Dot,id:3989,x:33672,y:31365,varname:node_3989,prsc:2,dt:1|A-7941-OUT,B-9876-OUT;n:type:ShaderForge.SFN_NormalVector,id:9876,x:33399,y:31522,prsc:2,pt:False;n:type:ShaderForge.SFN_Append,id:4544,x:34317,y:31406,varname:node_4544,prsc:2|A-9126-OUT,B-9126-OUT;n:type:ShaderForge.SFN_Tex2d,id:8637,x:34546,y:31439,ptovrint:False,ptlb:Diffuse_Ramp,ptin:_Diffuse_Ramp,varname:node_8637,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4544-OUT;n:type:ShaderForge.SFN_Multiply,id:3549,x:33892,y:32189,varname:node_3549,prsc:2|A-3603-OUT,B-178-OUT;n:type:ShaderForge.SFN_RemapRange,id:9126,x:34131,y:31406,varname:node_9126,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:0.99|IN-3989-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:3603,x:33924,y:31996,varname:node_3603,prsc:2,min:0.8,max:1|IN-8637-RGB;n:type:ShaderForge.SFN_Multiply,id:178,x:33892,y:32342,varname:node_178,prsc:2|A-8274-RGB,B-7241-RGB;n:type:ShaderForge.SFN_SwitchProperty,id:3034,x:33783,y:32653,ptovrint:False,ptlb:Use_Diffuse_TEX,ptin:_Use_Diffuse_TEX,varname:node_3034,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-5675-RGB,B-7776-OUT;n:type:ShaderForge.SFN_Color,id:5675,x:33527,y:32573,ptovrint:False,ptlb:Outline_COLOR,ptin:_Outline_COLOR,varname:node_5675,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:7241-8274-8637-2681-107-3034-5675;pass:END;sub:END;*/

Shader "Shader Forge/CharacterBody" {
    Properties {
        _BaseColor ("BaseColor", Color) = (1,1,1,1)
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Diffuse_Ramp ("Diffuse_Ramp", 2D) = "white" {}
        _Outline_Width ("Outline_Width", Range(0, 1)) = 0.1601015
        _OutlineValue ("OutlineValue", Range(0, 1)) = 0.8703384
        [MaterialToggle] _Use_Diffuse_TEX ("Use_Diffuse_TEX", Float ) = 0.5
        _Outline_COLOR ("Outline_COLOR", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 2.0
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _Outline_Width;
            uniform float _OutlineValue;
            uniform fixed _Use_Diffuse_TEX;
            uniform float4 _Outline_COLOR;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*(_Outline_Width/10.0),1) );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                return fixed4(lerp( _Outline_COLOR.rgb, (_Diffuse_var.rgb*_OutlineValue), _Use_Diffuse_TEX ),0);
            }
            ENDCG
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 2.0
            uniform float4 _BaseColor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Diffuse_Ramp; uniform float4 _Diffuse_Ramp_ST;
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
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float node_9126 = (max(0,dot(lightDirection,i.normalDir))*0.49+0.5);
                float2 node_4544 = float2(node_9126,node_9126);
                float4 _Diffuse_Ramp_var = tex2D(_Diffuse_Ramp,TRANSFORM_TEX(node_4544, _Diffuse_Ramp));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 emissive = (clamp(_Diffuse_Ramp_var.rgb,0.8,1)*(_Diffuse_var.rgb*_BaseColor.rgb));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Toony Colors Pro 2/Mobile"
    CustomEditor "ShaderForgeMaterialInspector"
}
