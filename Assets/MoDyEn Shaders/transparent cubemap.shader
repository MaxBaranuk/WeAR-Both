// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-8904-OUT,alpha-6091-OUT;n:type:ShaderForge.SFN_Cubemap,id:1437,x:32132,y:32613,ptovrint:False,ptlb:Cubemap,ptin:_Cubemap,varname:_Cubemap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,cube:7f71aac1f389efa429fb08eff95c095e,pvfc:0|MIP-7781-OUT;n:type:ShaderForge.SFN_Slider,id:6091,x:32138,y:32971,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:_Opacity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_ValueProperty,id:7781,x:31944,y:32596,ptovrint:False,ptlb:Reflection blur,ptin:_Reflectionblur,varname:_Reflectionblur,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:5813,x:32313,y:32737,varname:node_5813,prsc:2|A-1437-RGB,B-2388-RGB;n:type:ShaderForge.SFN_Color,id:2388,x:31998,y:32820,ptovrint:False,ptlb:Cubemap color,ptin:_Cubemapcolor,varname:_Cubemapcolor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Fresnel,id:9353,x:32132,y:32430,varname:node_9353,prsc:2|EXP-5952-OUT;n:type:ShaderForge.SFN_Multiply,id:8904,x:32452,y:32584,varname:node_8904,prsc:2|A-9353-OUT,B-5813-OUT;n:type:ShaderForge.SFN_Slider,id:5952,x:31767,y:32441,ptovrint:False,ptlb:Fresnel intensity,ptin:_Fresnelintensity,varname:_Fresnelintensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;proporder:1437-6091-7781-2388-5952;pass:END;sub:END;*/

Shader "Shader Forge/transparent cubemap" {
    Properties {
        _Cubemap ("Cubemap", Cube) = "_Skybox" {}
        _Opacity ("Opacity", Range(0, 1)) = 1
        _Reflectionblur ("Reflection blur", Float ) = 0
        _Cubemapcolor ("Cubemap color", Color) = (1,1,1,1)
        _Fresnelintensity ("Fresnel intensity", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 2.0
            #pragma glsl
            uniform samplerCUBE _Cubemap;
            uniform float _Opacity;
            uniform float _Reflectionblur;
            uniform float4 _Cubemapcolor;
            uniform float _Fresnelintensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float3 node_8904 = (pow(1.0-max(0,dot(normalDirection, viewDirection)),_Fresnelintensity)*(texCUBElod(_Cubemap,float4(viewReflectDirection,_Reflectionblur)).rgb*_Cubemapcolor.rgb));
                float3 emissive = node_8904;
                float3 finalColor = emissive;
                return fixed4(finalColor,_Opacity);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
