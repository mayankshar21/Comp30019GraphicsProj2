// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Code learnt and adapted from https://www.youtube.com/watch?v=Tjl8jP5Nuvc
// Fog formula and concept also adapted from http://in2gpu.com/2014/07/22/create-fog-shader/
Shader "Unlit/FogShader"
{
	Properties
	{
		
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		Zwrite On

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct vertIn
			{
				float4 vertex : POSITION;
			};

			struct vertOut
			{
				float4 vertex : SV_POSITION;
				float distance : DISTANCE;
			};
			
			vertOut vert (vertIn v)
			{
				vertOut o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				float distance = -mul(UNITY_MATRIX_MV, v.vertex).z;
				o.distance = distance;
				return o;
			}

			half4 _Color;


			fixed4 frag (vertOut v) : SV_Target
			{	
				float density = 0.10;
				float exponentialPower = v.distance * density; 
				float fogfactor = 1 / exp(pow(exponentialPower, 2));
				float fogInversion = fogfactor;
				fixed4 returnColor = float4(fogInversion,fogInversion,fogInversion,1);
				return returnColor;
			}
			ENDCG
		}
	}
}
